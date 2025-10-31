using Consultation.App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Faculty
{
    public partial class FacultyListCard : UserControl
    {
        public FacultyListCard()
        {
            InitializeComponent();
            for (int i = 0; i < 10; ++i) // example
            {
                var faculty = new FacultyCard();
                faculty.SetFacultyInfo(
                    $"Faculty Member {i + 1}",      // name
                    $"UM{i + 1000}",                // id
                    $"FacultyMember{i + 1}@umindanao.edu.ph",  // email
                    "Active"                       // status
                );
                fLayPanFac.Controls.Add(faculty);
            }
        }
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
