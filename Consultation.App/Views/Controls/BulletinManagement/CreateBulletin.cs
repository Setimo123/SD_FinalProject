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

        private void btnPublishBulletin_Click(object sender, EventArgs e)
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

            // Raise the event to notify subscribers that a bulletin was published
            BulletinPublished?.Invoke(this, bulletinData);
            
            // Show success message
            MessageBox.Show($"Bulletin '{bulletinData.Title}' has been published successfully!", 
                "Success", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
            
            this.Close();
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