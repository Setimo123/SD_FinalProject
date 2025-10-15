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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Confirm delete action
            var result = MessageBox.Show(
                $"Are you sure you want to delete the consultation for '{card.Data.Name}'? This action cannot be undone.",
                "Delete Consultation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Delete through the service (database)
                    bool success = await Services.ConsultationService.Instance.DeleteConsultation(card.Data.Id);
                    
                    if (success)
                    {
                        MessageBox.Show(
                            "Consultation has been deleted successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        
                        // Close the form after successful deletion
                        this.Close();
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
