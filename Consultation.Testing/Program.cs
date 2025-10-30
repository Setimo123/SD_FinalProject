
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Consultation.Repository;
using Consultation.Repository.Repository;
using Consultation.Repository.Repository.IRepository;
using Consultation.Service;
using Consultation.Service.IService;
using Consultation.Services.Service;
using Consultation.Services.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace consultation.Testing
{
    public class Program
    {
        private readonly ServiceProvider _provider;
        private readonly IAuthService authServices;
        private readonly IStudentServices studentServices;
        public async static Task Main(string[] args)
        {
            Program p = new Program();

            await p.Test();
        }
        public Program()
        {
            var services = new ServiceCollection();

            var cs = "Server=consultationdb.mysql.database.azure.com;" +
                       "Port=3306;" +
                       "Database=umeca_database;" +
                       "User Id=ConsultationDb;" +
                       "Password=MyServerAdmin123!;" +
                       "SslMode=Required;";


            services.AddDbContext<AppDbContext>(opt =>  
            {
                opt.UseMySql(cs, new MySqlServerVersion(new Version(8, 0, 36)), my =>
                my.EnableRetryOnFailure(
                 maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                 errorNumbersToAdd: null));
            });


            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IStudentRepository, StudentRepository>();    
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordHasher<Users>, PasswordHasher<Users>>();
            services.AddScoped<IStudentServices, StudentServices>();

            services.AddIdentityCore<Consultation.Domain.Users>()
                 .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            _provider = services.BuildServiceProvider();
            authServices = _provider.GetRequiredService<IAuthService>();
            studentServices = _provider.GetRequiredService<IStudentServices>();
        }

        private async Task Test()
        {
            string email = "c.balsomo.544358@umindanao.edu.ph";
            //string newPassword, string email,string oldPassword
            Console.WriteLine(await authServices.ChangePassword("123", email, "MyStudent123!")); 

        }
    }

}



