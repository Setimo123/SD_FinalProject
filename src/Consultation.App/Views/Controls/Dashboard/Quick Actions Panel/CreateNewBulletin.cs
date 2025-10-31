using Consultation.App.Views.Controls.BulletinManagement;
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
    public partial class CreateNewBulletin : UserControl
    {
        // Event to propagate bulletin published event to parent
        public event EventHandler<BulletinPublishedEventArgs> BulletinPublished;

        public CreateNewBulletin()
        {
            InitializeComponent();
        }

        private void materialCard1_Click(object sender, EventArgs e)
        {
            CreateBulletin bulletinForm = new CreateBulletin();
            
            // Subscribe to the BulletinPublished event
            bulletinForm.BulletinPublished += (s, args) =>
            {
                // Propagate the event to the parent (MainDashboardUserControl)
                BulletinPublished?.Invoke(s, args);
            };
            
            bulletinForm.ShowDialog();
        }
    }
}
