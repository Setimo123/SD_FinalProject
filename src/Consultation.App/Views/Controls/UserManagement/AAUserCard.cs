using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.EntityFrameworkCore;

namespace Consultation.App.Views.Controls.UserManagement
{
    public partial class UserCard : UserControl
    {
        private string userName;
        private string userID;
        private string userEmail;

        public UserCard(string name, string id, string email)
        {
            InitializeComponent();
            
            userName = name;
            userID = id;
            userEmail = email;

            // Set labels directly without additional overhead
            labelName.Text = name;
            labelUserID.Text = id;
            labelUserEmail.Text = email;

            // Optimize rendering
            SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                     ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStripEx1.Show(button1, new Point(0, button1.Height));
        }

        private void contextMenuStripEx1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void viewTSMI_Click(object sender, EventArgs e)
        {
            // Create a form to host the UserView control
            Form viewForm = new Form
            {
                Text = "User Details",
                Size = new Size(970, 600),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.White
            };

            // Create and configure the UserView control
            UserView userView = new UserView();
            userView.Dock = DockStyle.Fill;

            // Load user information from database
            LoadUserDataToView(userView);

            // Add the UserView to the form
            viewForm.Controls.Add(userView);

            // Show the form as a modal dialog
            viewForm.ShowDialog();
        }

        /// <summary>
        /// Loads user data from the database and populates the UserView
        /// </summary>
        private async void LoadUserDataToView(UserView userView)
        {
            try
            {
                using (var context = new Consultation.Infrastructure.Data.AppDbContext())
                {
                    // Try to find the user by UMID in the Users table
                    var user = await context.Users.FirstOrDefaultAsync(u => u.UMID == userID);

                    if (user != null)
                    {
                        // Set basic user information
                        userView.SetUserInformation(userName, userID, userEmail, user.UserType);

                        // Load additional information based on user type
                        switch (user.UserType)
                        {
                            case Consultation.Domain.Enum.UserType.Student:
                                var student = await context.Students
                                    .Include(s => s.Program)
                                    .ThenInclude(p => p.Department)
                                    .FirstOrDefaultAsync(s => s.StudentUMID == userID);
                                if (student != null)
                                {
                                    string department = student.Program?.Department?.Description ?? "N/A";
                                    userView.SetAdditionalInformation("N/A", department);
                                }
                                break;

                            case Consultation.Domain.Enum.UserType.Faculty:
                                var faculty = await context.Faculty
                                    .Include(f => f.Program)
                                    .ThenInclude(p => p.Department)
                                    .FirstOrDefaultAsync(f => f.FacultyUMID == userID);
                                if (faculty != null)
                                {
                                    string department = faculty.Program?.Department?.Description ?? "N/A";
                                    userView.SetAdditionalInformation("N/A", department);
                                }
                                break;

                            case Consultation.Domain.Enum.UserType.Admin:
                                var admin = await context.Admin
                                    .FirstOrDefaultAsync(a => a.Users.UMID == userID);
                                if (admin != null)
                                {
                                    userView.SetAdditionalInformation("N/A", "Administration");
                                }
                                break;
                        }
                    }
                    else
                    {
                        // If user not found in database, use the basic info from the card
                        userView.SetUserInformation(userName, userID, userEmail, Consultation.Domain.Enum.UserType.Student);
                        userView.SetAdditionalInformation("N/A", "N/A");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Fallback to basic information
                userView.SetUserInformation(userName, userID, userEmail, Consultation.Domain.Enum.UserType.Student);
                userView.SetAdditionalInformation("N/A", "N/A");
            }
        }

        private void editTSMI_Click(object sender, EventArgs e)
        {
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
            edituserprof editUserProf = new edituserprof(userID);
            editUserProf.Dock = DockStyle.Fill;

            // Add the edituserprof to the form
            editForm.Controls.Add(editUserProf);

            // Show the form as a modal dialog
            editForm.ShowDialog();
        }

        private async void deleteTSMI_Click(object sender, EventArgs e)
        {
            // Confirm delete action
            var result = MessageBox.Show(
                $"Are you sure you want to permanently delete the user '{userName}' (UMID: {userID})?\n\n" +
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
                    bool success = await Services.UserService.Instance.DeleteUser(userID);
                    
                    if (success)
                    {
                        MessageBox.Show(
                            "User has been permanently deleted!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        
                        // Remove this card from the parent container
                        this.Parent?.Controls.Remove(this);
                        this.Dispose();
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
