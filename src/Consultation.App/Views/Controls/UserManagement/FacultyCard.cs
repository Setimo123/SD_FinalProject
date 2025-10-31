using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Views
{
    public partial class FacultyCard : UserControl
    {
        public FacultyCard()
        {
            InitializeComponent();
        }

        public void SetFacultyInfo(string name, string id, string email, string status)
        {
            //lblFacM.Text = name;
            //lblIDFM.Text = id;
            //lblEmailFM.Text = email;
            //lblStatusFM.Text = status;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
