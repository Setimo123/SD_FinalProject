using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultation.BackEndCRUD.Repository;
using Consultation.BackEndCRUD.Repository.IRepository;
using Consultation.BackEndCRUD.Service.IService;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


namespace Consultation.BackEndCRUD.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<Users> _passwordHasher;
       
        //public AuthService(UserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //    _passwordHasher = new PasswordHasher<Users>();
        //}

        public AuthService(AppDbContext context)
        {
            _passwordHasher = new PasswordHasher<Users>();
            _userRepository = new UserRepository(context);
        }

        public async Task<Users?> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            return result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success ? user : null;
        }
    }
}
