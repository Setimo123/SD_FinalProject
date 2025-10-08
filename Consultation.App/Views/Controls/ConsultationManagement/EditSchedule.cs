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
            cardToEdit.Data = new ConsultationData
            {
                Name = StudentName.Text,
                IDNumber = Idnumber.Text,
                CourseCode = CourseCode.Text,
                Location = Location.Text,
                Faculty = Faculty.Text,
                Time = comboboxTime.SelectedItem.ToString() ?? "",
                Notes = Notes.Text,
                Date = Date.Text,

            };

            this.Close();
        }

        
                private void SetTime()
                {
                    comboboxTime.Items.Clear();

                    DateTime Start = DateTime.Today.AddHours(8);
                    DateTime End = DateTime.Today.AddHours(17);

                    while(Start <= End)
                    {
                        comboboxTime.Items.Add(Start.ToString("hh:mm tt"));
                        Start = Start.AddMinutes(5);

                    }

                    comboboxTime.SelectedIndex = 0;

                }
        

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboboxTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}