using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Views.Controls.UserManagement
{
    public partial class edituserprof : UserControl
    {
        public edituserprof()
        {
            InitializeComponent();
            
            // Wire up the exit button click event
            exitedit.Click += exitedit_Click;
            exitedit.Cursor = Cursors.Hand; // Make it clear it's clickable
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
    }
}
