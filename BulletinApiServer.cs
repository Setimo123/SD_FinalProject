// ===================================================================
// WPF API Bridge - Add this to your WPF .NET 8 Project
// ===================================================================
// This creates a background HTTP API server in your WPF application
// that allows your Next.js app to fetch data from LocalDB
// ===================================================================

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Consultation.Infrastructure.Data;
using Consultation.Domain;

namespace Consultation.App.Services
{
    /// <summary>
    /// Background API server that bridges Next.js with LocalDB
    /// </summary>
    public class BulletinApiServer
    {
        private WebApplication? _app;
        private Task? _runTask;

        /// <summary>
        /// Start the API server on port 5000
        /// Call this in App.xaml.cs or MainWindow constructor
        /// </summary>
        public async Task StartAsync()
        {
            try
            {
                var builder = WebApplication.CreateBuilder();

                // Configure Kestrel to listen on port 5000
                builder.WebHost.UseUrls("http://localhost:5000");

                // Add CORS to allow Next.js (localhost:3000) to call this API
                builder.Services.AddCors(options =>
                {
                    options.AddDefaultPolicy(policy =>
                    {
                        policy.WithOrigins("http://localhost:3000", "http://localhost:3001")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
                });

                // Add your DbContext
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ConsultationDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

                _app = builder.Build();

                // Enable CORS
                _app.UseCors();

                // ===================================================================
                // API ENDPOINTS
                // ===================================================================

                // GET /api/bulletin - Fetch all active bulletins
                _app.MapGet("/api/bulletin", async (AppDbContext db) =>
                {
                    try
                    {
                        var bulletins = await db.Bulletin
                            .Where(b => b.IsArchived == false)
                            .OrderByDescending(b => b.DatePublished)
                            .Select(b => new
                            {
                                Id = b.BulletinID,
                                b.Title,
                                b.Author,
                                b.Content,
                                b.Status,
                                b.DatePublished,
                                b.FileCount,
                                b.IsArchived
                            })
                            .ToListAsync();

                        Console.WriteLine($"✅ API: Returned {bulletins.Count} bulletins");
                        return Results.Ok(bulletins);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ API Error: {ex.Message}");
                        return Results.Problem(ex.Message);
                    }
                });

                // POST /api/bulletin - Create new bulletin
                _app.MapPost("/api/bulletin", async (AppDbContext db, BulletinCreateDto dto) =>
                {
                    try
                    {
                        var bulletin = new Bulletin
                        {
                            Title = dto.Title,
                            Author = dto.Author,
                            Content = dto.Content,
                            Status = dto.Status,
                            DatePublished = DateTime.Now,
                            FileCount = dto.FileCount,
                            IsArchived = dto.IsArchived
                        };

                        db.Bulletin.Add(bulletin);
                        await db.SaveChangesAsync();

                        Console.WriteLine($"✅ API: Created bulletin '{dto.Title}'");
                        return Results.Ok(new { success = true, message = "Bulletin created." });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ API Error: {ex.Message}");
                        return Results.Problem(ex.Message);
                    }
                });

                // Health check endpoint
                _app.MapGet("/api/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.Now }));

                Console.WriteLine("🚀 Starting Bulletin API Bridge on http://localhost:5000");
                
                // Run the server in a background task
                _runTask = _app.RunAsync();
                
                Console.WriteLine("✅ Bulletin API Bridge is running!");
                Console.WriteLine("   - Health: http://localhost:5000/api/health");
                Console.WriteLine("   - Bulletins: http://localhost:5000/api/bulletin");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to start API server: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Stop the API server (call this when closing the app)
        /// </summary>
        public async Task StopAsync()
        {
            if (_app != null)
            {
                Console.WriteLine("⏹️ Stopping Bulletin API Bridge...");
                await _app.StopAsync();
                await _app.DisposeAsync();
                Console.WriteLine("✅ Bulletin API Bridge stopped");
            }
        }
    }

    // ===================================================================
    // DTO (Data Transfer Object) for creating bulletins
    // ===================================================================
    public record BulletinCreateDto(
        string Title,
        string Author,
        string Content,
        int Status,
        int FileCount = 0,
        bool IsArchived = false
    );
}
