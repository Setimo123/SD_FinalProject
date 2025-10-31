using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository.Repository.IRepository
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAdmin();
        Task<int> GetTotalAdminCount();
        Task<List<Admin>> SearchAdmin(string searchTerm);
    }
}
