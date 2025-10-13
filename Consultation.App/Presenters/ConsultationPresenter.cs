using Consultation.App.Views.Controls.ConsultationManagement;
using Consultation.App.Views.IViews;
using System;
using System.Collections.Generic;

namespace Consultation.App.Presenters
{
    public class ConsultationPresenter
    {
        private readonly IConsultationView _view;
        private readonly List<ConsultationData> activeConsultations = new();
        private readonly List<ConsultationData> archivedConsultations = new();

        private string currentView = "Active";

        public ConsultationPresenter(IConsultationView view)
        {
            _view = view;

            // Wire up view events
            _view.ShowActiveEvent += (s, e) => ShowActive();
            _view.ShowArchivedEvent += (s, e) => ShowArchived();
            _view.RefreshConsultationsEvent += (s, e) => RefreshView();
            _view.ArchiveRequested += OnArchiveRequested;
            _view.RestoreRequested += OnRestoreRequested;

            LoadDummyData();
            ShowActive();
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

        private void ShowArchived()
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
