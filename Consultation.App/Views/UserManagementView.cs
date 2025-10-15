using Consultation.App.Views.Controls.UserManagement;
using Consultation.App.Views.IViews;
using Consultation.App.Presenters;
using Student_Faculty;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms; // Make sure this is here for Guna2 controls

namespace Consultation.App.Views
{
    public partial class UserManagementView : UserControl, IUserManagementView
    {
        private UserManagementPresenter _presenter;

        public UserManagementView()
        {
            InitializeComponent();

            buttonStudents.Click += (s, e) => StudentManagementEvent?.Invoke(s, e);
            buttonFaculty.Click += (s, e) => FacultyManagementEvent?.Invoke(s, e);
            buttonAdmin.Click += (s, e) => AdminManagementEvent?.Invoke(s, e);

            InitializeComboBoxes();
            OptimizeFlowLayoutPanel();
            InitializeSearchBox();
        }

        public event EventHandler StudentManagementEvent;
        public event EventHandler FacultyManagementEvent;
        public event EventHandler AdminManagementEvent;

        public UserControl AsUserControl => this;

        /// <summary>
        /// Sets the presenter reference so the view can call search functionality
        /// </summary>
        public void SetPresenter(UserManagementPresenter presenter)
        {
            _presenter = presenter;
        }

        /// <summary>
        /// Initializes the search box with event handlers
        /// </summary>
        private void InitializeSearchBox()
        {
            // Subscribe to KeyDown event to search only when Enter is pressed
            USMsearchbar.KeyDown += TextBoxSearch_KeyDown;

            // Clear the default text when focused
            USMsearchbar.Enter += (s, e) =>
            {
                if (USMsearchbar.Text == "Search by name, ID number, or email")
                {
                    USMsearchbar.Text = "";
                    USMsearchbar.ForeColor = Color.Black;
                }
            };

            // Restore default text if empty when losing focus
            USMsearchbar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(USMsearchbar.Text))
                {
                    USMsearchbar.Text = "Search by name, ID number, or email";
                    USMsearchbar.ForeColor = Color.Gray;
                }
            };

            // Set initial placeholder style
            USMsearchbar.ForeColor = Color.Gray;
        }

        private async void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // Only search when Enter key is pressed
            if (e.KeyCode != Keys.Enter) return;

            if (_presenter == null) return;

            // Don't search if it's the placeholder text
            if (USMsearchbar.Text == "Search by name, ID number, or email")
            {
                return;
            }

            // Perform search
            await _presenter.SearchUsers(USMsearchbar.Text);

            // Prevent the 'ding' sound when Enter is pressed
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        /// <summary>
        /// Optimizes the FlowLayoutPanel for smooth rendering
        /// </summary>
        private void OptimizeFlowLayoutPanel()
        {
            // Enable double buffering to reduce flicker
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, flPanelUserCard, new object[] { true });
        }

        // For adding user cards; change if needed
        public void AddUserCard(string name, string id, string email)
        {
            var card = new UserCard(name, id, email);
            flPanelUserCard.Controls.Add(card);
        }

        /// <summary>
        /// Adds multiple user cards in a single batch operation for optimal performance
        /// </summary>
        public void AddUserCardsBatch(List<(string name, string id, string email)> users)
        {
            if (users == null || users.Count == 0)
                return;

            try
            {
                // Suspend layout during batch addition
                flPanelUserCard.SuspendLayout();

                // Pre-create all cards
                var cards = new UserControl[users.Count];
                for (int i = 0; i < users.Count; i++)
                {
                    var user = users[i];
                    cards[i] = new UserCard(user.name, user.id, user.email);
                }

                // Add all cards at once
                flPanelUserCard.Controls.AddRange(cards);
            }
            finally
            {
                // Resume layout and perform single refresh
                flPanelUserCard.ResumeLayout(true);
            }
        }

        public void ClearUserCards()
        {
            try
            {
                // Suspend layout to prevent multiple redraws
                flPanelUserCard.SuspendLayout();

                // Clear all controls efficiently
                flPanelUserCard.Controls.Clear();
            }
            finally
            {
                // Resume layout after clearing
                flPanelUserCard.ResumeLayout(true);
            }
        }

        public void UpdateTotalStudents(int count)
        {
            TotalStudents.Text = count.ToString();
        }

        public void UpdateTotalFaculty(int count)
        {
            TotalFacultyMem.Text = count.ToString();
        }

        public void UpdateTotalAdmin(int count)
        {
            TotalAdmin.Text = count.ToString();
        }

        public void Message(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InitializeComboBoxes()
        {
            // ComboBox 1: Sort Options
            cboxSort.Items.Add("Sort by: Ascending");
            cboxSort.Items.Add("Sort by: Descending");
            cboxSort.SelectedIndex = 0; // Default selection

            // ComboBox 2: Year Levels
            string[] years = { "1st Year", "2nd Year", "3rd Year", "4th Year", "5th Year" };
            foreach (string year in years)
                CBoxYear.Items.Add(year);
            CBoxYear.SelectedIndex = 0;

            // Optional event handlers
            cboxSort.SelectedIndexChanged += cboxSort_SelectedIndexChanged;
            CBoxYear.SelectedIndexChanged += CBoxYear_SelectedIndexChanged;
        }

        private void cboxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Example placeholder
            // MessageBox.Show("Sort option selected: " + cboxSort.SelectedItem.ToString());
        }

        private void CBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Example placeholder
            // MessageBox.Show("Year level selected: " + CBoxYear.SelectedItem.ToString());
        }

        private void flPanelUserCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
