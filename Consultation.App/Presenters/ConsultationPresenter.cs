using Consultation.App.Repository;
using Consultation.App.Repository.IRepository;
using Consultation.App.Services;
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
            _view.DeleteRequested += OnDeleteRequested;

            // Subscribe to consultation service for updates
            ConsultationService.Instance.ConsultationsChanged += OnConsultationsChanged;

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

        private async void OnConsultationsChanged(object sender, EventArgs e)
        {
            // Reload consultations from service when data changes
            await LoadDataFromServiceAsync();
            
            // Refresh the current view with the new data
            RefreshView();
        }

        private async Task LoadDataFromDatabaseAsync()
        {
            try
            {
                activeConsultations.Clear();
                archivedConsultations.Clear();

                // Get consultations from service
                var activeFromService = await ConsultationService.Instance.GetActiveConsultations();
                var archivedFromService = await ConsultationService.Instance.GetArchivedConsultations();

                activeConsultations.AddRange(activeFromService);
                archivedConsultations.AddRange(archivedFromService);

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

        private async Task LoadDataFromServiceAsync()
        {
            try
            {
                activeConsultations.Clear();
                archivedConsultations.Clear();

                // Get consultations from service
                var activeFromService = await ConsultationService.Instance.GetActiveConsultations();
                var archivedFromService = await ConsultationService.Instance.GetArchivedConsultations();

                activeConsultations.AddRange(activeFromService);
                archivedConsultations.AddRange(archivedFromService);

                // Don't automatically refresh the view here - let the caller decide
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadDataFromServiceAsync Error: {ex.Message}");
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
                await LoadDataFromServiceAsync();
            }
            else
            {
                RefreshView();
            }
        }

        private async void OnArchiveRequested(object sender, ConsultationData data)
        {
            try
            {
                // Archive in database through service
                bool success = await ConsultationService.Instance.ArchiveConsultation(data.Id);
                
                if (success)
                {
                    // Reload fresh data from service/database
                    await LoadDataFromServiceAsync();
                    
                    // Update current view to show archived
                    currentView = "Archived";
                    
                    // Switch to archived view UI (just moves the underline)
                    _view.SwitchToArchivedView();
                    
                    // Explicitly load archived consultations
                    _view.LoadArchivedConsultations(archivedConsultations);
                    
                    // Service will notify all subscribers (including Dashboard)
                }
                else
                {
                    Console.WriteLine($"Failed to archive consultation {data.Id}");
                    MessageBox.Show("Failed to archive consultation. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OnArchiveRequested Error: {ex.Message}");
                MessageBox.Show($"An error occurred while archiving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnRestoreRequested(object sender, ConsultationData data)
        {
            try
            {
                // Restore in database through service
                bool success = await ConsultationService.Instance.RestoreConsultation(data.Id);
                
                if (success)
                {
                    // Reload fresh data from service/database
                    await LoadDataFromServiceAsync();
                    
                    // Update current view to show active
                    currentView = "Active";
                    
                    // Switch to active view UI (just moves the underline)
                    _view.SwitchToActiveView();
                    
                    // Explicitly load active consultations
                    _view.LoadActiveConsultations(activeConsultations);
                    
                    // Service will notify all subscribers (including Dashboard)
                }
                else
                {
                    Console.WriteLine($"Failed to restore consultation {data.Id}");
                    MessageBox.Show("Failed to restore consultation. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OnRestoreRequested Error: {ex.Message}");
                MessageBox.Show($"An error occurred while restoring: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnDeleteRequested(object sender, ConsultationData data)
        {
            try
            {
                // Delete from database through service
                bool success = await ConsultationService.Instance.DeleteConsultation(data.Id);
                
                if (success)
                {
                    MessageBox.Show(
                        "Consultation has been deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    
                    // Reload fresh data from service/database
                    await LoadDataFromServiceAsync();
                    
                    // Refresh the current view
                    if (currentView == "Active")
                    {
                        _view.LoadActiveConsultations(activeConsultations);
                    }
                    else
                    {
                        _view.LoadArchivedConsultations(archivedConsultations);
                    }
                    
                    // Service will notify all subscribers (including Dashboard)
                }
                else
                {
                    Console.WriteLine($"Failed to delete consultation {data.Id}");
                    MessageBox.Show("Failed to delete consultation. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OnDeleteRequested Error: {ex.Message}");
                MessageBox.Show($"An error occurred while deleting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
