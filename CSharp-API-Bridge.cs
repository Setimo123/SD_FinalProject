// ===================================================================
// C# API Bridge for LocalDB - Add this to your C# project
// ===================================================================
// This creates an HTTP API endpoint that your Next.js app can call
// to fetch data from your LocalDB database
// ===================================================================

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

// ===================================================================
// OPTION 1: If you already have an ASP.NET Core project
// ===================================================================
// Add this to your Program.cs or create a new controller

var builder = WebApplication.CreateBuilder(args);

// Add CORS to allow Next.js to call this API
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add your DbContext (replace with your actual DbContext name)
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ConsultationDatabase;Integrated Security=True;"));

var app = builder.Build();

app.UseCors();

// GET endpoint - Fetch all bulletins
app.MapGet("/api/bulletin", async (YourDbContext db) =>
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

    return Results.Ok(bulletins);
});

// POST endpoint - Create new bulletin
app.MapPost("/api/bulletin", async (YourDbContext db, BulletinCreateDto dto) =>
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

    return Results.Ok(new { success = true, message = "Bulletin created." });
});

app.Run("http://localhost:5000");

// ===================================================================
// DTOs (Data Transfer Objects)
// ===================================================================
public record BulletinCreateDto(
    string Title,
    string Author,
    string Content,
    int Status,
    int FileCount = 0,
    bool IsArchived = false
);

// ===================================================================
// OPTION 2: If you have a Console App or WinForms/WPF app
// ===================================================================
// You'll need to:
// 1. Install NuGet packages:
//    - Microsoft.AspNetCore.App
//    - Microsoft.EntityFrameworkCore.SqlServer
//
// 2. Add this code to start a background web server:
/*
public class BulletinApiServer
{
    private WebApplication? _app;

    public async Task StartAsync()
    {
        var builder = WebApplication.CreateBuilder();
        
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        builder.Services.AddDbContext<YourDbContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ConsultationDatabase;Integrated Security=True;"));

        _app = builder.Build();
        _app.UseCors();

        // Add endpoints (same as above)
        _app.MapGet("/api/bulletin", async (YourDbContext db) =>
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

            return Results.Ok(bulletins);
        });

        _app.MapPost("/api/bulletin", async (YourDbContext db, BulletinCreateDto dto) =>
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

            return Results.Ok(new { success = true, message = "Bulletin created." });
        });

        await _app.RunAsync("http://localhost:5000");
    }

    public async Task StopAsync()
    {
        if (_app != null)
        {
            await _app.StopAsync();
            await _app.DisposeAsync();
        }
    }
}

// In your Main method or Form_Load:
var apiServer = new BulletinApiServer();
_ = apiServer.StartAsync(); // Run in background
*/

// ===================================================================
// INSTRUCTIONS:
// ===================================================================
// 1. Replace "YourDbContext" with your actual DbContext class name
// 2. Replace "Bulletin" with your actual entity class name if different
// 3. Make sure your C# project references:
//    - Microsoft.AspNetCore.App
//    - Microsoft.EntityFrameworkCore.SqlServer
// 4. Run your C# application first (it will start on http://localhost:5000)
// 5. Then run your Next.js app (npm run dev)
// 6. Your Next.js app will now fetch data from the C# API bridge
// ===================================================================
