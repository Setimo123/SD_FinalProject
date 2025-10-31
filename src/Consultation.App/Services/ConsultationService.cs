using Consultation.App.Repository;
using Consultation.App.Repository.IRepository;
using Consultation.App.Views.Controls.ConsultationManagement;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultation.App.Services
{
    /// <summary>
    /// Singleton service to manage consultation data across the application using database
    /// </summary>
    public class ConsultationService
    {
        private static ConsultationService _instance;
        private static readonly object _lock = new object();
        
        private readonly IConsultationRequestRepository _repository;
        
        // Event to notify when consultations change
        public event EventHandler ConsultationsChanged;

        private ConsultationService()
        {
            var dbContext = new AppDbContext();
            _repository = new ConsultationRequestRepository(dbContext);
        }

        public static ConsultationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConsultationService();
                        }
                    }
                }
                return _instance;
            }
        }

        public async Task<List<ConsultationData>> GetActiveConsultations()
        {
            try
            {
                var allRequests = await _repository.GetAllConsultations();
                
                if (allRequests == null || !allRequests.Any())
                {
                    return new List<ConsultationData>();
                }

                // Only Pending (1) consultations are shown in Active
                var activeConsultations = allRequests
                    .Where(request => request.Status == Domain.Enum.Status.Pending)
                    .Select(request => new ConsultationData
                    {
                        Id = request.ConsultationID,
                        Name = request.Student?.StudentName ?? "Unknown Student",
                        CourseCode = request.SubjectCode,
                        Faculty = request.Faculty?.FacultyName ?? "Unknown Faculty",
                        Location = "TBD",
                        IDNumber = request.Student?.StudentUMID ?? "N/A",
                        Notes = request.Concern,
                        Date = request.DateSchedule.ToString("MMMM dd, yyyy"),
                        Time = $"{request.StartedTime:hh\\:mm tt} - {request.EndedTime:hh\\:mm tt}",
                        Status = request.Status.ToString()
                    })
                    .ToList();

                return activeConsultations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetActiveConsultations Error: {ex.Message}");
                return new List<ConsultationData>();
            }
        }

        public async Task<List<ConsultationData>> GetArchivedConsultations()
        {
            try
            {
                var allRequests = await _repository.GetAllConsultations();
                
                if (allRequests == null || !allRequests.Any())
                {
                    return new List<ConsultationData>();
                }

                // Approved (2), Disapproved (3), Cancelled (4), and Done (5) consultations are shown in Archive
                var archivedConsultations = allRequests
                    .Where(request => request.Status == Domain.Enum.Status.Approved ||
                                     request.Status == Domain.Enum.Status.Disapproved ||
                                     request.Status == Domain.Enum.Status.Cancelled ||
                                     request.Status == Domain.Enum.Status.Done)
                    .Select(request => new ConsultationData
                    {
                        Id = request.ConsultationID,
                        Name = request.Student?.StudentName ?? "Unknown Student",
                        CourseCode = request.SubjectCode,
                        Faculty = request.Faculty?.FacultyName ?? "Unknown Faculty",
                        Location = "TBD",
                        IDNumber = request.Student?.StudentUMID ?? "N/A",
                        Notes = request.Concern,
                        Date = request.DateSchedule.ToString("MMMM dd, yyyy"),
                        Time = $"{request.StartedTime:hh\\:mm tt} - {request.EndedTime:hh\\:mm tt}",
                        Status = request.Status.ToString()
                    })
                    .ToList();

                return archivedConsultations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetArchivedConsultations Error: {ex.Message}");
                return new List<ConsultationData>();
            }
        }

        public async Task<int> GetActiveConsultationsCount()
        {
            try
            {
                return await _repository.GetActiveConsultationsCount();
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
                return await _repository.GetCompletedConsultationsCount();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCompletedConsultationsCount Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<bool> ArchiveConsultation(int consultationId)
        {
            try
            {
                // Update status to Done (archived) in database
                bool success = await _repository.UpdateConsultationStatus(consultationId, Domain.Enum.Status.Done);
                
                if (success)
                {
                    // Notify all subscribers that consultations have changed
                    ConsultationsChanged?.Invoke(this, EventArgs.Empty);
                }
                
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ArchiveConsultation Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RestoreConsultation(int consultationId)
        {
            try
            {
                // Update status back to Pending (restored) in database
                bool success = await _repository.UpdateConsultationStatus(consultationId, Domain.Enum.Status.Pending);
                
                if (success)
                {
                    // Notify all subscribers that consultations have changed
                    ConsultationsChanged?.Invoke(this, EventArgs.Empty);
                }
                
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RestoreConsultation Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteConsultation(int consultationId)
        {
            try
            {
                bool success = await _repository.DeleteConsultation(consultationId);
                
                if (success)
                {
                    // Notify all subscribers that consultations have changed
                    ConsultationsChanged?.Invoke(this, EventArgs.Empty);
                }
                
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteConsultation Error: {ex.Message}");
                return false;
            }
        }

        public void NotifyConsultationsChanged()
        {
            ConsultationsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
