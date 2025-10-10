using Consultation.App.Views.Controls.UserManagement;
using Consultation.App.Views.IViews;
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
        public UserManagementView()
        {
            InitializeComponent();

            buttonStudents.Click += (s, e) => StudentManagementEvent?.Invoke(s, e);
            buttonFaculty.Click += (s, e) => FacultyManagementEvent?.Invoke(s, e);
            buttonAdmin.Click += (s, e) => AdminManagementEvent?.Invoke(s, e);

            InitializeComboBoxes();
        }

        public event EventHandler StudentManagementEvent;
        public event EventHandler FacultyManagementEvent;
        public event EventHandler AdminManagementEvent;

        public UserControl AsUserControl => this;

        // For adding user cards; change if needed
        public void AddUserCard(string name)
        {
            flPanelUserCard.Controls.Add(new UserCard(name, "547546", "genericEmail@hotmail.net"));
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

            // ComboBox 2: Programs
            string[] programs = { "BSCpE", "BSME", "BSCE", "BSECE", "BSCHE", "BSEE", "BSMatEng" };
            foreach (string program in programs)
                CBoxCourse.Items.Add(program);
            CBoxCourse.SelectedIndex = 0;

            // ComboBox 3: Year Levels
            string[] years = { "1st Year", "2nd Year", "3rd Year", "4th Year", "5th Year" };
            foreach (string year in years)
                CBoxYear.Items.Add(year);
            CBoxYear.SelectedIndex = 0;

            // Optional event handlers
            cboxSort.SelectedIndexChanged += cboxSort_SelectedIndexChanged;
            CBoxCourse.SelectedIndexChanged += CBoxCourse_SelectedIndexChanged;
            CBoxYear.SelectedIndexChanged += CBoxYear_SelectedIndexChanged;
        }

        private void cboxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Example placeholder
            // MessageBox.Show("Sort option selected: " + cboxSort.SelectedItem.ToString());
        }

        private void CBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Example placeholder
            // MessageBox.Show("Course selected: " + CBoxCourse.SelectedItem.ToString());
        }

        private void CBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Example placeholder
            // MessageBox.Show("Year level selected: " + CBoxYear.SelectedItem.ToString());
        }
    }
}
