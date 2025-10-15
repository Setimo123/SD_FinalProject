using Consultation.App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Views.Controls.BulletinManagement
{
    public partial class CreateBulletin : Form
    {
        // Event to notify when a bulletin is published
        public event EventHandler<BulletinPublishedEventArgs> BulletinPublished;

        public CreateBulletin()
        {
            InitializeComponent();
        }

        private async void btnPublishBulletin_Click(object sender, EventArgs e)
        {
            // Validate that required fields are not empty
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a bulletin title.", 
                    "Validation Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Please enter the author name.", 
                    "Validation Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                txtAuthor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Please enter the bulletin content.", 
                    "Validation Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                txtContent.Focus();
                return;
            }

            // Create event args with bulletin data
            var bulletinData = new BulletinPublishedEventArgs
            {
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Content = txtContent.Text.Trim(),
                Status = "Pending", // Default status for newly published bulletins
                DatePosted = DateTime.Now
            };

            try
            {
                // Disable button to prevent multiple submissions
                btnPublishBulletin.Enabled = false;
                
                // Publish bulletin through the service to database
                bool success = await BulletinService.Instance.PublishBulletin(bulletinData);
                
                if (success)
                {
                    // Show success message
                    MessageBox.Show($"Bulletin '{bulletinData.Title}' has been published successfully to the database!", 
                        "Success", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    
                    // Raise the event to notify subscribers that a bulletin was published
                    // This happens AFTER the database save is confirmed
                    BulletinPublished?.Invoke(this, bulletinData);
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to publish bulletin to the database. Please try again.", 
                        "Error", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    btnPublishBulletin.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while publishing the bulletin: {ex.Message}", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                btnPublishBulletin.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}