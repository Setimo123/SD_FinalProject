using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<Users?> GetUserByEmail(string email);

        Task CreateAccount(string username, string email, string password, Consultation.Domain.Enum.UserType usertype, string UMID);

        Task<bool> ChangePassword(string newPassword, string email, string oldPassword);

        Task<Users> ChangePasswordTest(string newPassword, string email);
    }
}
