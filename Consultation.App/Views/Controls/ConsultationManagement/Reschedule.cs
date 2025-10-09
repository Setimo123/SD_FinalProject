using Consultation.App.ConsultationManagement;
using Syncfusion.Windows.Forms.Tools.XPMenus;
using System;
using System.Windows.Forms;

namespace Consultation.App.Views.Controls.ConsultationManagement
{
    public partial class Reschedule : Form
    {
        private ConsultationCard card;

        public Reschedule(ConsultationCard cardToReschedule)
        {
            InitializeComponent();
            card = cardToReschedule;

            CurrentDate.Text = DateTime.Parse(card.DateText).ToString("MMMM dd, yyyy");
            CurrentTime.Text = card.TimeText;
        }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            card.Data = new ConsultationData
            {
                Date = Date.Text,
                Time = comboboxTime.Text,
                Notes = Reason.Text,

            };

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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
                        string timePm = hour.ToString() +  ":00 PM";
                        comboboxTime.Items.Add(timePm);
                }

                comboboxTime.SelectedIndex = 0;
                return;
            }
        }
    }
}

