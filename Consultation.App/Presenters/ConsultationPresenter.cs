using Consultation.App.Repository;
using Consultation.App.Repository.IRepository;
using Consultation.App.Views.Controls.ConsultationManagement;
using Consultation.App.Views.IViews;
using Consultation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultation.App.Presenters
{
    public class ConsultationPresenter
    {
        private readonly IConsultationView _view;
        private readonly IConsultationRequestRepository _consultationRepository;
        private readonly List<ConsultationData> activeConsultations = new();
        private readonly List<ConsultationData> archivedConsultations = new();

        private string currentView = "Active";

        public ConsultationPresenter(IConsultationView view, AppDbContext dbContext = null)
        {
            _view = view;
            
            // Initialize repository if dbContext is provided
            if (dbContext != null)
            {
                _consultationRepository = new ConsultationRequestRepository(dbContext);
            }

            // Wire up view events
            _view.ShowActiveEvent += async (s, e) => await ShowActiveAsync();
            _view.ShowArchivedEvent += async (s, e) => await ShowArchivedAsync();
            _view.RefreshConsultationsEvent += async (s, e) => await RefreshViewAsync();
            _view.ArchiveRequested += OnArchiveRequested;
            _view.RestoreRequested += OnRestoreRequested;

            // Load data from database if available, otherwise use dummy data
            if (_consultationRepository != null)
            {
                _ = LoadDataFromDatabaseAsync();
            }
            else
            {
                LoadDummyData();
                ShowActive();
            }
        }

        private async Task LoadDataFromDatabaseAsync()
        {
            try
            {
                activeConsultations.Clear();
                archivedConsultations.Clear();

                // Get all consultation requests from database
                var allRequests = await _consultationRepository.GetAllConsultations();
                
                if (allRequests == null || !allRequests.Any())
                {
                    // Fallback to dummy data if no database records
                    LoadDummyData();
                    ShowActive();
                    return;
                }

                foreach (var request in allRequests)
                {
                    var consultationData = new ConsultationData
                    {
                        Id = request.ConsultationID,
                        Name = request.Student?.StudentName ?? "Unknown Student",
                        CourseCode = request.SubjectCode,
                        Faculty = request.Faculty?.FacultyName ?? "Unknown Faculty",
                        Location = "TBD", // You may need to add location to your model
                        IDNumber = request.Student?.StudentUMID ?? "N/A",
                        Notes = request.Concern,
                        Date = request.DateSchedule.ToString("MMMM dd, yyyy"),
                        Time = $"{request.StartedTime:hh\\:mm tt} - {request.EndedTime:hh\\:mm tt}",
                        Status = request.Status.ToString()
                    };

                    // Separate active and archived based on status
                    if (request.Status == Domain.Enum.Status.Done)
                    {
                        archivedConsultations.Add(consultationData);
                    }
                    else
                    {
                        activeConsultations.Add(consultationData);
                    }
                }

                await ShowActiveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadDataFromDatabaseAsync Error: {ex.Message}");
                // Fallback to dummy data on error
                LoadDummyData();
                ShowActive();
            }
        }

        private void LoadDummyData()
        {
            if (activeConsultations.Count > 0) return;

            for (int i = 0; i < 5; i++)
            {
                activeConsultations.Add(new ConsultationData
                {
                    Name = $"Student {i + 1}",
                    CourseCode = $"BECE225-{i + 1}",
                    Faculty = $"Engr. Fade {i + 1}",
                    Location = $"Room BE2{i + 1}",
                    IDNumber = $"20250{i + 1}",
                    Notes = "Sample consultation note.",
                    Date = DateTime.Today.AddDays(i).ToString("MMMM dd, yyyy"),
                    Time = "12:30 PM",
                    Status = "Active"
                });
            }
        }

        private void ShowActive()
        {
            currentView = "Active";
            _view.LoadActiveConsultations(activeConsultations);
        }

        private async Task ShowActiveAsync()
        {
            currentView = "Active";
            _view.LoadActiveConsultations(activeConsultations);
        }

        private void ShowArchived()
        {
            currentView = "Archived";
            _view.LoadArchivedConsultations(archivedConsultations);
        }

        private async Task ShowArchivedAsync()
        {
            currentView = "Archived";
            _view.LoadArchivedConsultations(archivedConsultations);
        }

        private void RefreshView()
        {
            if (currentView == "Active")
                ShowActive();
            else
                ShowArchived();
        }

        private async Task RefreshViewAsync()
        {
            if (_consultationRepository != null)
            {
                await LoadDataFromDatabaseAsync();
            }
            else
            {
                RefreshView();
            }
        }

        private void OnArchiveRequested(object sender, ConsultationData data)
        {
            activeConsultations.Remove(data);
            archivedConsultations.Add(data);
            RefreshView();
        }

        private void OnRestoreRequested(object sender, ConsultationData data)
        {
            archivedConsultations.Remove(data);
            activeConsultations.Add(data);
            RefreshView();
        }
    }
}
