namespace Consultation.App.Views.Controls.UserManagement
{
    partial class ResPasAdmin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            BacktoFaculty = new Label();
            label10 = new Label();
            panel2 = new Panel();
            AdminConfirmPass = new TextBox();
            AdminNewPass = new TextBox();
            btnAdminIDCopyr = new Button();
            AdminNamer = new Label();
            btnAdminResPas = new Button();
            AdminPositionr = new Label();
            btnRCancelAdmin = new Button();
            label7 = new Label();
            label5 = new Label();
            tBAdminEmailAdShow = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tBAdminIDShow = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Crimson;
            panel1.Controls.Add(BacktoFaculty);
            panel1.Controls.Add(label10);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(639, 133);
            panel1.TabIndex = 4;
            // 
            // BacktoFaculty
            // 
            BacktoFaculty.AutoSize = true;
            BacktoFaculty.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BacktoFaculty.ForeColor = SystemColors.ControlLightLight;
            BacktoFaculty.Location = new Point(8, 0);
            BacktoFaculty.Name = "BacktoFaculty";
            BacktoFaculty.Size = new Size(151, 51);
            BacktoFaculty.TabIndex = 1;
            BacktoFaculty.Text = "<- Back to Admin";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Sans Serif Collection", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(8, 29);
            label10.Name = "label10";
            label10.Size = new Size(302, 112);
            label10.TabIndex = 0;
            label10.Text = "Reset Password";
            // 
            // panel2
            // 
            panel2.Controls.Add(AdminConfirmPass);
            panel2.Controls.Add(AdminNewPass);
            panel2.Controls.Add(btnAdminIDCopyr);
            panel2.Controls.Add(AdminNamer);
            panel2.Controls.Add(btnAdminResPas);
            panel2.Controls.Add(AdminPositionr);
            panel2.Controls.Add(btnRCancelAdmin);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(tBAdminEmailAdShow);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(tBAdminIDShow);
            panel2.Location = new Point(5, 142);
            panel2.Name = "panel2";
            panel2.Size = new Size(637, 400);
            panel2.TabIndex = 25;
            panel2.Paint += panel2_Paint;
            // 
            // AdminConfirmPass
            // 
            AdminConfirmPass.Location = new Point(17, 340);
            AdminConfirmPass.Name = "AdminConfirmPass";
            AdminConfirmPass.Size = new Size(199, 27);
            AdminConfirmPass.TabIndex = 25;
            AdminConfirmPass.Text = "Input text";
            // 
            // AdminNewPass
            // 
            AdminNewPass.Location = new Point(17, 256);
            AdminNewPass.Name = "AdminNewPass";
            AdminNewPass.Size = new Size(199, 27);
            AdminNewPass.TabIndex = 24;
            AdminNewPass.Text = "Input text";
            // 
            // btnAdminIDCopyr
            // 
            btnAdminIDCopyr.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdminIDCopyr.ForeColor = Color.Red;
            btnAdminIDCopyr.Location = new Point(222, 160);
            btnAdminIDCopyr.Name = "btnAdminIDCopyr";
            btnAdminIDCopyr.Size = new Size(64, 28);
            btnAdminIDCopyr.TabIndex = 23;
            btnAdminIDCopyr.Text = "Copy";
            btnAdminIDCopyr.UseVisualStyleBackColor = true;
            // 
            // AdminNamer
            // 
            AdminNamer.AutoSize = true;
            AdminNamer.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AdminNamer.Location = new Point(138, 5);
            AdminNamer.Name = "AdminNamer";
            AdminNamer.Size = new Size(67, 51);
            AdminNamer.TabIndex = 3;
            AdminNamer.Text = "Name";
            // 
            // btnAdminResPas
            // 
            btnAdminResPas.BackColor = Color.Crimson;
            btnAdminResPas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdminResPas.ForeColor = SystemColors.ControlLightLight;
            btnAdminResPas.Location = new Point(463, 340);
            btnAdminResPas.Name = "btnAdminResPas";
            btnAdminResPas.Size = new Size(141, 29);
            btnAdminResPas.TabIndex = 22;
            btnAdminResPas.Text = "Reset Password";
            btnAdminResPas.UseVisualStyleBackColor = false;
            // 
            // AdminPositionr
            // 
            AdminPositionr.AutoSize = true;
            AdminPositionr.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AdminPositionr.Location = new Point(138, 56);
            AdminPositionr.Name = "AdminPositionr";
            AdminPositionr.Size = new Size(78, 51);
            AdminPositionr.TabIndex = 4;
            AdminPositionr.Text = "position";
            // 
            // btnRCancelAdmin
            // 
            btnRCancelAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRCancelAdmin.ForeColor = Color.Red;
            btnRCancelAdmin.Location = new Point(351, 340);
            btnRCancelAdmin.Name = "btnRCancelAdmin";
            btnRCancelAdmin.Size = new Size(94, 29);
            btnRCancelAdmin.TabIndex = 21;
            btnRCancelAdmin.Text = "Cancel";
            btnRCancelAdmin.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(71, 107);
            label7.Name = "label7";
            label7.Size = new Size(103, 51);
            label7.TabIndex = 13;
            label7.Text = "Student ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label5.Location = new Point(351, 107);
            label5.Name = "label5";
            label5.Size = new Size(178, 51);
            label5.TabIndex = 14;
            label5.Text = "Umindanao Address";
            // 
            // tBAdminEmailAdShow
            // 
            tBAdminEmailAdShow.BackColor = SystemColors.ControlLight;
            tBAdminEmailAdShow.Location = new Point(351, 161);
            tBAdminEmailAdShow.Name = "tBAdminEmailAdShow";
            tBAdminEmailAdShow.Size = new Size(243, 27);
            tBAdminEmailAdShow.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 202);
            label1.Name = "label1";
            label1.Size = new Size(134, 51);
            label1.TabIndex = 17;
            label1.Text = "New Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 287);
            label2.Name = "label2";
            label2.Size = new Size(162, 51);
            label2.TabIndex = 18;
            label2.Text = "Confirm Password";
            // 
            // tBAdminIDShow
            // 
            tBAdminIDShow.BackColor = SystemColors.ControlLight;
            tBAdminIDShow.Location = new Point(56, 161);
            tBAdminIDShow.Name = "tBAdminIDShow";
            tBAdminIDShow.Size = new Size(160, 27);
            tBAdminIDShow.TabIndex = 15;
            // 
            // ResPasAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ResPasAdmin";
            Size = new Size(645, 546);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label BacktoFaculty;
        private Label label10;
        private Panel panel2;
        private TextBox AdminConfirmPass;
        private TextBox AdminNewPass;
        private Button btnAdminIDCopyr;
        private Label AdminNamer;
        private Button btnAdminResPas;
        private Label AdminPositionr;
        private Button btnRCancelAdmin;
        private Label label7;
        private Label label5;
        private TextBox tBAdminEmailAdShow;
        private Label label1;
        private Label label2;
        private TextBox tBAdminIDShow;
    }
}
