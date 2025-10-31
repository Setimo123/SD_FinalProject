using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("==================================");
Console.WriteLine("Database Migration Runner");
Console.WriteLine("==================================");
Console.WriteLine("");

try
{
    Console.WriteLine("Creating AppDbContext...");
    using (var context = new AppDbContext())
    {
        Console.WriteLine("Checking connection...");
        Console.WriteLine($"Database: {context.Database.GetConnectionString()}");
        Console.WriteLine("");
      
    Console.WriteLine("Deleting existing database if present...");
        context.Database.EnsureDeleted();
      
        Console.WriteLine("Creating database and seeding data...");
   context.Database.EnsureCreated();
        
        Console.WriteLine("");
 Console.WriteLine("? SUCCESS! Database created and seeded!");
        Console.WriteLine("");

        // Verify users were seeded
        var userCount = context.Users.Count();
        Console.WriteLine($"Total users in database: {userCount}");
        
        if (userCount > 0)
    {
       Console.WriteLine("");
         Console.WriteLine("Admin users:");
 var admins = context.Users.Where(u => u.UserType == Consultation.Domain.Enum.UserType.Admin).ToList();
     foreach (var admin in admins)
        {
       Console.WriteLine($"  - {admin.UserName} ({admin.Email})");
    }
        }
 
    Console.WriteLine("");
        Console.WriteLine("You can now login with:");
      Console.WriteLine("  Email: jgallenero@umindanao.edu.ph");
   Console.WriteLine("  Password: MyAdmin123!");
        Console.WriteLine("");
    }
}
catch (Exception ex)
{
    Console.WriteLine("");
    Console.WriteLine("? ERROR!");
    Console.WriteLine($"Message: {ex.Message}");
    Console.WriteLine("");
    if (ex.InnerException != null)
    {
   Console.WriteLine("Inner Exception:");
        Console.WriteLine(ex.InnerException.Message);
    }
  Console.WriteLine("");
    Console.WriteLine("Stack Trace:");
    Console.WriteLine(ex.StackTrace);
}

Console.WriteLine("");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
