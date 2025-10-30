using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Consultation.Repository.IRepository;
using Consultation.Repository;
using Consultation.Service.IService;

namespace Consultation.Service
{
    public class AdminAccountServices : IAdminAccountServices
    {
        private readonly IAdminAccountRepository _adminAccountrepository;
     
        public AdminAccountServices(AppDbContext context)
        {
            _adminAccountrepository = new AdminAccountRepository(context);
        }

        public async Task<Admin?> AdminAccount(string userID)
        {
            return await _adminAccountrepository.GetAdminAccount(userID);
        }

    }
}
