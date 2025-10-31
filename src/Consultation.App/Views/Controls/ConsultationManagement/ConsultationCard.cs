using Consultation.App.Views.Controls.ConsultationManagement;
using System;
using System.Windows.Forms;

namespace Consultation.App.ConsultationManagement
{
    public partial class ConsultationCard : UserControl
    {

        public event EventHandler<ConsultationCard> ArchiveRequested;
        public event EventHandler<ConsultationCard> DeleteRequested;
        private ConsultationData data;

        public DateTime ScheduleDate { get; private set; }


        public string NameText => StudentName.Text;
        public string DateText => ScheduleDate.ToShortDateString();
        public string TimeText => Time.Text;
        public string CourseCode => courseCodeLabel.Text;
        public string Faculty => faculty.Text;
        public string LocationText => Location.Text;
        public string IDNumber => Idnumber.Text;
        public string Notes => Noteslabel.Text;
        public string Status => ConStatus.Text;


        public ConsultationCard(ConsultationData _data)
        {
            InitializeComponent();
            Data = _data;
        }


        public ConsultationData Data
        {
            get => data;
            set
            {
                data = value;
                StudentName.Text = data.Name;
                courseCodeLabel.Text = data.CourseCode;
                Noteslabel.Text = data.Notes;
                Date.Text = data.Date;
                Time.Text = data.Time;
                faculty.Text = data.Faculty;
                Idnumber.Text = data.IDNumber;
                Location.Text = data.Location;
                ConStatus.Text = data.Status;

                if (DateTime.TryParse(data.Date, out DateTime parsedDate))
                    ScheduleDate = parsedDate;
                else
                    ScheduleDate = DateTime.MinValue;

                // Update the visual appearance of the ConStatus button based on status
                UpdateStatusAppearance();
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MenuContext.Show(guna2Button1, guna2Button1.Width / 2, guna2Button1.Height);
        }


        private void archiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArchiveRequested?.Invoke(this, this);
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSchedule editForm = new EditSchedule(this);
            editForm.ShowDialog();
        }


        private void rescheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reschedule rescheduleForm = new Reschedule(this);
            rescheduleForm.ShowDialog();
        }



        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Confirm delete action
            var result = MessageBox.Show(
                $"Are you sure you want to delete the consultation for '{StudentName.Text}'? This action cannot be undone.",
                "Delete Consultation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteRequested?.Invoke(this, this);
            }
        }


        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewConsultation viewForm = new ViewConsultation(this);
            viewForm.ShowDialog();
        }

        private void ConStatus_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the visual appearance of the ConStatus button based on the consultation status
        /// </summary>
        private void UpdateStatusAppearance()
        {
            string status = ConStatus.Text.Trim();

            // Status 1: Pending - Red/Firebrick
            if (string.Equals(status, "Pending", StringComparison.OrdinalIgnoreCase))
            {
                ConStatus.FillColor = Color.FromArgb(255, 240, 240);
                ConStatus.ForeColor = Color.FromArgb(190, 0, 2);
                ConStatus.Font = new Font(ConStatus.Font.FontFamily, ConStatus.Font.Size, FontStyle.Bold);
            }
            // Status 2: Approved - Green
            else if (string.Equals(status, "Approved", StringComparison.OrdinalIgnoreCase))
            {
                ConStatus.FillColor = Color.FromArgb(220, 252, 231); // Light green background
                ConStatus.ForeColor = Color.FromArgb(21, 128, 61); // Dark green text
                ConStatus.Font = new Font(ConStatus.Font.FontFamily, ConStatus.Font.Size, FontStyle.Bold);
            }
            // Status 3: Disapproved - Dark Red
            else if (string.Equals(status, "Disapproved", StringComparison.OrdinalIgnoreCase))
            {
                ConStatus.FillColor = Color.FromArgb(254, 226, 226); // Very light red background
                ConStatus.ForeColor = Color.FromArgb(153, 27, 27); // Dark red text
                ConStatus.Font = new Font(ConStatus.Font.FontFamily, ConStatus.Font.Size, FontStyle.Bold);
            }
            // Status 4: Cancelled - Orange/Amber
            else if (string.Equals(status, "Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                ConStatus.FillColor = Color.FromArgb(254, 243, 199); // Light amber background
                ConStatus.ForeColor = Color.FromArgb(146, 64, 14); // Dark amber text
                ConStatus.Font = new Font(ConStatus.Font.FontFamily, ConStatus.Font.Size, FontStyle.Bold);
            }
            // Status 5: Done - Blue/Gray
            else if (string.Equals(status, "Done", StringComparison.OrdinalIgnoreCase))
            {
                ConStatus.FillColor = Color.FromArgb(224, 242, 254); // Light blue background
                ConStatus.ForeColor = Color.FromArgb(30, 64, 175); // Dark blue text
                ConStatus.Font = new Font(ConStatus.Font.FontFamily, ConStatus.Font.Size, FontStyle.Bold);
            }
            // Default fallback
            else
            {
                ConStatus.FillColor = Color.FromArgb(243, 244, 246); // Light gray background
                ConStatus.ForeColor = Color.FromArgb(75, 85, 99); // Dark gray text
                ConStatus.Font = new Font(ConStatus.Font.FontFamily, ConStatus.Font.Size, FontStyle.Regular);
            }
        }
    }
}
