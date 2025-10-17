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
    public partial class AAaddUser : UserControl
    {
        public AAaddUser()
        {
            InitializeComponent();
            
            // Wire up event handlers
            ADDexit.Click += ADDexit_Click;
            ADDexit.Cursor = Cursors.Hand;
            
            ADDchanges.Click += ADDchanges_Click;
            ADDcancel.Click += ADDcancel_Click;
            
            // Initialize dropdowns
            InitializeRoleComboBox();
            InitializeDepartmentComboBox();
            
            // Initialize input handling for TextBoxes
            InitializeTextBoxHandling();
            
            // Prevent form from being dragged by disabling mouse move on all controls
            PreventFormDragging(this);
        }

        /// <summary>
        /// Initializes input handling, validation, and character limits for all TextBoxes
        /// </summary>
        private void InitializeTextBoxHandling()
        {
            // Full Name TextBox
            ADDfn.MaxLength = 100;
            ADDfn.PlaceholderText = "Enter full name";
            ADDfn.TextChanged += ADDfn_TextChanged;
            ADDfn.Leave += ADDfn_Leave;

            // Email TextBox
            ADDea.MaxLength = 100;
            ADDea.PlaceholderText = "example@umindanao.edu.ph";
            ADDea.TextChanged += ADDea_TextChanged;
            ADDea.Leave += ADDea_Leave;

            // User ID TextBox
            ADDuid.MaxLength = 20;
            ADDuid.PlaceholderText = "Enter User ID/UMID";
            ADDuid.TextChanged += ADDuid_TextChanged;
            ADDuid.Leave += ADDuid_Leave;
            ADDuid.KeyPress += ADDuid_KeyPress;

            // Password TextBox
            ADDps.MaxLength = 50;
            ADDps.PlaceholderText = "Enter password (min 8 characters)";
            ADDps.UseSystemPasswordChar = true; // Hide password with dots
            ADDps.TextChanged += ADDps_TextChanged;
            ADDps.Leave += ADDps_Leave;

            // Show Password Checkbox
            ADDsp.CheckedChanged += ADDsp_CheckedChanged;
        }

        #region TextBox Event Handlers

        private void ADDfn_TextChanged(object sender, EventArgs e)
        {
            if (ADDfn.Text.StartsWith(" "))
            {
                ADDfn.Text = ADDfn.Text.TrimStart();
                ADDfn.SelectionStart = ADDfn.Text.Length;
            }
            ADDfn.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void ADDfn_Leave(object sender, EventArgs e)
        {
            string fullName = ADDfn.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                ADDfn.BorderColor = Color.Red;
                return;
            }

            if (!Regex.IsMatch(fullName, @"^[a-zA-Z\s\.\-']+$"))
            {
                ADDfn.BorderColor = Color.Orange;
                MessageBox.Show(
                    "Full name should only contain letters, spaces, and common punctuation (. - ').",
                    "Invalid Name Format",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                ADDfn.BorderColor = Color.Green;
                ADDfn.Text = CapitalizeWords(fullName);
            }
        }

        private void ADDea_TextChanged(object sender, EventArgs e)
        {
            if (ADDea.Text.Contains(" "))
            {
                int cursorPosition = ADDea.SelectionStart;
                ADDea.Text = ADDea.Text.Replace(" ", "");
                ADDea.SelectionStart = Math.Max(0, cursorPosition - 1);
            }
            ADDea.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private async void ADDea_Leave(object sender, EventArgs e)
        {
            string email = ADDea.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                ADDea.BorderColor = Color.Red;
                return;
            }

            if (!IsValidEmail(email))
            {
                ADDea.BorderColor = Color.Red;
                MessageBox.Show(
                    "Please enter a valid email address.\nExample: username@umindanao.edu.ph",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check if email is already in use
            bool isAvailable = await UserService.Instance.IsEmailAvailable(email);
            if (!isAvailable)
            {
                ADDea.BorderColor = Color.Red;
                MessageBox.Show(
                    "This email address is already registered in the system.",
                    "Email Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                ADDea.BorderColor = Color.Green;
                ADDea.Text = email.ToLower();
            }
        }

        private void ADDuid_TextChanged(object sender, EventArgs e)
        {
            if (ADDuid.Text.Contains(" "))
            {
                int cursorPosition = ADDuid.SelectionStart;
                ADDuid.Text = ADDuid.Text.Replace(" ", "");
                ADDuid.SelectionStart = Math.Max(0, cursorPosition - 1);
            }

            ADDuid.BorderColor = Color.FromArgb(213, 218, 223);

            if (ADDuid.Text.Length > 0 && ADDuid.Text.Length >= 4)
            {
                ADDuid.BorderColor = Color.Green;
            }
            else if (ADDuid.Text.Length > 0)
            {
                ADDuid.BorderColor = Color.Orange;
            }
        }

        private async void ADDuid_Leave(object sender, EventArgs e)
        {
            string umid = ADDuid.Text.Trim();
            if (string.IsNullOrWhiteSpace(umid))
            {
                ADDuid.BorderColor = Color.Red;
                return;
            }

            if (umid.Length < 4)
            {
                ADDuid.BorderColor = Color.Orange;
                MessageBox.Show(
                    "User ID must be at least 4 characters long.",
                    "Invalid User ID",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check if UMID is already in use
            bool isAvailable = await UserService.Instance.IsUMIDAvailable(umid);
            if (!isAvailable)
            {
                ADDuid.BorderColor = Color.Red;
                MessageBox.Show(
                    "This User ID (UMID) is already registered in the system.",
                    "UMID Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                ADDuid.BorderColor = Color.Green;
            }
        }

        private void ADDuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void ADDcn_TextChanged(object sender, EventArgs e)
        {
            ADDps.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void ADDps_TextChanged(object sender, EventArgs e)
        {
            ADDps.BorderColor = Color.FromArgb(213, 218, 223);
            
            // Visual feedback for password strength
            string password = ADDps.Text;
            if (password.Length >= 8)
            {
                ADDps.BorderColor = Color.Green;
            }
            else if (password.Length > 0)
            {
                ADDps.BorderColor = Color.Orange;
            }
        }

        private void ADDps_Leave(object sender, EventArgs e)
        {
            string password = ADDps.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(password))
            {
                ADDps.BorderColor = Color.Red;
                return;
            }

            if (password.Length < 8)
            {
                ADDps.BorderColor = Color.Red;
                MessageBox.Show(
                    "Password must be at least 8 characters long.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Optional: Check for password complexity
            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            
            if (!hasUpper || !hasLower || !hasDigit)
            {
                ADDps.BorderColor = Color.Orange;
                MessageBox.Show(
                    "For better security, password should contain:\n" +
                    "• At least one uppercase letter\n" +
                    "• At least one lowercase letter\n" +
                    "• At least one number",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                ADDps.BorderColor = Color.Green;
            }
        }

        private void ADDsp_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on checkbox state
            if (ADDsp.Checked)
            {
                // Show password
                ADDps.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password
                ADDps.UseSystemPasswordChar = true;
            }
        }

        private void ADDcn_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern);
            }
            catch
            {
                return false;
            }
        }

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

        private bool ValidateAllInputs()
        {
            bool isValid = true;
            StringBuilder errorMessage = new StringBuilder();

            // Validate Full Name
            string fullName = ADDfn.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                errorMessage.AppendLine("• Full name is required");
                ADDfn.BorderColor = Color.Red;
                isValid = false;
            }
            else if (fullName.Length < 2)
            {
                errorMessage.AppendLine("• Full name must be at least 2 characters");
                ADDfn.BorderColor = Color.Red;
                isValid = false;
            }
            else if (!Regex.IsMatch(fullName, @"^[a-zA-Z\s\.\-']+$"))
            {
                errorMessage.AppendLine("• Full name contains invalid characters");
                ADDfn.BorderColor = Color.Red;
                isValid = false;
            }

            // Validate Email
            string email = ADDea.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                errorMessage.AppendLine("• Email address is required");
                ADDea.BorderColor = Color.Red;
                isValid = false;
            }
            else if (!IsValidEmail(email))
            {
                errorMessage.AppendLine("• Email address format is invalid");
                ADDea.BorderColor = Color.Red;
                isValid = false;
            }

            // Validate User ID
            string umid = ADDuid.Text.Trim();
            if (string.IsNullOrWhiteSpace(umid))
            {
                errorMessage.AppendLine("• User ID is required");
                ADDuid.BorderColor = Color.Red;
                isValid = false;
            }
            else if (umid.Length < 4)
            {
                errorMessage.AppendLine("• User ID must be at least 4 characters");
                ADDuid.BorderColor = Color.Red;
                isValid = false;
            }
            else if (!Regex.IsMatch(umid, @"^[a-zA-Z0-9]+$"))
            {
                errorMessage.AppendLine("• User ID must be alphanumeric only");
                ADDuid.BorderColor = Color.Red;
                isValid = false;
            }

            // Validate Role Selection
            if (ADDrole.SelectedIndex == -1)
            {
                errorMessage.AppendLine("• Role/User Type must be selected");
                isValid = false;
            }

            // Validate Department ONLY for Students
            if (ADDrole.SelectedIndex == 0) // Only for Student
            {
                if (ADDdept.SelectedIndex == -1)
                {
                    errorMessage.AppendLine("• Department/Program is required for students");
                    isValid = false;
                }
            }

            // Validate Password
            string password = ADDps.Text.Trim();
            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage.AppendLine("• Password is required");
                ADDps.BorderColor = Color.Red;
                isValid = false;
            }
            else if (password.Length < 8)
            {
                errorMessage.AppendLine("• Password must be at least 8 characters");
                ADDps.BorderColor = Color.Red;
                isValid = false;
            }

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

        #region Dropdown Initialization

        private void InitializeRoleComboBox()
        {
            ADDrole.Items.Clear();
            ADDrole.Items.Add("Student");
            ADDrole.Items.Add("Faculty");
            ADDrole.Items.Add("Admin");
            
            // Wire up the selection changed event
            ADDrole.SelectedIndexChanged += ADDrole_SelectedIndexChanged;
        }

        private void ADDrole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable/disable department dropdown based on role
            // Department is only required for Students
            if (ADDrole.SelectedIndex == 0) // Student
            {
                ADDdept.Enabled = true;
                ADDdept.BackColor = Color.White;
            }
            else // Faculty or Admin
            {
                ADDdept.Enabled = false;
                ADDdept.SelectedIndex = -1;
                ADDdept.BackColor = Color.LightGray;
            }
        }

        private async void InitializeDepartmentComboBox()
        {
            try
            {
                // Load programs instead of departments for better granularity
                var departments = await UserService.Instance.GetAllDepartments();
                ADDdept.Items.Clear();

                // Get all programs for all departments
                foreach (var dept in departments)
                {
                    var programs = await UserService.Instance.GetProgramsByDepartment(dept.DepartmentID);
                    foreach (var prog in programs)
                    {
                        ADDdept.Items.Add(new DepartmentItem 
                        { 
                            Id = prog.ProgramID, 
                            Name = $"{prog.ProgramName} - {dept.DepartmentName}" 
                        });
                    }
                }

                ADDdept.DisplayMember = "Name";
                ADDdept.ValueMember = "Id";
                
                // Initially disable until role is selected
                ADDdept.Enabled = false;
                ADDdept.BackColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"InitializeDepartmentComboBox Error: {ex.Message}");
                MessageBox.Show($"Error loading programs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Button Click Handlers

        private async void ADDchanges_Click(object sender, EventArgs e)
        {
            // Validate all inputs first
            if (!ValidateAllInputs())
            {
                return;
            }

            try
            {
                // Disable buttons to prevent multiple submissions
                ADDchanges.Enabled = false;
                ADDchanges.Text = "Adding...";
                ADDcancel.Enabled = false;

                // Get sanitized values
                string fullName = ADDfn.Text.Trim();
                string email = ADDea.Text.Trim().ToLower();
                string umid = ADDuid.Text.Trim();
                string password = ADDps.Text.Trim(); // Get password from input

                Console.WriteLine($"Adding new user:");
                Console.WriteLine($"  Full Name: {fullName}");
                Console.WriteLine($"  Email: {email}");
                Console.WriteLine($"  UMID: {umid}");
                Console.WriteLine($"  Password: [HIDDEN FOR SECURITY]");

                // Determine user type from dropdown
                UserType userType = ADDrole.SelectedIndex switch
                {
                    0 => UserType.Student,
                    1 => UserType.Faculty,
                    2 => UserType.Admin,
                    _ => UserType.Student
                };

                Console.WriteLine($"  User Type: {userType}");

                // Get selected department/program ID
                int? departmentId = null;
                if (ADDdept.SelectedItem is DepartmentItem selectedDept)
                {
                    departmentId = selectedDept.Id;
                    Console.WriteLine($"  Department ID: {departmentId}");
                }

                // Create user in database
                bool success = await UserService.Instance.CreateUser(
                    fullName,
                    email,
                    umid,
                    password,      // Pass the user-entered password
                    userType,
                    departmentId
                );

                if (success)
                {
                    Console.WriteLine("User created successfully in database");

                    MessageBox.Show(
                        $"User {fullName} has been successfully added to the system!\n\n" +
                        $"The user can now login with their credentials.",
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
                    Console.WriteLine("Failed to create user in database");

                    ADDchanges.Enabled = true;
                    ADDchanges.Text = "Add User";
                    ADDcancel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ADDchanges_Click Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                MessageBox.Show(
                    $"An error occurred while adding the user: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                ADDchanges.Enabled = true;
                ADDchanges.Text = "Add User";
                ADDcancel.Enabled = true;
            }
        }

        private void ADDcancel_Click(object sender, EventArgs e)
        {
            // Ask for confirmation
            var result = MessageBox.Show(
                "Are you sure you want to cancel? All entered information will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close the parent form
                Form parentForm = this.FindForm();
                if (parentForm != null)
                {
                    parentForm.Close();
                }
            }
        }

        #endregion

        #region Form Dragging Prevention

        /// <summary>
        /// Recursively prevent all controls from being used to drag the form
        /// </summary>
        private void PreventFormDragging(Control control)
        {
            control.MouseDown += Control_MouseDown;
            control.MouseMove += Control_MouseMove;
            control.MouseUp += Control_MouseUp;

            foreach (Control childControl in control.Controls)
            {
                PreventFormDragging(childControl);
            }
        }

        private bool _isDragging = false;
        private Point _dragStartPoint;

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        #endregion

        #region Empty Event Handlers (for Designer compatibility)

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ADDexit_Click(object sender, EventArgs e)
        {
            // Close the parent form
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        #endregion

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
