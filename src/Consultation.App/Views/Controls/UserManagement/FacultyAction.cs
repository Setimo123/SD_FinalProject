using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Views.Controls.UserManagement
{
    public partial class FacultyAction : UserControl
    {
        public FacultyAction()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            picBoxFacview = new PictureBox();
            picBoxFacEditUser = new PictureBox();
            picBoxFacResetPass = new PictureBox();
            picBoxFacDelUser = new PictureBox();
            panel1 = new Panel();
            ((ISupportInitialize)picBoxFacview).BeginInit();
            ((ISupportInitialize)picBoxFacEditUser).BeginInit();
            ((ISupportInitialize)picBoxFacResetPass).BeginInit();
            ((ISupportInitialize)picBoxFacDelUser).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // picBoxFacview
            // 
            picBoxFacview.ErrorImage = null;
            picBoxFacview.Image = Properties.Icons.view_png;
            picBoxFacview.Location = new Point(0, 3);
            picBoxFacview.Name = "picBoxFacview";
            picBoxFacview.Size = new Size(190, 50);
            picBoxFacview.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxFacview.TabIndex = 0;
            picBoxFacview.TabStop = false;
            // 
            // picBoxFacEditUser
            // 
            picBoxFacEditUser.Image = Properties.Icons.Edit_User;
            picBoxFacEditUser.Location = new Point(3, 56);
            picBoxFacEditUser.Name = "picBoxFacEditUser";
            picBoxFacEditUser.Size = new Size(187, 50);
            picBoxFacEditUser.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxFacEditUser.TabIndex = 1;
            picBoxFacEditUser.TabStop = false;
            // 
            // picBoxFacResetPass
            // 
            picBoxFacResetPass.Image = Properties.Icons.reset_password;
            picBoxFacResetPass.Location = new Point(3, 112);
            picBoxFacResetPass.Name = "picBoxFacResetPass";
            picBoxFacResetPass.Size = new Size(187, 45);
            picBoxFacResetPass.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxFacResetPass.TabIndex = 2;
            picBoxFacResetPass.TabStop = false;
            // 
            // picBoxFacDelUser
            // 
            picBoxFacDelUser.Image = Properties.Icons.delete_user;
            picBoxFacDelUser.Location = new Point(3, 163);
            picBoxFacDelUser.Name = "picBoxFacDelUser";
            picBoxFacDelUser.Size = new Size(187, 45);
            picBoxFacDelUser.TabIndex = 3;
            picBoxFacDelUser.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(picBoxFacview);
            panel1.Controls.Add(picBoxFacDelUser);
            panel1.Controls.Add(picBoxFacEditUser);
            panel1.Controls.Add(picBoxFacResetPass);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(194, 216);
            panel1.TabIndex = 4;
            // 
            // FacultyAction
            // 
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(panel1);
            Name = "FacultyAction";
            Size = new Size(198, 214);
            ((ISupportInitialize)picBoxFacview).EndInit();
            ((ISupportInitialize)picBoxFacEditUser).EndInit();
            ((ISupportInitialize)picBoxFacResetPass).EndInit();
            ((ISupportInitialize)picBoxFacDelUser).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private PictureBox picBoxFacEditUser;
        private PictureBox picBoxFacResetPass;
        private PictureBox picBoxFacDelUser;
        private Panel panel1;
        private PictureBox picBoxFacview;

        private void picBoxFacview_Click(object sender, EventArgs e)
        {

        }
    }
}
