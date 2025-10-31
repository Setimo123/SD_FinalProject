using Consultation.Service.IService;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Consultation.Repository.IRepository;
using Consultation.Repository;
using Consultation.Domain.Enum;
using Consultation.Repository.Repository.IRepository;


namespace Consultation.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _userRepository;
        private readonly PasswordHasher<Users> _passwordHasher;
        private readonly UserManager<Users> _userManager;
        private readonly AppDbContext _appDbContext;
        private Users? user;
        public string AdminUserID { get; set; }
      

        public AuthService(AppDbContext context)
        {
            _appDbContext = context;
            _passwordHasher = new PasswordHasher<Users>();
            _userRepository = new UserRepository(context);
            //_userManager = userManager UserManager<Users> userManager;

        }
        public async Task<Users?> Login(string email, string password,string role)
        {
            user = await _userRepository.GetUserByEmail(email);
            if (user == null)
                return null;

            var userFilter = role switch
            {
                "Admin" => user.UserType.ToString() == UserType.Admin.ToString(),
                "Faculty" => user.UserType.ToString() == UserType.Faculty.ToString(),
                "Student" => user.UserType.ToString() == UserType.Student.ToString(),
                _ => false
            };

            if (!userFilter)
                return null;

           var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
           return result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success ? user : null;
        }

        public Task<Users?> CreateAccount(string email, string password, UserType role, string name, string phonenumber = "")
        {
            switch (role)
            {
                case UserType.Student:
                    return InformationFillup(_appDbContext, email, password, name, role, phonenumber);
                case UserType.Faculty:
                    return InformationFillup(_appDbContext, email, password, name, role, phonenumber);
                default:
                    return null;
            }
        }

        private async Task<Users?> InformationFillup(AppDbContext db, string email, string password, string name, UserType role, string phonenumber)
        {

            var createaccount = new Users
            {
                Email = email,
                Id = Guid.NewGuid().ToString(),
                UserName = name,
                NormalizedEmail = name.ToUpper(),
                PhoneNumber = phonenumber,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                UMID = name.Split('@')[0].Split('.')[2],
                LockoutEnd = null,
                AccessFailedCount = 0,
                LockoutEnabled = false,
                NormalizedUserName = name.ToUpper(),
                UserType = role,
                PasswordHash = password,

            };

            var result = await _userManager.CreateAsync(createaccount);

            return result.Succeeded ? user : null;
        }
    }
}
