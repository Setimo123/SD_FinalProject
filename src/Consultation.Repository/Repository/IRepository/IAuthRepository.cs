using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository.Repository.IRepository
{
    public interface IAuthRepository
    {
        Task<Users?> GetUserByEmail(string email);
    }
}
