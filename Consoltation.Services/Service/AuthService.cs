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
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<Users> _passwordHasher;
        private readonly UserManager<Users> _userManager;
        private readonly AppDbContext _appDbContext;
        private Users? user;
        public string AdminUserID { get; set; }
      

        public AuthService(IUserRepository userRepository,IPasswordHasher<Users> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;

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


        public async Task CreateAccount(string username, string email, string password, Consultation.Domain.Enum.UserType usertype
            ,string UMID)
            {
                await _userRepository.CreateAccount(username, email, password, usertype, UMID);
            }

        public async Task<bool> ChangePassword(string newPassword, string email, string oldPassword)
        {
           return await _userRepository.ChangePassword(newPassword, email, oldPassword);
        }

        public async Task<Users> ChangePasswordTest(string newPassword, string email)
        {
            return await _userRepository.ChangePasswordTest(newPassword, email);
        }
    }
}
