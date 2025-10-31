using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.BackEndCRUD.Service.IService
{
    public interface IAuthService
    {
        Task<Users?> Login(string email, string password);
    }
}
