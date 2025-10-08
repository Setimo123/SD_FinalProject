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
                Time = Time.Text,
                Notes = Reason.Text,

            };

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        //Change into combobox 
        //daghan error
        private void Time_Click(object sender, EventArgs e)
        {
            Paneltime.Left = Time.Left + (Time.Width - Paneltime.Width) / 2;
            Paneltime.Top = Time.Bottom;
            Paneltime.Visible = true;
            LabelMinutes.Focus();
        }

        private void LabelHours_Click(object sender, EventArgs e)
        {
            int hours = int.Parse(LabelHours.Text);
            hours = hours % 12 + 1;
            LabelHours.Text = hours.ToString("");
        }

        private void LabelMinutes_MouseClick(object sender, MouseEventArgs e)
        {
            int minutes = int.Parse(LabelMinutes.Text);
            int tens = minutes / 10;
            int ones = minutes % 10;

            if (e.X < LabelMinutes.Width / 2)
                minutes = (minutes + 10) % 60;
            else
                minutes = (minutes + 1) % 60;

            LabelMinutes.Text = minutes.ToString("00");
        }

        private void LabelAMPM_Click(object sender, EventArgs e)
        {
            LabelAMPM.Text = LabelAMPM.Text == "AM" ? "PM" : "AM";
        }

        private void UpdateTime()
        {
            Time.Text = LabelHours.Text + " : " + LabelMinutes.Text + " " + LabelAMPM.Text;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            UpdateTime();
            Paneltime.Visible = false;
        }

        //ComboBox Time Picker
        private void comboboxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboboxTime.Items.Count == 0)
            {
                for (int hour = 1; hour <= 12; hour++)
                {
                    for (int minute = 0; minute <= 60; minute += 10)
                    {
                        string timeAm = hour.ToString() + ":" + (minute < 10 ? "0" + minute.ToString() : minute.ToString()) + " AM";
                        string timePm = hour.ToString() + ":" + (minute < 10 ? "0" + minute.ToString() : minute.ToString()) + " PM";
                        comboboxTime.Items.Add(timePm);
                        comboboxTime.Items.Add(timeAm);
                    }
                }
                comboboxTime.SelectedIndex = 0;
                return;
            }
        }
    }
}
