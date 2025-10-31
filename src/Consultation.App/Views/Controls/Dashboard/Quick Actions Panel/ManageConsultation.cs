using Consultation.App.ConsultationManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Views.Controls.Dashboard.Quick_Actions_Panel
{
    public partial class ManageConsultation : UserControl
    {
        public event EventHandler NavigateToConsultation;

        public ManageConsultation()
        {
            InitializeComponent();
        }

        private void materialCard1_Click(object sender, EventArgs e)
        {
            // Trigger navigation to Consultation view
            NavigateToConsultation?.Invoke(this, EventArgs.Empty);
        }
    }
}
