using Consultation.Domain;
using Consultation.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Service.IService
{
    public interface IAuthService
    {
        Task<Users?> Login(string email, string password,string role);
        Task<Users?> CreateAccount(string email, string password, UserType role, string name, string phonenumber = "");
    }


}
