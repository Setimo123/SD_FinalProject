using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultation.Domain;


namespace Consultation.BackEndCRUD.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<Users?> GetUserByEmail(string email);
    }
}
