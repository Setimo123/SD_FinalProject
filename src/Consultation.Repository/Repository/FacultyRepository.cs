using Consultation.Domain;
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
    public class FacultyRepository : IFacultyRepository
    {
        private readonly AppDbContext _context;

        public FacultyRepository(AppDbContext context) => _context = context;
        public async Task<List<ConsultationRequest?>> FacultyConsultation(int id)
        {
            var consultation = await _context.ConsultationRequest.Include(cr => cr.Faculty)
                .Where(f => f.FacultyID == id)
                .Include(s => s.Student)
                .ToListAsync();

            return consultation;
        }

        public async Task ChangeConsultationByID(int id,Consultation.Domain.Enum.Status status,string reason)
        {

            var consultation = await _context.ConsultationRequest
                .FirstOrDefaultAsync(c => c.ConsultationID == id) ?? new ConsultationRequest();

                  if (consultation == null)
                 {
                     return;
                 }
                consultation.DisapprovedReason = reason;
                consultation.Status = status;
                await _context.SaveChangesAsync();
        }

        public async Task<Faculty> GetFacultyInformation(string faucltyUMID)
        {
            try
            {
                var faculty = _context.Faculty
                       .Include(f => f.SchoolYear)
                       .ThenInclude(f => f.EnrolledCourses)
                       .Include(f => f.ConsultationRequests)
                       .Include(f => f.Program)
                       .FirstOrDefaultAsync(f => f.FacultyUMID == faucltyUMID);
                return await faculty ?? new Faculty();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Student Repository Error: {ex.Message}");
                return new Faculty();
            }
        }

        public async Task<List<Faculty>> GetAllFaculty()
        {
            try
            {
                var faculty = await _context.Faculty
                    .Include(f => f.Users)
                    .Where(f => f.Users.UserType == Domain.Enum.UserType.Faculty)
                    .Include(f => f.Program)
                    .AsNoTracking()
                    .ToListAsync();

                return faculty ?? new List<Faculty>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Faculty Repository Error: {ex.Message}");
                return new List<Faculty>();
            }
        }

        public async Task<int> GetTotalFacultyCount()
        {
            try
            {
                var count = await _context.Faculty
                    .Include(f => f.Users)
                    .Where(f => f.Users.UserType == Domain.Enum.UserType.Faculty)
                    .CountAsync();

                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Faculty Repository Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<List<Faculty>> SearchFaculty(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return await GetAllFaculty();
                }

                searchTerm = searchTerm.ToLower().Trim();

                var faculty = await _context.Faculty
                    .Include(f => f.Users)
                    .Where(f => f.Users.UserType == Domain.Enum.UserType.Faculty)
                    .Include(f => f.Program)
                    .Where(f => 
                        f.FacultyName.ToLower().Contains(searchTerm) ||
                        f.FacultyUMID.ToLower().Contains(searchTerm) ||
                        f.FacultyEmail.ToLower().Contains(searchTerm))
                    .AsNoTracking()
                    .ToListAsync();

                return faculty ?? new List<Faculty>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Faculty Repository Error: {ex.Message}");
                return new List<Faculty>();
            }
        }
    }
}
