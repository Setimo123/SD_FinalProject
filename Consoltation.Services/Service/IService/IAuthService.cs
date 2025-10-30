using Consultation.Domain;
using Consultation.Domain.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Service.IService
{
    public interface IAuthService
    {
        Task<Users?> Login(string email, string password,string role);
        Task CreateAccount(string username, string email, string password, Consultation.Domain.Enum.UserType usertype
            , string UMID);

        Task<bool> ChangePassword(string newPassword, string email, string oldPassword);

        Task<Users> ChangePasswordTest(string newPassword, string email);
    }


}
