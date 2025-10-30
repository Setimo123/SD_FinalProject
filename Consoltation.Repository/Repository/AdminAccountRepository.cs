using Consultation.Repository.IRepository;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository
{
    public class AdminAccountRepository : IAdminAccountRepository
    {
        private readonly AppDbContext _context;

        public AdminAccountRepository(AppDbContext context) => _context = context;

        public async Task<Admin?> GetAdminAccount(string userId)
        {
            return await _context.Admin.FirstOrDefaultAsync(x => x.UsersID == userId);
        }
    }
}
