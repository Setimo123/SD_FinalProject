using Consultation.App.Repository;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Consultation.App.Services
{
  /// <summary>
    /// Background API server that bridges Next.js with LocalDB
    /// Lightweight HTTP API server using HttpListener - no additional packages needed
    /// Runs on http://localhost:5000/api/bulletin
    /// </summary>
    public class BulletinApiServer
    {
        private HttpListener _listener;
      private CancellationTokenSource _cancellationTokenSource;
   private Task _listenerTask;

      public bool IsRunning { get; private set; }

     /// <summary>
        /// Start the API server on port 5000
        /// Call this in Program.cs Main method
        /// </summary>
        public async Task StartAsync()
        {
         if (IsRunning)
            {
      Console.WriteLine("⚠️ API Server is already running.");
       return;
     }

   try
   {
      _listener = new HttpListener();
         _listener.Prefixes.Add("http://localhost:5000/");
                _listener.Start();

                _cancellationTokenSource = new CancellationTokenSource();
      IsRunning = true;

                Console.WriteLine("🚀 Starting Bulletin API Bridge on http://localhost:5000");
     Console.WriteLine("✅ Bulletin API Bridge is running!");
                Console.WriteLine("   - Health: http://localhost:5000/api/health");
            Console.WriteLine("   - Bulletins: http://localhost:5000/api/bulletin");
        Console.WriteLine("   - Bulletin by ID: http://localhost:5000/api/bulletin/{id}");
   Console.WriteLine("   - Archived: http://localhost:5000/api/bulletin/archived");

_listenerTask = Task.Run(async () => await ListenAsync(_cancellationTokenSource.Token));
  }
 catch (Exception ex)
            {
      Console.WriteLine($"❌ Failed to start API server: {ex.Message}");
     IsRunning = false;
     throw;
            }
   }

        private async Task ListenAsync(CancellationToken cancellationToken)
        {
         while (!cancellationToken.IsCancellationRequested && _listener.IsListening)
   {
      try
     {
     var context = await _listener.GetContextAsync();
        _ = Task.Run(() => HandleRequestAsync(context), cancellationToken);
        }
     catch (HttpListenerException)
             {
// Listener was stopped
         break;
     }
                catch (Exception ex)
      {
  Console.WriteLine($"⚠️ Listener error: {ex.Message}");
                }
            }
        }

        private async Task HandleRequestAsync(HttpListenerContext context)
        {
   var request = context.Request;
            var response = context.Response;

      // Add CORS headers for Next.js
      response.AddHeader("Access-Control-Allow-Origin", "*");
          response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
      response.AddHeader("Access-Control-Allow-Headers", "Content-Type");

            // Handle preflight OPTIONS request
   if (request.HttpMethod == "OPTIONS")
 {
          response.StatusCode = 200;
       response.Close();
          return;
            }

 try
            {
 var path = request.Url.AbsolutePath.ToLower();
         var method = request.HttpMethod;

  Console.WriteLine($"📥 {method} {path}");

             // Route handling
           if (path == "/api/health")
 {
         await HandleHealthCheck(response);
  }
          else if (path == "/api/bulletin" && method == "GET")
                {
            await HandleGetAllBulletins(response);
    }
                else if (path == "/api/bulletin" && method == "POST")
      {
     await HandleCreateBulletin(request, response);
 }
else if (path.StartsWith("/api/bulletin/archived"))
         {
         await HandleGetArchivedBulletins(response);
  }
       else if (path.StartsWith("/api/bulletin/"))
            {
      var idStr = path.Substring("/api/bulletin/".Length);
             await HandleGetBulletinById(response, idStr);
        }
    else
      {
          response.StatusCode = 404;
        await WriteJsonResponse(response, new { error = "Endpoint not found" });
       }
         }
       catch (Exception ex)
            {
        Console.WriteLine($"❌ API Error: {ex.Message}");
         response.StatusCode = 500;
    await WriteJsonResponse(response, new { error = ex.Message });
            }
        }

   private async Task HandleHealthCheck(HttpListenerResponse response)
        {
            await WriteJsonResponse(response, new 
            { 
      status = "healthy", 
                timestamp = DateTime.Now,
           message = "Bulletin API Bridge is running"
    });
            Console.WriteLine("✅ Health check OK");
        }

        private async Task HandleGetAllBulletins(HttpListenerResponse response)
    {
            using var dbContext = new AppDbContext();
            var bulletins = await dbContext.Bulletin
            .Where(b => !b.IsArchived)
        .OrderByDescending(b => b.DatePublished)
    .Select(b => new
    {
             id = b.BulletinID,
          title = b.Title,
       author = b.Author,
         content = b.Content,
         status = b.Status.ToString(),
          datePublished = b.DatePublished,
                    fileCount = b.FileCount,
      isArchived = b.IsArchived
 })
                .ToListAsync();

            await WriteJsonResponse(response, bulletins);
            Console.WriteLine($"✅ API: Returned {bulletins.Count} bulletins");
        }

        private async Task HandleGetBulletinById(HttpListenerResponse response, string idStr)
      {
    if (!int.TryParse(idStr, out int id))
            {
       response.StatusCode = 400;
    await WriteJsonResponse(response, new { error = "Invalid ID" });
   return;
      }

        using var dbContext = new AppDbContext();
       var bulletin = await dbContext.Bulletin
      .Where(b => b.BulletinID == id)
       .Select(b => new
{
        id = b.BulletinID,
        title = b.Title,
    author = b.Author,
          content = b.Content,
 status = b.Status.ToString(),
   datePublished = b.DatePublished,
             fileCount = b.FileCount,
              isArchived = b.IsArchived
                })
                .FirstOrDefaultAsync();

            if (bulletin == null)
            {
      response.StatusCode = 404;
await WriteJsonResponse(response, new { error = "Bulletin not found" });
            Console.WriteLine($"⚠️ API: Bulletin {id} not found");
      return;
            }

await WriteJsonResponse(response, bulletin);
            Console.WriteLine($"✅ API: Returned bulletin {id}");
        }

        private async Task HandleGetArchivedBulletins(HttpListenerResponse response)
        {
     using var dbContext = new AppDbContext();
            var bulletins = await dbContext.Bulletin
            .Where(b => b.IsArchived)
         .OrderByDescending(b => b.DatePublished)
   .Select(b => new
     {
              id = b.BulletinID,
           title = b.Title,
       author = b.Author,
          content = b.Content,
       status = "Archived",
     datePublished = b.DatePublished,
 fileCount = b.FileCount,
       isArchived = b.IsArchived
         })
    .ToListAsync();

            await WriteJsonResponse(response, bulletins);
        Console.WriteLine($"✅ API: Returned {bulletins.Count} archived bulletins");
        }

        private async Task HandleCreateBulletin(HttpListenerRequest request, HttpListenerResponse response)
   {
            try
            {
         using var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding);
     var json = await reader.ReadToEndAsync();
     
          var dto = JsonSerializer.Deserialize<BulletinCreateDto>(json, new JsonSerializerOptions
              {
       PropertyNameCaseInsensitive = true
 });

             if (dto == null)
           {
 response.StatusCode = 400;
        await WriteJsonResponse(response, new { error = "Invalid request body" });
    return;
    }

    using var dbContext = new AppDbContext();
        var bulletin = new Bulletin
  {
     Title = dto.Title,
  Author = dto.Author,
   Content = dto.Content,
    Status = (Domain.Enum.BulletinStatus)dto.Status,
          DatePublished = DateTime.Now,
          FileCount = dto.FileCount,
               IsArchived = dto.IsArchived
       };

         dbContext.Bulletin.Add(bulletin);
                await dbContext.SaveChangesAsync();

       await WriteJsonResponse(response, new 
      { 
     success = true, 
       message = "Bulletin created.",
       id = bulletin.BulletinID
            });
       Console.WriteLine($"✅ API: Created bulletin '{dto.Title}'");
            }
            catch (Exception ex)
            {
         Console.WriteLine($"❌ API Error creating bulletin: {ex.Message}");
        response.StatusCode = 500;
                await WriteJsonResponse(response, new { error = ex.Message });
            }
        }

     private async Task WriteJsonResponse(HttpListenerResponse response, object data)
        {
       response.ContentType = "application/json";
       response.ContentEncoding = Encoding.UTF8;

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
       {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
         WriteIndented = true
    });

       var buffer = Encoding.UTF8.GetBytes(json);
    response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
 response.Close();
        }

        /// <summary>
        /// Stop the API server (call this when closing the app)
     /// </summary>
        public async Task StopAsync()
        {
     if (!IsRunning || _listener == null)
 {
      return;
      }

 try
{
       Console.WriteLine("⏹️ Stopping Bulletin API Bridge...");
        _cancellationTokenSource?.Cancel();
   _listener.Stop();
                _listener.Close();

 if (_listenerTask != null)
    {
         await _listenerTask;
          }

              IsRunning = false;
                Console.WriteLine("✅ Bulletin API Bridge stopped");
            }
            catch (Exception ex)
       {
       Console.WriteLine($"⚠️ Error stopping API Server: {ex.Message}");
     }
        }
    }

    // ===================================================================
    // DTO (Data Transfer Object) for creating bulletins
    // ===================================================================
    public class BulletinCreateDto
    {
    public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    public int Status { get; set; }
        public int FileCount { get; set; } = 0;
     public bool IsArchived { get; set; } = false;
    }
}
