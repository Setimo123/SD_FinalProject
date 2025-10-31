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

        private int? _bulletinId; // Null for create, has value for edit
        private bool _isEditMode;

        public CreateBulletin()
        {
            InitializeComponent();
            _isEditMode = false;
        }

        // Constructor for edit mode
        public CreateBulletin(int bulletinId) : this()
        {
            _bulletinId = bulletinId;
            _isEditMode = true;
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

            try
            {
                // Disable button to prevent multiple submissions
                btnPublishBulletin.Enabled = false;
                
                if (_isEditMode && _bulletinId.HasValue)
                {
                    // Update existing bulletin - NO event raising, service handles the refresh
                    bool success = await BulletinService.Instance.UpdateBulletin(
                        _bulletinId.Value,
                        txtTitle.Text.Trim(),
                        txtAuthor.Text.Trim(),
                        txtContent.Text.Trim(),
                        "Pending" // Keep status as Pending for edited bulletins
                    );
                    
                    if (success)
                    {
                        MessageBox.Show(
                            "Bulletin has been updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        
                        // Just close - BulletinService already raised BulletinsChanged event
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to update bulletin. Please try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        btnPublishBulletin.Enabled = true;
                    }
                }
                else
                {
                    // Create new bulletin
                    var bulletinData = new BulletinPublishedEventArgs
                    {
                        Title = txtTitle.Text.Trim(),
                        Author = txtAuthor.Text.Trim(),
                        Content = txtContent.Text.Trim(),
                        Status = "Pending", // Default status for newly published bulletins
                        DatePosted = DateTime.Now
                    };

                    // Publish bulletin through the service to database
                    bool success = await BulletinService.Instance.PublishBulletin(bulletinData);
                    
                    if (success)
                    {
                        // Show success message
                        MessageBox.Show(
                            $"Bulletin '{bulletinData.Title}' has been published successfully!", 
                            "Success", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                        
                        // Note: BulletinService already raises BulletinPublished and BulletinsChanged events
                        // No need to raise BulletinPublished here again
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to publish bulletin. Please try again.", 
                            "Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        btnPublishBulletin.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred: {ex.Message}", 
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