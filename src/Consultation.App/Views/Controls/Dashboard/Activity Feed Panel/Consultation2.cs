using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Dashboard.Activity_Feed_Panel
{
    public partial class Consultation2 : UserControl
    {
        public Consultation2()
        {
            InitializeComponent();
         
         //   for (int i = 0; i < 10; i++)
         //   {
         //       flowLayoutPanel1.Controls.Add(new ConsultationCard());
         //   }
        }

        public int ConsultationId { get; set; }
        public string ConsultationTitle { get; set; }
        public string ConsultationBody { get; set; }
        public string ConsultationStatus { get; set; }
        public string ConsultationDepartment { get; set; }
        public DateTime ConsultationDateScheduled { get; set; }
    }
}
