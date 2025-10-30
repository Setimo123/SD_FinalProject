using Consultation.Repository.IRepository;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Consultation.Repository.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace Consultation.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<Users> _passwordHasher;
        private readonly UserManager<Users> _userManager;

        public UserRepository(AppDbContext context, UserManager<Users> userManager,
            IPasswordHasher<Users> passwordHasher)
        {
            _context = context;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }
           

        public async Task<Users?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }  


        public async Task CreateAccount(string username,
            string email,string password,Consultation.Domain.Enum.UserType usertype
            ,string UMID)
        {
                var createUser = new Users
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = username,
                    Email = email,
                    UMID = UMID,
                    UserType = usertype,
                    NormalizedEmail = email.ToUpperInvariant(),
                    NormalizedUserName = username.ToUpperInvariant(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };
                    createUser.PasswordHash = new PasswordHasher<Users>().HashPassword(createUser, password);
                     _context.Users.Add(createUser);
                   await _context.SaveChangesAsync();


            if (usertype == Consultation.Domain.Enum.UserType.Student)
            {
                var student = new Student
                {
                 UsersID  = createUser.Id,
                 StudentUMID = UMID,
                 SchoolYearID = 1,
                 StudentName = username,
                 yearLevel = Enum.YearLevel.Third_Year,
                 Email = email,
                 ProgramID = 3,
                };
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return;
            }

            if (usertype == Consultation.Domain.Enum.UserType.Faculty)
            {
                var faculty = new Faculty
                {
                    FacultyEmail = email,
                    FacultyUMID = UMID,
                    ProgramID = 3,
                    UsersID = createUser.Id,
                    SchoolYearID = 1,
                };
                _context.Faculty.Add(faculty);
                await _context.SaveChangesAsync();
                return;
            }
        }


        public async Task<bool> ChangePassword(string newPassword, string email,string oldPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                Console.WriteLine("No User Found");
                return false;
            }

            if (newPassword != null)
            {
                var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, oldPassword);
                if (passwordVerification == PasswordVerificationResult.Failed)
                {
                    Console.WriteLine("Old Password is incorrect");
                    return false;
                }

                user.PasswordHash = _passwordHasher.HashPassword(user, newPassword);
                await _context.SaveChangesAsync();
                return true;
            }

            return true;
        }

        public async Task<Users> ChangePasswordTest(string newPassword, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }
    }
}
