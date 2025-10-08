using Consultation.BackEndCRUD.Repository.IRepository;
using Consultation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Consultation.Domain;

namespace Consultation.BackEndCRUD.Repository
{
    public class EditConsultationrequestRepository : IEditConsultationrequestRepository
    {
        private readonly AppDbContext _context;

        public EditConsultationrequestRepository(AppDbContext context) => _context = context;
        public async Task<ConsultationRequest?> GetConsultationRequests(int studentId)
        {
            return await _context.ConsultationRequest
                                .Include(c => c.Student)
                                .Include(c => c.Faculty)
                                .FirstOrDefaultAsync(c => c.StudentID == studentId);

        }

        public async Task<IEnumerable<ConsultationRequest>> GetConsultationRequestsAsync()
        {
            return await _context.ConsultationRequest
                .Include(c => c.Student)
                .Include(c => c.Faculty)
                .ToListAsync();
        }
    }
}
