using System;
using System.Windows.Forms;
using Consultation.App.ConsultationManagement;

namespace Consultation.App.Views.Controls.ConsultationManagement
{
    public partial class ArchiveCard : UserControl
    {
        public event EventHandler<ConsultationData> RestoreClicked;

        private ConsultationData data = new ConsultationData();

        public ArchiveCard()
        {
            InitializeComponent();
        }

        public ConsultationData Data
        {
            get => data;
            set
            {
                data = value;
                Namelabel.Text = data.Name;
                Code.Text = data.CourseCode;
                Notes.Text = data.Notes;
                Date.Text = data.Date;
                Time.Text = data.Time;
                Faculty.Text = data.Faculty;
                idnumber.Text = data.IDNumber;
                Location.Text = data.Location;
                
                // Set the ArcStatus to "Archived"
                ArcStatus.Text = "Archived";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MenuContextArchive.Show(guna2Button1, guna2Button1.Width / 2, guna2Button1.Height);
        }

        private void restoreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RestoreClicked?.Invoke(this, data);
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Confirm delete action
            var result = MessageBox.Show(
                $"Are you sure you want to permanently delete the consultation for '{data.Name}'? This action cannot be undone.",
                "Delete Consultation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Delete through the service (database)
                    bool success = await Services.ConsultationService.Instance.DeleteConsultation(data.Id);
                    
                    if (success)
                    {
                        MessageBox.Show(
                            "Consultation has been permanently deleted!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to delete the consultation. Please try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"An error occurred: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
