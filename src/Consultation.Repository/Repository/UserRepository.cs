using Consultation.Repository.IRepository;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Consultation.Repository.Repository.IRepository;

namespace Consultation.Repository
{
    public class UserRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) => _context = context;

        public async Task<Users?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }  
    }
}
