using Consultation.App.Views.Controls.ConsultationManagement;
using System;
using System.Windows.Forms;

namespace Consultation.App.ConsultationManagement
{
    public partial class ConsultationCard : UserControl
    {
        
        public event EventHandler<ConsultationCard> ArchiveRequested;
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
            // TODO: Add delete logic if needed
        }


        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewConsultation viewForm = new ViewConsultation(this);
            viewForm.ShowDialog();
        }
    }
}
