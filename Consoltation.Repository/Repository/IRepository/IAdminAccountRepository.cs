using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository.IRepository
{
    public interface IAdminAccountRepository
    {
        Task<Admin?> GetAdminAccount(string userId);
    }
}
