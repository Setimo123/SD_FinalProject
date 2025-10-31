using Consultation.App.Services;
using Consultation.App.Views.Controls.ConsultationManagement;
using Consultation.App.Views.IViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            // Subscribe to consultation service events
            ConsultationService.Instance.ConsultationsChanged += OnConsultationsChanged;

            // Set default selected tab
            MoveUnderline(btnConsultation);

            btnConsultation.Click += async (s, e) =>
            {
                MoveUnderline(btnConsultation);
                await LoadActiveConsultationsFromService();
            };

            btnArchive.Click += async (s, e) =>
            {
                MoveUnderline(btnArchive);
                await LoadArchivedConsultationsFromService();
            };

            btnRefresh.Click += btnRefresh_Click;
        }

        private async void OnConsultationsChanged(object sender, EventArgs e)
        {
            // Refresh the current view when consultations change
            if (LabelHeader.Text == "Active Consultations")
            {
                await LoadActiveConsultationsFromService();
            }
            else if (LabelHeader.Text == "Archived Consultations")
            {
                await LoadArchivedConsultationsFromService();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            if (LabelHeader.Text == "Active Consultations")
            {
                await LoadActiveConsultationsFromService();
            }
            else
            {
                await LoadArchivedConsultationsFromService();
            }
        }

        private async Task LoadActiveConsultationsFromService()
        {
            try
            {
                var consultations = await ConsultationService.Instance.GetActiveConsultations();
                LoadActiveConsultations(consultations);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadActiveConsultationsFromService Error: {ex.Message}");
                MessageBox.Show(
                    "An error occurred while loading active consultations. Please try again.",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadArchivedConsultationsFromService()
        {
            try
            {
                var consultations = await ConsultationService.Instance.GetArchivedConsultations();
                LoadArchivedConsultations(consultations);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadArchivedConsultationsFromService Error: {ex.Message}");
                MessageBox.Show(
                    "An error occurred while loading archived consultations. Please try again.",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
