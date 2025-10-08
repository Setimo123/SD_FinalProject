using Consultation.App.Views.Controls.ConsultationManagement;
using Consultation.App.Views.IViews;
using System;
using System.CodeDom;
using System.Windows.Forms;


namespace Consultation.App.ConsultationManagement
{

    public partial class ConsultationView : UserControl, IConsultationView
    {

        private List<ConsultationCard> activeCards = new List<ConsultationCard>();
        private List<ArchiveCard> archivedCards = new List<ArchiveCard>();


        public ConsultationView()
        {
            InitializeComponent();

            for (int i = 0; i < 4; i++)
            {
                var data = new ConsultationData();
                var card = new ConsultationCard(data);
                card.ArchiveRequested += (s, e) => ArchiveCard(card);
                activeCards.Add(card);
            }

            ShowConsultationView();
        }
        public UserControl AsUserControl => this;


        
        private void ShowConsultationView()
        {
            WindowPanelConsultation.Controls.Clear();
            foreach (var card in activeCards)
            {
                WindowPanelConsultation.Controls.Add(card);
            }
        }

        public void ArchiveCard(ConsultationCard card)
        {
            activeCards.Remove(card);
            WindowPanelConsultation.Controls.Remove(card);

            var archiveCard = new ArchiveCard();
            archiveCard.Data = card.Data;
            archiveCard.RestoreClicked += (s, e) => RestoreCard(archiveCard);
            archivedCards.Add(archiveCard);

            ShowConsultationView();

        }


        private void RestoreCard(ArchiveCard archiveCard)
        {
            archivedCards.Remove(archiveCard);
            WindowPanelConsultation.Controls.Remove(archiveCard);

            var card = new ConsultationCard(archiveCard.Data);
            card.ArchiveRequested += (s, e) => ArchiveCard(card);
            activeCards.Add(card);

            ShowConsultationView();
        }



        private void MoveUnderline(Control targetButton)
        {
            underlinePanel.Width = targetButton.Width;
            underlinePanel.Left = targetButton.Left;
            underlinePanel.Top = targetButton.Bottom - 4;
            underlinePanel.Visible = true;
        }


        private void OnCardArchived(object sender, ArchiveCard archiveCard)
        {
            WindowPanelConsultation.Controls.Remove(archiveCard);
            archivedCards.Remove(archiveCard);

            var data = archiveCard.Data;
            var consultationCard = new ConsultationCard(data);
            consultationCard.ArchiveRequested += (s, e) => ArchiveCard(consultationCard);
            activeCards.Add(consultationCard);

            ShowConsultationView();
        }

        private void ShowArchivedConsultations()
        {
            LabelHeader.Text = "Archived Consultation";
            MoveUnderline(btnArchive);
            WindowPanelConsultation.Controls.Clear();

            foreach (var archiveCard in archivedCards)
            {
                WindowPanelConsultation.Controls.Add(archiveCard);
            }
        }

        private void btnConsultation_Click_1(object sender, EventArgs e)
        {
            btnConsultation.ForeColor = Color.FromArgb(190, 0, 2);
            btnConsultation.Font = new Font(btnConsultation.Font, FontStyle.Bold);
            btnArchive.ForeColor = Color.FromArgb(86, 93, 109);
            btnArchive.Font = new Font(btnArchive.Font, FontStyle.Regular);
            MoveUnderline(btnConsultation);
            LabelHeader.Text = "Active Consultation";
            ShowConsultationView();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            btnArchive.ForeColor = Color.FromArgb(190, 0, 2);
            btnArchive.Font = new Font(btnArchive.Font, FontStyle.Bold);
            btnConsultation.ForeColor = Color.FromArgb(86, 93, 109);
            btnConsultation.Font = new Font(btnConsultation.Font, FontStyle.Regular);
            MoveUnderline(btnArchive);
            LabelHeader.Text = "Archived Consultation";
            ShowArchivedConsultations();
           

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (LabelHeader.Text == "Active Consultation")
            {
                ShowConsultationView();
            }
            else if (LabelHeader.Text == "Archived Consultation")
            {
                ShowArchivedConsultations();
            }
        }

    }
}