using Consultation.BackEndCRUD.Service;
using Consultation.Infrastructure.Data;
using System;
using System.Threading.Tasks;

Console.WriteLine("==================================");
Console.WriteLine("Login Test");
Console.WriteLine("==================================");
Console.WriteLine("");

try
{
    Console.WriteLine("Creating AppDbContext and AuthService...");
    using (var context = new AppDbContext())
    {
        var authService = new AuthService(context);
   
     Console.WriteLine("Attempting login with:");
        Console.WriteLine("  Email: jgallenero@umindanao.edu.ph");
        Console.WriteLine("  Password: MyAdmin123!");
        Console.WriteLine("");

        var user = await authService.Login("jgallenero@umindanao.edu.ph", "MyAdmin123!");
      
        if (user != null)
        {
Console.WriteLine("? LOGIN SUCCESSFUL!");
       Console.WriteLine($"  User ID: {user.Id}");
    Console.WriteLine($"  Username: {user.UserName}");
   Console.WriteLine($"  Email: {user.Email}");
    Console.WriteLine($"  UMID: {user.UMID}");
            Console.WriteLine($"  User Type: {user.UserType}");
        }
        else
        {
            Console.WriteLine("? LOGIN FAILED - Invalid credentials");
  }
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
