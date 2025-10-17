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
                
                // Display the actual status from the database
                ArcStatus.Text = data.Status;
                
                // Update the visual appearance based on status
                UpdateStatusAppearance();
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

        /// <summary>
        /// Updates the visual appearance of the ArcStatus textbox based on the consultation status
        /// </summary>
        private void UpdateStatusAppearance()
        {
            string status = ArcStatus.Text.Trim();

            // Status 1: Pending - Red/Firebrick
            if (string.Equals(status, "Pending", StringComparison.OrdinalIgnoreCase))
            {
                ArcStatus.FillColor = Color.FromArgb(255, 240, 240);
                ArcStatus.ForeColor = Color.FromArgb(190, 0, 2);
                ArcStatus.Font = new Font(ArcStatus.Font.FontFamily, ArcStatus.Font.Size, FontStyle.Bold);
            }
            // Status 2: Approved - Green
            else if (string.Equals(status, "Approved", StringComparison.OrdinalIgnoreCase))
            {
                ArcStatus.FillColor = Color.FromArgb(220, 252, 231); // Light green background
                ArcStatus.ForeColor = Color.FromArgb(21, 128, 61); // Dark green text
                ArcStatus.Font = new Font(ArcStatus.Font.FontFamily, ArcStatus.Font.Size, FontStyle.Bold);
            }
            // Status 3: Disapproved - Dark Red
            else if (string.Equals(status, "Disapproved", StringComparison.OrdinalIgnoreCase))
            {
                ArcStatus.FillColor = Color.FromArgb(254, 226, 226); // Very light red background
                ArcStatus.ForeColor = Color.FromArgb(153, 27, 27); // Dark red text
                ArcStatus.Font = new Font(ArcStatus.Font.FontFamily, ArcStatus.Font.Size, FontStyle.Bold);
            }
            // Status 4: Cancelled - Orange/Amber
            else if (string.Equals(status, "Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                ArcStatus.FillColor = Color.FromArgb(254, 243, 199); // Light amber background
                ArcStatus.ForeColor = Color.FromArgb(146, 64, 14); // Dark amber text
                ArcStatus.Font = new Font(ArcStatus.Font.FontFamily, ArcStatus.Font.Size, FontStyle.Bold);
            }
            // Status 5: Done - Blue/Gray
            else if (string.Equals(status, "Done", StringComparison.OrdinalIgnoreCase))
            {
                ArcStatus.FillColor = Color.FromArgb(224, 242, 254); // Light blue background
                ArcStatus.ForeColor = Color.FromArgb(30, 64, 175); // Dark blue text
                ArcStatus.Font = new Font(ArcStatus.Font.FontFamily, ArcStatus.Font.Size, FontStyle.Bold);
            }
            // Default fallback
            else
            {
                ArcStatus.FillColor = Color.FromArgb(243, 244, 246); // Light gray background
                ArcStatus.ForeColor = Color.FromArgb(75, 85, 99); // Dark gray text
                ArcStatus.Font = new Font(ArcStatus.Font.FontFamily, ArcStatus.Font.Size, FontStyle.Regular);
            }
        }
    }
}
