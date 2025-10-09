using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Consultation.App.ConsultationManagement;
using Syncfusion.Windows.Tools.Controls;

namespace Consultation.App.Views.Controls.ConsultationManagement
{
    public partial class ViewConsultation : Form
    {

        private ConsultationCard card;
        public ViewConsultation(ConsultationCard cardToView)
        {
            InitializeComponent();
            card = cardToView;
            LoadCardDetails();

        }

        private void LoadCardDetails()
        {
            StudentName.Text = card.Data.Name;
            Date.Text = card.Data.Date;
            Time.Text = card.Data.Time;
            CourseCode.Text = card.Data.CourseCode;
            Faculty.Text = card.Data.Faculty;
            Location.Text = card.Data.Location;
            idnumber.Text = card.Data.IDNumber;
            Notes.Text = card.Data.Notes;
        }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            Reschedule rescheduleForm = new Reschedule(card);
            rescheduleForm.ShowDialog();

         
            LoadCardDetails();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSchedule editForm = new EditSchedule(card);
            editForm.ShowDialog();

     
            LoadCardDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
