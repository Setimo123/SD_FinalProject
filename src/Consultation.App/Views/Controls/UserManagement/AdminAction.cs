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
    public partial class AdminAction : UserControl
    {
        public AdminAction()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            picBoxAdminview = new PictureBox();
            picBoxAdminEditUser = new PictureBox();
            picBoxAdminResetPass = new PictureBox();
            picBoxAdminDelUser = new PictureBox();
            panel1 = new Panel();
            ((ISupportInitialize)picBoxAdminview).BeginInit();
            ((ISupportInitialize)picBoxAdminEditUser).BeginInit();
            ((ISupportInitialize)picBoxAdminResetPass).BeginInit();
            ((ISupportInitialize)picBoxAdminDelUser).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // picBoxAdminview
            // 
            picBoxAdminview.ErrorImage = null;
            picBoxAdminview.Image = Properties.Icons.view_png;
            picBoxAdminview.Location = new Point(-3, 5);
            picBoxAdminview.Name = "picBoxAdminview";
            picBoxAdminview.Size = new Size(190, 45);
            picBoxAdminview.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxAdminview.TabIndex = 0;
            picBoxAdminview.TabStop = false;
            // 
            // picBoxAdminEditUser
            // 
            picBoxAdminEditUser.Image = Properties.Icons.Edit_User;
            picBoxAdminEditUser.Location = new Point(0, 57);
            picBoxAdminEditUser.Name = "picBoxAdminEditUser";
            picBoxAdminEditUser.Size = new Size(187, 45);
            picBoxAdminEditUser.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxAdminEditUser.TabIndex = 1;
            picBoxAdminEditUser.TabStop = false;
            // 
            // picBoxAdminResetPass
            // 
            picBoxAdminResetPass.Image = Properties.Icons.reset_password;
            picBoxAdminResetPass.Location = new Point(0, 110);
            picBoxAdminResetPass.Name = "picBoxAdminResetPass";
            picBoxAdminResetPass.Size = new Size(187, 45);
            picBoxAdminResetPass.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxAdminResetPass.TabIndex = 2;
            picBoxAdminResetPass.TabStop = false;
            // 
            // picBoxAdminDelUser
            // 
            picBoxAdminDelUser.Image = Properties.Icons.delete_user;
            picBoxAdminDelUser.Location = new Point(0, 163);
            picBoxAdminDelUser.Name = "picBoxAdminDelUser";
            picBoxAdminDelUser.Size = new Size(187, 50);
            picBoxAdminDelUser.TabIndex = 3;
            picBoxAdminDelUser.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(picBoxAdminview);
            panel1.Controls.Add(picBoxAdminDelUser);
            panel1.Controls.Add(picBoxAdminEditUser);
            panel1.Controls.Add(picBoxAdminResetPass);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(190, 216);
            panel1.TabIndex = 4;
            // 
            // AdminAction
            // 
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(panel1);
            Name = "AdminAction";
            Size = new Size(194, 222);
            ((ISupportInitialize)picBoxAdminview).EndInit();
            ((ISupportInitialize)picBoxAdminEditUser).EndInit();
            ((ISupportInitialize)picBoxAdminResetPass).EndInit();
            ((ISupportInitialize)picBoxAdminDelUser).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private PictureBox picBoxAdminEditUser;
        private PictureBox picBoxAdminResetPass;
        private PictureBox picBoxAdminDelUser;
        private Panel panel1;
        private PictureBox picBoxAdminview;

        private void picBoxAdminview_Click(object sender, EventArgs e)
        {

        }
    }
}
