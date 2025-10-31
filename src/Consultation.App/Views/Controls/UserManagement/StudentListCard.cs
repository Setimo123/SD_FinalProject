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
    public partial class StudentListCard : UserControl
    {
        public StudentListCard()
        {
            InitializeComponent();

            for (int i = 0; i < 10; ++i)
            {
                var student = new StudentCard();
                student.SetStudentInfo(
                    $"Student {i + 1}",
                    $"UM{i + 1000}",
                    "CPE-321/L",
                    $"student{i + 1}@umindanao.edu.ph",
                    "Active"
                );
                fLayPanStud.Controls.Add(student); 
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
