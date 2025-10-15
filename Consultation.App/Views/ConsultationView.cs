using Consultation.App.Views.Controls.ConsultationManagement;
using Consultation.App.Views.IViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Consultation.App.ConsultationManagement
{
    public partial class ConsultationView : UserControl, IConsultationView, IChildView
    {
        public event EventHandler ShowActiveEvent;
        public event EventHandler ShowArchivedEvent;
        public event EventHandler RefreshConsultationsEvent;
        public event EventHandler<ConsultationData> ArchiveRequested;
        public event EventHandler<ConsultationData> RestoreRequested;
        public event EventHandler<ConsultationData> DeleteRequested;

        public UserControl AsUserControl => this;

        private readonly List<ConsultationCard> activeCards = new();
        private readonly List<ArchiveCard> archivedCards = new();

        public ConsultationView()
        {
            InitializeComponent();

            // Set default selected tab
            MoveUnderline(btnConsultation);

            btnConsultation.Click += (s, e) =>
            {
                MoveUnderline(btnConsultation);
                ShowActiveEvent?.Invoke(this, EventArgs.Empty);
            };

            btnArchive.Click += (s, e) =>
            {
                MoveUnderline(btnArchive);
                ShowArchivedEvent?.Invoke(this, EventArgs.Empty);
            };

            btnRefresh.Click += (s, e) => RefreshConsultationsEvent?.Invoke(this, EventArgs.Empty);
        }

        public void LoadActiveConsultations(List<ConsultationData> consultations)
        {
            LabelHeader.Text = "Active Consultations";
            ClearCards();

            foreach (var data in consultations.Distinct())
            {
                var card = new ConsultationCard(data);
                card.ArchiveRequested += (s, e) => ArchiveRequested?.Invoke(this, data);
                card.DeleteRequested += (s, e) => DeleteRequested?.Invoke(this, data);
                activeCards.Add(card);
                WindowPanelConsultation.Controls.Add(card);
            }
        }

        public void LoadArchivedConsultations(List<ConsultationData> consultations)
        {
            LabelHeader.Text = "Archived Consultations";
            ClearCards();

            foreach (var data in consultations)
            {
                var card = new ArchiveCard { Data = data };
                card.RestoreClicked += (s, e) => RestoreRequested?.Invoke(this, data);
                archivedCards.Add(card);
                WindowPanelConsultation.Controls.Add(card);
            }
        }

        private void ClearCards()
        {
            foreach (var card in activeCards)
                WindowPanelConsultation.Controls.Remove(card);
            activeCards.Clear();

            foreach (var card in archivedCards)
                WindowPanelConsultation.Controls.Remove(card);
            archivedCards.Clear();
        }

        public void SwitchToArchivedView()
        {
            // Just move the underline, don't trigger the event
            // The presenter will call LoadArchivedConsultations directly
            MoveUnderline(btnArchive);
        }

        public void SwitchToActiveView()
        {
            // Just move the underline, don't trigger the event
            // The presenter will call LoadActiveConsultations directly
            MoveUnderline(btnConsultation);
        }

        private void MoveUnderline(Control btn)
        {
            if (btn == null || underlinePanel == null) return;

            underlinePanel.Width = btn.Width;
            underlinePanel.Left = btn.Left;
            underlinePanel.Top = btn.Bottom - 2;
            underlinePanel.Visible = true;
            underlinePanel.BringToFront();
        }
    }
}
