using Consultation.App.Repository.IRepository;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Consultation.App.Repository
{
    public class ConsultationRequestRepository : IConsultationRequestRepository
    {
        private readonly AppDbContext _context;

        public ConsultationRequestRepository(AppDbContext context) => _context = context;

        public async Task<List<ConsultationRequest>> GetConsultation(string ProgramName)
        {
            try
            {
                var ConsultationRequestList = await _context.ConsultationRequest.Where(x => x.ProgramName == ProgramName)
                    .ToListAsync();
                return ConsultationRequestList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ConsultationRequestRepository Error: {ex.Message}");
                return null;
            }
        }

        public async Task<ConsultationRequest?> GetStudenInfoConsultationRequests(int studentId)
        {
            return await _context.ConsultationRequest
                                .Include(c => c.Student)
                                .FirstOrDefaultAsync(c => c.StudentID == studentId);
        }

        public async Task<ConsultationRequest?> GetFacultyaInfoConsultationRequests(int facultyId)
        {
            return await _context.ConsultationRequest
                                 .Include(c => c.Faculty)
                                 .FirstOrDefaultAsync(c => c.FacultyID == facultyId);
        }

        
        public async Task<List<ConsultationRequest>> GetConsultationRequestInfo(string programName)
        {
            return await _context.ConsultationRequest
                                 .Include(c => c.Student)
                                 .Include(c => c.Faculty)
                                 .Where(c => c.ProgramName == programName)
                                 .ToListAsync();
        }

        public Task<Student> GetStudentInformation(string studentUMNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, int>> GetActiveConsultationCountsByProgram()
        {
            try
            {
                // Count active consultations (Pending and Approved) grouped by program
                var counts = await _context.ConsultationRequest
                    .Where(c => c.Status == Domain.Enum.Status.Pending || c.Status == Domain.Enum.Status.Approved)
                    .GroupBy(c => c.ProgramName)
                    .Select(g => new { ProgramName = g.Key, Count = g.Count() })
                    .ToListAsync();

                // Convert to dictionary
                var result = new Dictionary<string, int>
                {
                    { "CpE", 0 },
                    { "ME", 0 },
                    { "CE", 0 },
                    { "EE", 0 },
                    { "ECE", 0 },
                    { "ChE", 0 }
                };

                foreach (var item in counts)
                {
                    if (result.ContainsKey(item.ProgramName))
                    {
                        result[item.ProgramName] = item.Count;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetActiveConsultationCountsByProgram Error: {ex.Message}");
                return new Dictionary<string, int>
                {
                    { "CpE", 0 },
                    { "ME", 0 },
                    { "CE", 0 },
                    { "EE", 0 },
                    { "ECE", 0 },
                    { "ChE", 0 }
                };
            }
        }

        public async Task<int> GetActiveConsultationsCount()
        {
            try
            {
                // Count consultations with Pending or Approved status (Active consultations)
                var count = await _context.ConsultationRequest
                    .CountAsync(c => c.Status == Domain.Enum.Status.Pending || 
                                     c.Status == Domain.Enum.Status.Approved);
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetActiveConsultationsCount Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> GetCompletedConsultationsCount()
        {
            try
            {
                // Count consultations with Done status (Completed/Archived consultations)
                var count = await _context.ConsultationRequest
                    .CountAsync(c => c.Status == Domain.Enum.Status.Done);
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCompletedConsultationsCount Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<List<ConsultationRequest>> GetAllConsultations()
        {
            try
            {
                // Get all consultation requests with related student and faculty data
                var consultations = await _context.ConsultationRequest
                    .Include(c => c.Student)
                    .Include(c => c.Faculty)
                    .ToListAsync();
                return consultations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllConsultations Error: {ex.Message}");
                return new List<ConsultationRequest>();
            }
        }
    }
}
