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
    public partial class StudentAction : UserControl
    {
        public StudentAction()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            picBoxStudview = new PictureBox();
            picBoxStudEditUser = new PictureBox();
            picBoxStudResetPass = new PictureBox();
            picBoxStudDelUser = new PictureBox();
            panel1 = new Panel();
            ((ISupportInitialize)picBoxStudview).BeginInit();
            ((ISupportInitialize)picBoxStudEditUser).BeginInit();
            ((ISupportInitialize)picBoxStudResetPass).BeginInit();
            ((ISupportInitialize)picBoxStudDelUser).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // picBoxStudview
            // 
            picBoxStudview.ErrorImage = null;
            picBoxStudview.Image = Properties.Icons.view_png;
            picBoxStudview.Location = new Point(0, 0);
            picBoxStudview.Name = "picBoxStudview";
            picBoxStudview.Size = new Size(190, 50);
            picBoxStudview.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxStudview.TabIndex = 0;
            picBoxStudview.TabStop = false;
            // 
            // picBoxStudEditUser
            // 
            picBoxStudEditUser.Image = Properties.Icons.Edit_User;
            picBoxStudEditUser.Location = new Point(3, 56);
            picBoxStudEditUser.Name = "picBoxStudEditUser";
            picBoxStudEditUser.Size = new Size(187, 50);
            picBoxStudEditUser.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxStudEditUser.TabIndex = 1;
            picBoxStudEditUser.TabStop = false;
            // 
            // picBoxStudResetPass
            // 
            picBoxStudResetPass.Image = Properties.Icons.reset_password;
            picBoxStudResetPass.Location = new Point(3, 112);
            picBoxStudResetPass.Name = "picBoxStudResetPass";
            picBoxStudResetPass.Size = new Size(187, 45);
            picBoxStudResetPass.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxStudResetPass.TabIndex = 2;
            picBoxStudResetPass.TabStop = false;
            // 
            // picBoxStudDelUser
            // 
            picBoxStudDelUser.Image = Properties.Icons.delete_user;
            picBoxStudDelUser.Location = new Point(3, 162);
            picBoxStudDelUser.Name = "picBoxStudDelUser";
            picBoxStudDelUser.Size = new Size(187, 45);
            picBoxStudDelUser.TabIndex = 3;
            picBoxStudDelUser.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(picBoxStudview);
            panel1.Controls.Add(picBoxStudDelUser);
            panel1.Controls.Add(picBoxStudEditUser);
            panel1.Controls.Add(picBoxStudResetPass);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(193, 210);
            panel1.TabIndex = 4;
            // 
            // StudentAction
            // 
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(panel1);
            Name = "StudentAction";
            Size = new Size(198, 215);
            ((ISupportInitialize)picBoxStudview).EndInit();
            ((ISupportInitialize)picBoxStudEditUser).EndInit();
            ((ISupportInitialize)picBoxStudResetPass).EndInit();
            ((ISupportInitialize)picBoxStudDelUser).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private PictureBox picBoxStudEditUser;
        private PictureBox picBoxStudResetPass;
        private PictureBox picBoxStudDelUser;
        private Panel panel1;
        private PictureBox picBoxStudview;
    }
}
