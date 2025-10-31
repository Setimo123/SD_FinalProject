using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

// This program will create the database directly
Console.WriteLine("Creating ConsultationDatabase...");
Console.WriteLine("");

try
{
  using (var context = new AppDbContext())
  {
        Console.WriteLine("Applying migrations...");
    context.Database.Migrate();
        
        Console.WriteLine("");
      Console.WriteLine("? Database created successfully!");
        Console.WriteLine("");
    Console.WriteLine("Database: ConsultationDatabase");
        Console.WriteLine("Server: (localdb)\\MSSQLLocalDB");
        Console.WriteLine("");
        Console.WriteLine("You can now login with:");
        Console.WriteLine("  Email: jgallenero@umindanao.edu.ph");
        Console.WriteLine("  Password: MyAdmin123!");
        Console.WriteLine("");
    }
}
catch (Exception ex)
{
    Console.WriteLine("? Error creating database:");
    Console.WriteLine(ex.Message);
 Console.WriteLine("");
    Console.WriteLine("Inner exception:");
    Console.WriteLine(ex.InnerException?.Message);
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
