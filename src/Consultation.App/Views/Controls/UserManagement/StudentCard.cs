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
    public partial class StudentCard : UserControl
    {
        public StudentCard()
        {
            InitializeComponent();
        }

        public void SetStudentInfo(string name, string id, string course, string email, string status)
        {
            lblStudName.Text = name;
            lblStudID.Text = id;
            //lblCourse.Text = course;
            lblStudEmail.Text = email;
            //lblStatus.Text = status;
        }
    }
}
