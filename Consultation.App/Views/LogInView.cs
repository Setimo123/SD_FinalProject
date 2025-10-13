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
        private Label resultlabel1;
        private Label ErrorPassLabel;

        public LogInView()
        {
            InitializeComponent();

            resultlabel1 = new Label
            {
                Name = "resultlabel1",
                AutoSize = true,
                Location = new Point(10, 10),
                Text = ""
            };
            this.Controls.Add(resultlabel1);

            ErrorPassLabel = new Label
            {
                Name = "ErrorPassLabel",
                AutoSize = true,
                Location = new Point(10, 35),
                ForeColor = Color.Red,
                Text = ""
            };
            this.Controls.Add(ErrorPassLabel);

            Emtextbox.TextChanged += SignInTextBox_TextChanged;
            PassTextBox.TextChanged += PasswordTextBoxV2_TextChanged;
            Login_button.Click += (s, e) => LogInEvent?.Invoke(s, e);

            // Initialize password char and subscribe to events
            PassTextBox.UseSystemPasswordChar = true;
            showpass.CheckedChanged += showpass_CheckedChanged;
        }

        // Removed ShowPassButton_Click and all references to ShowPassButton

        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            PassTextBox.UseSystemPasswordChar = !showpass.Checked;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void HideForm()
        {
            this.Hide();
        }

        public void ShowForm()
        {
            this.Show();
        }

        public string useremail => Emtextbox.Text;

        public string password => PassTextBox.Text;

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

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
