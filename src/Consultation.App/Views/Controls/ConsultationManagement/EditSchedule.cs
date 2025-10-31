using Consultation.App.Views.Controls.ConsultationManagement;
using Guna.UI2.WinForms;
using Syncfusion.Windows.Forms.Tools.XPMenus;
using System;
using System.Windows.Forms;

namespace Consultation.App.ConsultationManagement
{
    public partial class EditSchedule : Form
    {

        private ConsultationCard cardToEdit;

        public EditSchedule(ConsultationCard cardToEdit)
        {
            InitializeComponent();

            this.cardToEdit = cardToEdit;

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            var data = cardToEdit.Data;

            data.Name = StudentName.Text;
            data.IDNumber = Idnumber.Text;
            data.CourseCode = CourseCode.Text;
            data.Location = Location.Text;
            data.Faculty = Faculty.Text;
            data.Time = comboboxTime.Text;
            data.Notes = Notes.Text;
            data.Date = Date.Text;

            
            cardToEdit.Data = data;

            this.Close();
        }


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboboxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTime = comboboxTime.SelectedItem?.ToString();
        }

        private void comboboxTime_DropDown(object sender, EventArgs e)
        {
            if (comboboxTime.Items.Count == 0)
            {
                for (int hour = 1; hour <= 12; hour++)
                {
                    string timeAm = hour.ToString() + ":00 AM";
                    comboboxTime.Items.Add(timeAm);
                }


                for (int hour = 1; hour <= 12; hour++)
                {
                    string timePm = hour.ToString() + ":00 PM";
                    comboboxTime.Items.Add(timePm);
                }

                comboboxTime.SelectedIndex = 0;
                return;
            }
        }
    }
}