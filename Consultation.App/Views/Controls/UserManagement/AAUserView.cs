using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Consultation.Domain.Enum;

namespace Consultation.App.Views.Controls.UserManagement
{
    public partial class UserView : UserControl
    {
        private string _currentUMID; // Store the UMID for edit functionality

        public UserView()
        {
            InitializeComponent();
            
            // Wire up the close button click event
            cLose.Click += cLose_Click;
            cLose.Cursor = Cursors.Hand; // Make it clear it's clickable
            
            // Wire up the edit profile button click event
            edprof.Click += edprof_Click;
            
            // Wire up the delete button click event
            Delbutton.Click += Delbutton_Click;
            Delbutton.Cursor = Cursors.Hand; // Make it clear it's clickable
        }

        /// <summary>
        /// Sets the user information to be displayed in the UserView
        /// </summary>
        /// <param name="name">Complete name of the user</param>
        /// <param name="umid">UMID of the user</param>
        /// <param name="email">Email address of the user</param>
        /// <param name="userType">User type (Student, Faculty, or Admin)</param>
        public void SetUserInformation(string name, string umid, string email, UserType userType)
        {
            // Store the UMID for later use
            _currentUMID = umid;

            // Set the name
            USname.Text = name;
            
            // Set the UMID
            gradientUID.Text = umid;
            
            // Set the email
            gradientEM.Text = email;
            
            // Set the user type/role
            gradientRLE.Text = GetUserTypeDisplay(userType);
        }

        /// <summary>
        /// Sets additional information like contact and department
        /// </summary>
        /// <param name="contact">Contact number</param>
        /// <param name="department">Department name</param>
        public void SetAdditionalInformation(string contact, string department)
        {
            gradientCTC.Text = contact;
            gradientDEPT.Text = department;
        }

        /// <summary>
        /// Converts UserType enum to display text
        /// </summary>
        private string GetUserTypeDisplay(UserType userType)
        {
            return userType switch
            {
                UserType.Student => "Student",
                UserType.Faculty => "Faculty",
                UserType.Admin => "Administrator",
                _ => "Unknown"
            };
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cLose_Click(object sender, EventArgs e)
        {
            // Close the parent form
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        private void edprof_Click(object sender, EventArgs e)
        {
            // Get the parent form (UserView form) before closing it
            Form parentForm = this.FindForm();
            
            // Close the UserView form first
            if (parentForm != null)
            {
                parentForm.Close();
            }

            // Create a form to host the edituserprof control
            Form editForm = new Form
            {
                Text = "Edit User Profile",
                Size = new Size(970, 650),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.White
            };

            // Create and configure the edituserprof control with the user's UMID
            edituserprof editUserProf = new edituserprof(_currentUMID);
            editUserProf.Dock = DockStyle.Fill;

            // Add the edituserprof to the form
            editForm.Controls.Add(editUserProf);

            // Show the form as a modal dialog
            editForm.ShowDialog();
        }

        private async void Delbutton_Click(object sender, EventArgs e)
        {
            // Confirm delete action
            var result = MessageBox.Show(
                $"Are you sure you want to permanently delete the user '{USname.Text}' (UMID: {_currentUMID})?\n\n" +
                "This action will delete:\n" +
                "- User account\n" +
                "- All related records (enrollments, consultations, etc.)\n\n" +
                "This action cannot be undone!",
                "Delete User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2); // Default to No for safety
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Delete through the UserService (database)
                    bool success = await Consultation.App.Services.UserService.Instance.DeleteUser(_currentUMID);
                    
                    if (success)
                    {
                        MessageBox.Show(
                            "User has been permanently deleted!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        
                        // Close the UserView form after successful deletion
                        Form parentForm = this.FindForm();
                        if (parentForm != null)
                        {
                            parentForm.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to delete the user. Please try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"An error occurred while deleting the user: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
