using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Consultation.App.Services;
using Consultation.Domain;
using Consultation.Domain.Enum;

namespace Consultation.App.Views.Controls.UserManagement
{
    public partial class edituserprof : UserControl
    {
        private string _originalUMID; // Store the original UMID to find the user
        private Users _currentUser;

        public edituserprof()
        {
            InitializeComponent();
            
            // Wire up event handlers
            exitedit.Click += exitedit_Click;
            exitedit.Cursor = Cursors.Hand;
            
            canxel.Click += canxel_Click;
            saveChanges.Click += saveChanges_Click;
            
            // Initialize dropdowns
            InitializeRoleComboBox();
            InitializeDepartmentComboBox();
            
            // Initialize input handling for TextBoxes
            InitializeTextBoxHandling();
        }

        /// <summary>
        /// Constructor that accepts user UMID to load data
        /// </summary>
        public edituserprof(string umid) : this()
        {
            _originalUMID = umid;
            LoadUserData(umid);
        }

        /// <summary>
        /// Initializes input handling, validation, and character limits for all TextBoxes
        /// </summary>
        private void InitializeTextBoxHandling()
        {
            // Full Name TextBox
            TBfullname.MaxLength = 100; // Limit to 100 characters
            TBfullname.PlaceholderText = "Enter full name";
            TBfullname.TextChanged += TBfullname_TextChanged;
            TBfullname.Leave += TBfullname_Leave;
            
            // Email TextBox
            TBemail.MaxLength = 100;
            TBemail.PlaceholderText = "example@umindanao.edu.ph";
            TBemail.TextChanged += TBemail_TextChanged;
            TBemail.Leave += TBemail_Leave;
            
            // User ID TextBox
            TBUID.MaxLength = 20;
            TBUID.PlaceholderText = "Enter User ID/UMID";
            TBUID.TextChanged += TBUID_TextChanged;
            TBUID.KeyPress += TBUID_KeyPress; // Only allow alphanumeric
            
            // Contact Number TextBox
            TBContact.MaxLength = 15;
            TBContact.PlaceholderText = "+63 XXX XXX XXXX";
            TBContact.KeyPress += TBContact_KeyPress; // Only allow numbers and specific characters
            TBContact.TextChanged += TBContact_TextChanged;
        }

        #region TextBox Event Handlers

        /// <summary>
        /// Handles Full Name TextBox text changes - validates name format
        /// </summary>
        private void TBfullname_TextChanged(object sender, EventArgs e)
        {
            // Remove leading spaces while typing
            if (TBfullname.Text.StartsWith(" "))
            {
                TBfullname.Text = TBfullname.Text.TrimStart();
                TBfullname.SelectionStart = TBfullname.Text.Length;
            }
            
            // Reset border color to default when user starts typing
            TBfullname.BorderColor = Color.FromArgb(213, 218, 223);
        }

        /// <summary>
        /// Validates Full Name when user leaves the field
        /// </summary>
        private void TBfullname_Leave(object sender, EventArgs e)
        {
            string fullName = TBfullname.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(fullName))
            {
                TBfullname.BorderColor = Color.Red;
                return;
            }
            
            // Validate that name contains only letters, spaces, and common name characters
            if (!Regex.IsMatch(fullName, @"^[a-zA-Z\s\.\-']+$"))
            {
                TBfullname.BorderColor = Color.Orange;
                MessageBox.Show(
                    "Full name should only contain letters, spaces, and common punctuation (. - ').",
                    "Invalid Name Format",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                TBfullname.BorderColor = Color.Green;
                // Auto-capitalize first letter of each word
                TBfullname.Text = CapitalizeWords(fullName);
            }
        }

        /// <summary>
        /// Handles Email TextBox text changes
        /// </summary>
        private void TBemail_TextChanged(object sender, EventArgs e)
        {
            // Remove spaces (emails don't have spaces)
            if (TBemail.Text.Contains(" "))
            {
                int cursorPosition = TBemail.SelectionStart;
                TBemail.Text = TBemail.Text.Replace(" ", "");
                TBemail.SelectionStart = Math.Max(0, cursorPosition - 1);
            }
            
            // Reset border color
            TBemail.BorderColor = Color.FromArgb(213, 218, 223);
        }

        /// <summary>
        /// Validates Email when user leaves the field
        /// </summary>
        private void TBemail_Leave(object sender, EventArgs e)
        {
            string email = TBemail.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(email))
            {
                TBemail.BorderColor = Color.Red;
                return;
            }
            
            // Validate email format
            if (!IsValidEmail(email))
            {
                TBemail.BorderColor = Color.Red;
                MessageBox.Show(
                    "Please enter a valid email address.\nExample: username@umindanao.edu.ph",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                TBemail.BorderColor = Color.Green;
                // Convert to lowercase for consistency
                TBemail.Text = email.ToLower();
            }
        }

        /// <summary>
        /// Handles User ID TextBox text changes
        /// </summary>
        private void TBUID_TextChanged(object sender, EventArgs e)
        {
            // Remove spaces
            if (TBUID.Text.Contains(" "))
            {
                int cursorPosition = TBUID.SelectionStart;
                TBUID.Text = TBUID.Text.Replace(" ", "");
                TBUID.SelectionStart = Math.Max(0, cursorPosition - 1);
            }
            
            // Reset border color
            TBUID.BorderColor = Color.FromArgb(213, 218, 223);
            
            // Validate minimum length
            if (TBUID.Text.Length > 0 && TBUID.Text.Length >= 4)
            {
                TBUID.BorderColor = Color.Green;
            }
            else if (TBUID.Text.Length > 0)
            {
                TBUID.BorderColor = Color.Orange;
            }
        }

        /// <summary>
        /// Restricts User ID to alphanumeric characters only
        /// </summary>
        private void TBUID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only alphanumeric characters and control keys (backspace, delete)
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Handles Contact Number TextBox text changes
        /// </summary>
        private void TBContact_TextChanged(object sender, EventArgs e)
        {
            // Reset border color
            TBContact.BorderColor = Color.FromArgb(213, 218, 223);
        }

        /// <summary>
        /// Restricts Contact Number to digits, spaces, +, -, and parentheses
        /// </summary>
        private void TBContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, +, -, spaces, parentheses, and control keys
            if (!char.IsDigit(e.KeyChar) && 
                !char.IsControl(e.KeyChar) && 
                e.KeyChar != '+' && 
                e.KeyChar != '-' && 
                e.KeyChar != ' ' && 
                e.KeyChar != '(' && 
                e.KeyChar != ')')
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        #endregion

        #region Validation Helper Methods

        /// <summary>
        /// Validates email format using regex
        /// </summary>
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Comprehensive email regex pattern
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Capitalizes the first letter of each word
        /// </summary>
        private string CapitalizeWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            var words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }
            return string.Join(" ", words);
        }

        /// <summary>
        /// Validates all input fields before saving
        /// </summary>
        private bool ValidateAllInputs()
        {
            bool isValid = true;
            StringBuilder errorMessage = new StringBuilder();

            // Validate Full Name
            string fullName = TBfullname.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                errorMessage.AppendLine("• Full name is required");
                TBfullname.BorderColor = Color.Red;
                isValid = false;
            }
            else if (fullName.Length < 2)
            {
                errorMessage.AppendLine("• Full name must be at least 2 characters");
                TBfullname.BorderColor = Color.Red;
                isValid = false;
            }
            else if (!Regex.IsMatch(fullName, @"^[a-zA-Z\s\.\-']+$"))
            {
                errorMessage.AppendLine("• Full name contains invalid characters");
                TBfullname.BorderColor = Color.Red;
                isValid = false;
            }

            // Validate Email
            string email = TBemail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                errorMessage.AppendLine("• Email address is required");
                TBemail.BorderColor = Color.Red;
                isValid = false;
            }
            else if (!IsValidEmail(email))
            {
                errorMessage.AppendLine("• Email address format is invalid");
                TBemail.BorderColor = Color.Red;
                isValid = false;
            }

            // Validate User ID
            string umid = TBUID.Text.Trim();
            if (string.IsNullOrWhiteSpace(umid))
            {
                errorMessage.AppendLine("• User ID is required");
                TBUID.BorderColor = Color.Red;
                isValid = false;
            }
            else if (umid.Length < 4)
            {
                errorMessage.AppendLine("• User ID must be at least 4 characters");
                TBUID.BorderColor = Color.Red;
                isValid = false;
            }
            else if (!Regex.IsMatch(umid, @"^[a-zA-Z0-9]+$"))
            {
                errorMessage.AppendLine("• User ID must be alphanumeric only");
                TBUID.BorderColor = Color.Red;
                isValid = false;
            }

            // Validate Role Selection
            if (CBrole.SelectedIndex == -1)
            {
                errorMessage.AppendLine("• Role/User Type must be selected");
                isValid = false;
            }

            // Show validation errors if any
            if (!isValid)
            {
                MessageBox.Show(
                    "Please fix the following errors:\n\n" + errorMessage.ToString(),
                    "Validation Errors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return isValid;
        }

        #endregion

        /// <summary>
        /// Initializes the Role/User Type dropdown
        /// </summary>
        private void InitializeRoleComboBox()
        {
            CBrole.Items.Clear();
            CBrole.Items.Add("Student");
            CBrole.Items.Add("Faculty");
            CBrole.Items.Add("Admin");
        }

        /// <summary>
        /// Initializes the Department dropdown
        /// </summary>
        private async void InitializeDepartmentComboBox()
        {
            try
            {
                var departments = await UserService.Instance.GetAllDepartments();
                CBdept.Items.Clear();
                
                foreach (var dept in departments)
                {
                    CBdept.Items.Add(new DepartmentItem { Id = dept.DepartmentID, Name = dept.DepartmentName });
                }
                
                // Set display member
                CBdept.DisplayMember = "Name";
                CBdept.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"InitializeDepartmentComboBox Error: {ex.Message}");
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads user data into the form fields
        /// </summary>
        private async void LoadUserData(string umid)
        {
            try
            {
                Console.WriteLine($"Loading user data for UMID: {umid}");
                
                _currentUser = await UserService.Instance.GetUserByUMID(umid);
                
                if (_currentUser == null)
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Console.WriteLine($"User loaded: {_currentUser.UserName}, Type: {_currentUser.UserType}");

                // Populate form fields with null-safe operations
                TBfullname.Text = SanitizeInput(_currentUser.UserName);
                TBemail.Text = SanitizeInput(_currentUser.Email);
                TBUID.Text = SanitizeInput(_currentUser.UMID);
                
                // Set border colors to green for loaded data
                TBfullname.BorderColor = Color.Green;
                TBemail.BorderColor = Color.Green;
                TBUID.BorderColor = Color.Green;
                
                // Set role
                switch (_currentUser.UserType)
                {
                    case UserType.Student:
                        CBrole.SelectedIndex = 0;
                        // Load student department
                        var (programId, deptName) = await UserService.Instance.GetStudentDepartmentInfo(umid);
                        Console.WriteLine($"Student info loaded - ProgramID: {programId}, Department: {deptName}");
                        if (programId.HasValue)
                        {
                            SelectDepartmentByProgramId(programId.Value);
                        }
                        break;
                    case UserType.Faculty:
                        CBrole.SelectedIndex = 1;
                        Console.WriteLine("Faculty role selected");
                        break;
                    case UserType.Admin:
                        CBrole.SelectedIndex = 2;
                        Console.WriteLine("Admin role selected");
                        break;
                }
                
                Console.WriteLine("User data loaded successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadUserData Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                MessageBox.Show($"Error loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sanitizes input to prevent null values and trim whitespace
        /// </summary>
        private string SanitizeInput(string input)
        {
            return string.IsNullOrWhiteSpace(input) ? "" : input.Trim();
        }

        /// <summary>
        /// Helper to select department in dropdown by program ID
        /// </summary>
        private void SelectDepartmentByProgramId(int programId)
        {
            // For simplicity, we're using department directly
            // You may need to map programId to departmentId based on your schema
            for (int i = 0; i < CBdept.Items.Count; i++)
            {
                var item = CBdept.Items[i] as DepartmentItem;
                if (item != null && item.Id == programId)
                {
                    CBdept.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// Handles the Save Changes button click
        /// </summary>
        private async void saveChanges_Click(object sender, EventArgs e)
        {
            // Validate all inputs first
            if (!ValidateAllInputs())
            {
                return;
            }

            try
            {
                // Disable button to prevent multiple submissions
                saveChanges.Enabled = false;
                saveChanges.Text = "Saving...";
                canxel.Enabled = false;
                
                // Get sanitized values
                string newFullName = SanitizeInput(TBfullname.Text);
                string newEmail = SanitizeInput(TBemail.Text).ToLower();
                string newUMID = SanitizeInput(TBUID.Text);
                
                Console.WriteLine($"Saving changes for user:");
                Console.WriteLine($"  Original UMID: {_originalUMID}");
                Console.WriteLine($"  New Full Name: {newFullName}");
                Console.WriteLine($"  New Email: {newEmail}");
                Console.WriteLine($"  New UMID: {newUMID}");
                
                // Determine user type from dropdown
                UserType newUserType = CBrole.SelectedIndex switch
                {
                    0 => UserType.Student,
                    1 => UserType.Faculty,
                    2 => UserType.Admin,
                    _ => UserType.Student
                };
                
                Console.WriteLine($"  New User Type: {newUserType}");

                // Get selected department/program ID
                int? newDepartmentId = null;
                if (CBdept.SelectedItem is DepartmentItem selectedDept)
                {
                    newDepartmentId = selectedDept.Id;
                    Console.WriteLine($"  New Department ID: {newDepartmentId}");
                }

                // Update user in database
                bool success = await UserService.Instance.UpdateUser(
                    _originalUMID,
                    newFullName,
                    newEmail,
                    newUMID,
                    newUserType,
                    newDepartmentId
                );

                if (success)
                {
                    Console.WriteLine("User updated successfully in database");
                    
                    MessageBox.Show(
                        "User profile has been updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    
                    // Close the form
                    Form parentForm = this.FindForm();
                    if (parentForm != null)
                    {
                        parentForm.Close();
                    }
                }
                else
                {
                    Console.WriteLine("Failed to update user in database");
                    
                    MessageBox.Show(
                        "Failed to update user profile. Please try again.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    
                    saveChanges.Enabled = true;
                    saveChanges.Text = "Save Changes";
                    canxel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"saveChanges_Click Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                
                MessageBox.Show(
                    $"An error occurred: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
                saveChanges.Enabled = true;
                saveChanges.Text = "Save Changes";
                canxel.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Cancel button click
        /// </summary>
        private void canxel_Click(object sender, EventArgs e)
        {
            // Close the parent form
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        private void exitedit_Click(object sender, EventArgs e)
        {
            // Close the parent form
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Empty event handler for designer compatibility
        }

        private void label10_Click(object sender, EventArgs e)
        {
            // Empty event handler for designer compatibility
        }

        /// <summary>
        /// Helper class for department dropdown items
        /// </summary>
        private class DepartmentItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
