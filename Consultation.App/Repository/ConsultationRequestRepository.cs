using Consultation.App.Repository.IRepository;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultation.App.Repository
{
    public class ConsultationRequestRepository : IConsultationRequestRepository
    {
        private readonly AppDbContext _context;

        public ConsultationRequestRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ConsultationRequest>> GetAllConsultations()
        {
            try
            {
                return await _context.ConsultationRequest
                    .Include(c => c.Student)
                    .Include(c => c.Faculty)
                    .OrderByDescending(c => c.DateSchedule)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllConsultations Error: {ex.Message}");
                return new List<ConsultationRequest>();
            }
        }

        public async Task<int> GetActiveConsultationsCount()
        {
            try
            {
                return await _context.ConsultationRequest
                    .CountAsync(c => c.Status != Domain.Enum.Status.Done);
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
                return await _context.ConsultationRequest
                    .CountAsync(c => c.Status == Domain.Enum.Status.Done);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCompletedConsultationsCount Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<Dictionary<string, int>> GetActiveConsultationCountsByProgram()
        {
            try
            {
                // Get all active consultations (not Done status) with student and program information
                var consultations = await _context.ConsultationRequest
                    .Where(c => c.Status != Domain.Enum.Status.Done)
                    .Include(c => c.Student)
                        .ThenInclude(s => s.Program)
                    .ToListAsync();

                Console.WriteLine($"Total active consultations found: {consultations.Count}");

                var programCounts = new Dictionary<string, int>();

                foreach (var consultation in consultations)
                {
                    // Get the program name through the student relationship
                    var programName = consultation.Student?.Program?.ProgramName;
                    
                    if (!string.IsNullOrEmpty(programName))
                    {
                        Console.WriteLine($"Consultation ID {consultation.ConsultationID}: Student={consultation.Student?.StudentName}, Program={programName}");
                        
                        if (programCounts.ContainsKey(programName))
                            programCounts[programName]++;
                        else
                            programCounts[programName] = 1;
                    }
                    else
                    {
                        Console.WriteLine($"Consultation ID {consultation.ConsultationID}: No program found (Student={consultation.Student?.StudentName ?? "null"})");
                    }
                }

                Console.WriteLine("=== Program Counts Dictionary ===");
                foreach (var kvp in programCounts)
                {
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }

                return programCounts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetActiveConsultationCountsByProgram Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return new Dictionary<string, int>();
            }
        }

        public async Task<bool> UpdateConsultationStatus(int consultationId, Domain.Enum.Status status)
        {
            try
            {
                var consultation = await _context.ConsultationRequest.FindAsync(consultationId);
                if (consultation == null)
                {
                    Console.WriteLine($"Consultation with ID {consultationId} not found.");
                    return false;
                }

                consultation.Status = status;
                await _context.SaveChangesAsync();
                Console.WriteLine($"Successfully updated consultation {consultationId} status to {status}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateConsultationStatus Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteConsultation(int consultationId)
        {
            try
            {
                var consultation = await _context.ConsultationRequest.FindAsync(consultationId);
                if (consultation == null)
                {
                    Console.WriteLine($"Consultation with ID {consultationId} not found.");
                    return false;
                }

                _context.ConsultationRequest.Remove(consultation);
                await _context.SaveChangesAsync();
                Console.WriteLine($"Successfully deleted consultation {consultationId}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteConsultation Error: {ex.Message}");
                return false;
            }
        }
    }
}
