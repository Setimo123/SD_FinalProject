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
    public partial class AdminCard : UserControl
    {
        public AdminCard()
        {
            
        }


        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            AdminAction = new Label();
            lblAdminEmail = new Label();
            lblAdminID = new Label();
            lblAdminName = new Label();
            ((ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Icons.person_b;
            pictureBox.Location = new Point(3, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(88, 60);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.TabIndex = 12;
            pictureBox.TabStop = false;
            // 
            // AdminAction
            // 
            AdminAction.AutoSize = true;
            AdminAction.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AdminAction.Location = new Point(766, 16);
            AdminAction.Name = "AdminAction";
            AdminAction.Size = new Size(37, 51);
            AdminAction.TabIndex = 16;
            AdminAction.Text = "...";
            // 
            // lblAdminEmail
            // 
            lblAdminEmail.AutoSize = true;
            lblAdminEmail.Font = new Font("Sans Serif Collection", 9F);
            lblAdminEmail.Location = new Point(485, 16);
            lblAdminEmail.Name = "lblAdminEmail";
            lblAdminEmail.Size = new Size(143, 51);
            lblAdminEmail.TabIndex = 15;
            lblAdminEmail.Text = "Umindanao Email";
            // 
            // lblAdminID
            // 
            lblAdminID.AutoSize = true;
            lblAdminID.Font = new Font("Sans Serif Collection", 9F);
            lblAdminID.Location = new Point(310, 16);
            lblAdminID.Name = "lblAdminID";
            lblAdminID.Size = new Size(42, 51);
            lblAdminID.TabIndex = 14;
            lblAdminID.Text = "I.D";
            // 
            // lblAdminName
            // 
            lblAdminName.AutoSize = true;
            lblAdminName.Font = new Font("Sans Serif Collection", 9F);
            lblAdminName.Location = new Point(93, 16);
            lblAdminName.Name = "lblAdminName";
            lblAdminName.Size = new Size(111, 51);
            lblAdminName.TabIndex = 13;
            lblAdminName.Text = "Admin Name";
            // 
            // AdminCard
            // 
            BackColor = SystemColors.ControlLightLight;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(AdminAction);
            Controls.Add(lblAdminEmail);
            Controls.Add(lblAdminID);
            Controls.Add(lblAdminName);
            Controls.Add(pictureBox);
            Name = "AdminCard";
            Size = new Size(944, 70);
            ((ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pictureBox;
        private Label AdminAction;
        private Label lblAdminEmail;
        private Label lblAdminID;
        private Label lblAdminName;
    }
}
