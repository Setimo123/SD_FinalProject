using Consultation.App.Views.IViews;
using Consultation.App.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Consultation.App.Views
{
    public partial class MainView : Form, IMainView
    {
        private readonly Button[] _navButtons;

        public MainView()
        {
            InitializeComponent();

            profilePanel.BackColor = Color.Transparent;

            buttonDashboard.Click += (s, e) => DashboardEvent?.Invoke(s, e);
            buttonConsultation.Click += (s, e) => ConsultationEvent?.Invoke(s, e);
            buttonBulletin.Click += (s, e) => BulletinEvent?.Invoke(s, e);
            buttonSFManagement.Click += (s, e) => SFManagementEvent?.Invoke(s, e);
            buttonNotification.Click += (s, e) => NotificationEvent?.Invoke(s, e);
            this.FormClosed += MainView_FormClosed;

            _navButtons = new[]
            {
                buttonDashboard,
                buttonConsultation,
                buttonBulletin,
                buttonSFManagement,
            };

            foreach (var btn in _navButtons)
            {
                btn.MouseEnter += NavButton_MouseEnter;
                btn.MouseLeave += NavButton_MouseLeave;
            }
        }

        public Panel MainPanel => panelContainer;

        public Button CurrentActiveButton { get; set; }

        public event EventHandler DashboardEvent;
        public event EventHandler ConsultationEvent;
        public event EventHandler BulletinEvent;
        public event EventHandler SFManagementEvent;
        public event EventHandler PreferenceEvent;
        public event EventHandler NotificationEvent;

        // Add method to set user information
        public void SetUserInfo(string userName, string userRole)
        {
            if (username != null)
            {
                username.Text = userName;
            }

            if (userole != null)
            {
                userole.Text = userRole;
            }
        }

        public void HighlightButton(Button button)
        {
            if (button == null) return;
            button.BackColor = Color.White;
            button.ForeColor = Color.Black;
            button.ImageIndex = 1; // Optional: highlighted icon
        }

        public void ResetButton(Button button)
        {
            if (button == null) return;
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.White;
            button.ImageIndex = 0; // Optional: normal icon
        }

        private void NavButton_MouseEnter(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null && btn != CurrentActiveButton)
            {
                btn.BackColor = Color.LightGray;
                btn.ImageIndex = 1;
                btn.ForeColor = Color.Black;
            }
        }

        private void NavButton_MouseLeave(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null && btn != CurrentActiveButton)
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.White;
                btn.ImageIndex = 0;
            }
        }
        public void Header(string header)
        {
            labelForm.Text = header;
        }

        public void SetMessage(string message)
        {
            MessageBox.Show(message);
        }
        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void ShowForm()
        {
            Show();
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void labelProfileName_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Confirm sign out action
            var result = CustomMessageBox.Show(
                "Are you sure you want to sign out?\n\n" +
                "You will be returned to the login screen.",
                "Confirm Sign Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2); // Default to No for safety
                
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonNotification_Click(object sender, EventArgs e)
        {

        }

        private void labelProfileRole_Click(object sender, EventArgs e)
        {

        }

        private void sidePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void profilePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {

        }

        private void buttonSFManagement_Click(object sender, EventArgs e)
        {

        }
    }
}
