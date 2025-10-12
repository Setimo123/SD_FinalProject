using Consultation.App.Views.IViews;
using Guna.UI2.WinForms.Enums;
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

namespace Consultation.App.Views
{
    public partial class LogInView : Form, ILoginView
    {
        private Label resultlabel1; // Add this field to the LogInView class to fix CS0103
        private Label ErrorPassLabel;

        public LogInView()
        {
            InitializeComponent();

            // Initialize resultlabel1 if not already done by designer
            resultlabel1 = new Label
            {
                Name = "resultlabel1",
                AutoSize = true,
                Location = new Point(10, 10), // Adjust location as needed
                Text = ""
            };
            this.Controls.Add(resultlabel1);

            // Initialize ErrorPassLabel to fix CS0103
            ErrorPassLabel = new Label
            {
                Name = "ErrorPassLabel",
                AutoSize = true,
                Location = new Point(10, 35), // Adjust location as needed
                ForeColor = Color.Red,
                Text = ""
            };
            this.Controls.Add(ErrorPassLabel);

            EmailTextBox.TextChanged += SignInTextBox_TextChanged;
            PasswordTextBox.TextChanged += PasswordTextBoxV2_TextChanged;
            Login_button.Click += (s, e) => LogInEvent?.Invoke(s, e);
        }


        private void ShowPassButton_Click(object sender, EventArgs e)
        {
            PasswordVisible = !PasswordVisible;
            PasswordTextBox.UseSystemPasswordChar = !PasswordVisible;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void HideForm()
        {
            this.Hide();
        }
        //public string useremail => EmailTextBox.Text;

        //public string password => PasswordTextBox.Text;

        public string useremail => EmailTextBox.Text;

        public string password => PasswordTextBox.Text;

        public event EventHandler LogInEvent;


        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void SignInTextBox_TextChanged(object sender, EventArgs e)
        {
            resultlabel1.Text = "";
        }

        private void PasswordTextBoxV2_TextChanged(object sender, EventArgs e)
        {
            ErrorPassLabel.Text = "";
        }

        private bool PasswordVisible = false;
        private const string LePassword = "admin";

        private bool EmailIsValid(string email)

        {
            return Regex.IsMatch(email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dockingClientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        //private void SignInButton_Click(object sender, EventArgs e)
        //{
        //    LogInEvent?.Invoke(this, EventArgs.Empty);

        //}

    }
}
