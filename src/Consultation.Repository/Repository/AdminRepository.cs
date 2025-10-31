using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Infrastructure.Data;
using Consultation.Repository.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context) => _context = context;

        public async Task<List<Admin>> GetAllAdmin()
        {
            try
            {
                var admins = await _context.Admin
                    .Include(a => a.Users)
                    .Where(a => a.Users.UserType == UserType.Admin)
                    .AsNoTracking()
                    .ToListAsync();

                return admins ?? new List<Admin>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Admin Repository Error: {ex.Message}");
                return new List<Admin>();
            }
        }

        public async Task<int> GetTotalAdminCount()
        {
            try
            {
                var count = await _context.Admin
                    .Include(a => a.Users)
                    .Where(a => a.Users.UserType == UserType.Admin)
                    .CountAsync();

                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Admin Repository Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<List<Admin>> SearchAdmin(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return await GetAllAdmin();
                }

                searchTerm = searchTerm.ToLower().Trim();

                var admins = await _context.Admin
                    .Include(a => a.Users)
                    .Where(a => a.Users.UserType == UserType.Admin)
                    .Where(a => 
                        a.AdminName.ToLower().Contains(searchTerm) ||
                        a.Users.UMID.ToLower().Contains(searchTerm) ||
                        a.Users.Email.ToLower().Contains(searchTerm))
                    .AsNoTracking()
                    .ToListAsync();

                return admins ?? new List<Admin>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Admin Repository Error: {ex.Message}");
                return new List<Admin>();
            }
        }
    }
}//dapat makita ni siya sa akong i push

