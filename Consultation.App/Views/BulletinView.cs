using Consultation.App.Services;
using Consultation.App.Views.Controls.BulletinManagement;
using Consultation.App.Views.IViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Views
{
    public partial class BulletinView : UserControl, IBulletinView
    {
        public BulletinView()
        {
            InitializeComponent();

            // Subscribe to bulletin service events
            BulletinService.Instance.BulletinsChanged += OnBulletinsChanged;

            btnBulletinView_Click(btnBulletinView, EventArgs.Empty);
        }

        public UserControl AsUserControl => this;

        private void btnCreateBulletin_Click(object sender, EventArgs e)
        {
            CreateBulletin bulletinForm = new CreateBulletin();
            bulletinForm.ShowDialog();
            // Refresh is handled by the BulletinsChanged event
        }

        private void OnBulletinsChanged(object sender, EventArgs e)
        {
            // Refresh the current view
            if (lblBulletinHeader.Text == "Active Bulletins")
            {
                LoadActiveBulletins();
            }
            else if (lblBulletinHeader.Text == "Archived Bulletins")
            {
                LoadArchivedBulletins();
            }
        }

        private void LoadActiveBulletins()
        {
            flpBulletinList.Controls.Clear();
            
            var bulletins = BulletinService.Instance.GetActiveBulletins();
            
            foreach (var bulletin in bulletins)
            {
                var card = new BulletinCard(
                    bulletin.Id,
                    bulletin.Title,
                    bulletin.Author,
                    bulletin.Content,
                    bulletin.Status,
                    bulletin.DatePosted
                );
                flpBulletinList.Controls.Add(card);
            }
            
            // If no bulletins exist, show a message or empty state
            if (bulletins.Count == 0)
            {
                // Optional: Add a label showing "No bulletins available"
                // For now, just leave it empty
            }
        }

        private void btnBulletinView_Click(object sender, EventArgs e)
        {
            btnBulletinView.ForeColor = Color.FromArgb(190, 0, 2);
            btnBulletinView.Font = new Font(btnBulletinView.Font, FontStyle.Bold);
            btnArchive.ForeColor = Color.FromArgb(86, 93, 109);
            btnArchive.Font = new Font(btnArchive.Font, FontStyle.Regular);
            MoveUnderline(btnBulletinView);

            lblBulletinHeader.Text = "Active Bulletins";

            // Load active bulletins from service
            LoadActiveBulletins();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            btnArchive.ForeColor = Color.FromArgb(190, 0, 2);
            btnArchive.Font = new Font(btnBulletinView.Font, FontStyle.Bold);
            btnBulletinView.ForeColor = Color.FromArgb(86, 93, 109);
            btnBulletinView.Font = new Font(btnArchive.Font, FontStyle.Regular);
            MoveUnderline(btnArchive);

            lblBulletinHeader.Text = "Archived Bulletins";

            // Load archived bulletins from service
            LoadArchivedBulletins();
        }
        
        private void LoadArchivedBulletins()
        {
            flpBulletinList.Controls.Clear();
            
            var bulletins = BulletinService.Instance.GetArchivedBulletins();
            
            foreach (var bulletin in bulletins)
            {
                var card = new ArchiveCard(
                    bulletin.Id,
                    bulletin.Title,
                    bulletin.Author,
                    bulletin.Content,
                    bulletin.Status,
                    bulletin.DatePosted
                );
                flpBulletinList.Controls.Add(card);
            }
            
            // If no archived bulletins exist, show a message or empty state
            if (bulletins.Count == 0)
            {
                // Optional: Add a label showing "No archived bulletins"
                // For now, just leave it empty
            }
        }

        private void MoveUnderline(Guna.UI2.WinForms.Guna2Button targetButton)
        {
            panelUnderline.Width = targetButton.Width;
            panelUnderline.Left = targetButton.Left;
            panelUnderline.Top = targetButton.Bottom - 4;
            panelUnderline.Visible = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (lblBulletinHeader.Text == "Active Bulletins")
            {
                btnBulletinView_Click(btnBulletinView, EventArgs.Empty);
            }
            else
            {
                btnArchive_Click(btnArchive, EventArgs.Empty);
            }
        }
    }
}