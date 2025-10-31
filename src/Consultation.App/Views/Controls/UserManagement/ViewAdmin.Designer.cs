namespace Consultation.App.Views.Controls.UserManagement
{
    partial class ViewAdmin
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
            panVA = new Panel();
            panel3 = new Panel();
            btnAdminDelv = new Button();
            btnAdminResPasv = new Button();
            btnAdminEUPv = new Button();
            label9 = new Label();
            panel2 = new Panel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            tBAdminDepartv = new TextBox();
            tBAdminRoleJobv = new TextBox();
            tBAdminContactNumv = new TextBox();
            tBAdminEmailv = new TextBox();
            tBAdminEmployeeIDv = new TextBox();
            label4 = new Label();
            label3 = new Label();
            AdminTitlev = new Label();
            AdminsNamev = new Label();
            panel1 = new Panel();
            BacktoAdmin = new Label();
            label10 = new Label();
            BtnCopyAdminIDv = new Button();
            panVA.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panVA
            // 
            panVA.Controls.Add(panel3);
            panVA.Controls.Add(panel2);
            panVA.Controls.Add(panel1);
            panVA.Location = new Point(3, 3);
            panVA.Name = "panVA";
            panVA.Size = new Size(944, 544);
            panVA.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnAdminDelv);
            panel3.Controls.Add(btnAdminResPasv);
            panel3.Controls.Add(btnAdminEUPv);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(691, 147);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 394);
            panel3.TabIndex = 2;
            // 
            // btnAdminDelv
            // 
            btnAdminDelv.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            btnAdminDelv.ForeColor = Color.Crimson;
            btnAdminDelv.Location = new Point(32, 158);
            btnAdminDelv.Name = "btnAdminDelv";
            btnAdminDelv.Size = new Size(188, 40);
            btnAdminDelv.TabIndex = 4;
            btnAdminDelv.Text = "Delete";
            btnAdminDelv.UseVisualStyleBackColor = true;
            // 
            // btnAdminResPasv
            // 
            btnAdminResPasv.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            btnAdminResPasv.ForeColor = Color.Crimson;
            btnAdminResPasv.Location = new Point(32, 112);
            btnAdminResPasv.Name = "btnAdminResPasv";
            btnAdminResPasv.Size = new Size(188, 40);
            btnAdminResPasv.TabIndex = 3;
            btnAdminResPasv.Text = "Reset Password";
            btnAdminResPasv.UseVisualStyleBackColor = true;
            // 
            // btnAdminEUPv
            // 
            btnAdminEUPv.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            btnAdminEUPv.ForeColor = Color.Crimson;
            btnAdminEUPv.Location = new Point(32, 66);
            btnAdminEUPv.Name = "btnAdminEUPv";
            btnAdminEUPv.Size = new Size(188, 40);
            btnAdminEUPv.TabIndex = 2;
            btnAdminEUPv.Text = "Edit User Profile";
            btnAdminEUPv.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(68, 12);
            label9.Name = "label9";
            label9.Size = new Size(120, 51);
            label9.TabIndex = 1;
            label9.Text = "Quick Action";
            // 
            // panel2
            // 
            panel2.Controls.Add(BtnCopyAdminIDv);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(tBAdminDepartv);
            panel2.Controls.Add(tBAdminRoleJobv);
            panel2.Controls.Add(tBAdminContactNumv);
            panel2.Controls.Add(tBAdminEmailv);
            panel2.Controls.Add(tBAdminEmployeeIDv);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(AdminTitlev);
            panel2.Controls.Add(AdminsNamev);
            panel2.Location = new Point(11, 147);
            panel2.Name = "panel2";
            panel2.Size = new Size(674, 394);
            panel2.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(374, 281);
            label8.Name = "label8";
            label8.Size = new Size(105, 51);
            label8.TabIndex = 12;
            label8.Text = "Department";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(374, 197);
            label7.Name = "label7";
            label7.Size = new Size(111, 51);
            label7.TabIndex = 11;
            label7.Text = "Role/Job Title";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(13, 281);
            label6.Name = "label6";
            label6.Size = new Size(133, 51);
            label6.TabIndex = 10;
            label6.Text = "Contact Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(13, 197);
            label5.Name = "label5";
            label5.Size = new Size(118, 51);
            label5.TabIndex = 9;
            label5.Text = "Email Address";
            // 
            // tBAdminDepartv
            // 
            tBAdminDepartv.BackColor = SystemColors.ControlLight;
            tBAdminDepartv.Location = new Point(374, 335);
            tBAdminDepartv.Name = "tBAdminDepartv";
            tBAdminDepartv.Size = new Size(281, 27);
            tBAdminDepartv.TabIndex = 8;
            // 
            // tBAdminRoleJobv
            // 
            tBAdminRoleJobv.BackColor = SystemColors.ControlLight;
            tBAdminRoleJobv.Location = new Point(374, 251);
            tBAdminRoleJobv.Name = "tBAdminRoleJobv";
            tBAdminRoleJobv.Size = new Size(281, 27);
            tBAdminRoleJobv.TabIndex = 7;
            // 
            // tBAdminContactNumv
            // 
            tBAdminContactNumv.BackColor = SystemColors.ControlLight;
            tBAdminContactNumv.Location = new Point(13, 335);
            tBAdminContactNumv.Name = "tBAdminContactNumv";
            tBAdminContactNumv.Size = new Size(289, 27);
            tBAdminContactNumv.TabIndex = 6;
            // 
            // tBAdminEmailv
            // 
            tBAdminEmailv.BackColor = SystemColors.ControlLight;
            tBAdminEmailv.Location = new Point(13, 251);
            tBAdminEmailv.Name = "tBAdminEmailv";
            tBAdminEmailv.Size = new Size(289, 27);
            tBAdminEmailv.TabIndex = 5;
            // 
            // tBAdminEmployeeIDv
            // 
            tBAdminEmployeeIDv.BackColor = SystemColors.ControlLight;
            tBAdminEmployeeIDv.Location = new Point(13, 166);
            tBAdminEmployeeIDv.Name = "tBAdminEmployeeIDv";
            tBAdminEmployeeIDv.Size = new Size(160, 27);
            tBAdminEmployeeIDv.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 126);
            label4.Name = "label4";
            label4.Size = new Size(108, 51);
            label4.TabIndex = 3;
            label4.Text = "Employee ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 89);
            label3.Name = "label3";
            label3.Size = new Size(160, 51);
            label3.TabIndex = 2;
            label3.Text = "Basic Information";
            // 
            // AdminTitlev
            // 
            AdminTitlev.AutoSize = true;
            AdminTitlev.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AdminTitlev.Location = new Point(109, 53);
            AdminTitlev.Name = "AdminTitlev";
            AdminTitlev.Size = new Size(118, 51);
            AdminTitlev.TabIndex = 1;
            AdminTitlev.Text = "Administrator";
            // 
            // AdminsNamev
            // 
            AdminsNamev.AutoSize = true;
            AdminsNamev.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AdminsNamev.Location = new Point(109, 12);
            AdminsNamev.Name = "AdminsNamev";
            AdminsNamev.Size = new Size(67, 51);
            AdminsNamev.TabIndex = 0;
            AdminsNamev.Text = "Name";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Crimson;
            panel1.Controls.Add(BacktoAdmin);
            panel1.Controls.Add(label10);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(938, 133);
            panel1.TabIndex = 0;
            // 
            // BacktoAdmin
            // 
            BacktoAdmin.AutoSize = true;
            BacktoAdmin.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BacktoAdmin.ForeColor = SystemColors.ControlLightLight;
            BacktoAdmin.Location = new Point(8, 3);
            BacktoAdmin.Name = "BacktoAdmin";
            BacktoAdmin.Size = new Size(151, 51);
            BacktoAdmin.TabIndex = 1;
            BacktoAdmin.Text = "<- Back to Admin";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Sans Serif Collection", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(8, 29);
            label10.Name = "label10";
            label10.Size = new Size(244, 112);
            label10.TabIndex = 0;
            label10.Text = "User Details";
            // 
            // BtnCopyAdminIDv
            // 
            BtnCopyAdminIDv.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnCopyAdminIDv.ForeColor = Color.Red;
            BtnCopyAdminIDv.Location = new Point(180, 166);
            BtnCopyAdminIDv.Name = "BtnCopyAdminIDv";
            BtnCopyAdminIDv.Size = new Size(64, 28);
            BtnCopyAdminIDv.TabIndex = 25;
            BtnCopyAdminIDv.Text = "Copy";
            BtnCopyAdminIDv.UseVisualStyleBackColor = true;
            // 
            // ViewAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panVA);
            Name = "ViewAdmin";
            Size = new Size(950, 550);
            panVA.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panVA;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private TextBox tBAdminDepartv;
        private TextBox tBAdminRoleJobv;
        private TextBox tBAdminContactNumv;
        private TextBox tBAdminEmailv;
        private TextBox tBAdminEmployeeIDv;
        private Label label4;
        private Label label3;
        private Label AdminTitlev;
        private Label AdminsNamev;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button btnAdminDelv;
        private Button btnAdminResPasv;
        private Button btnAdminEUPv;
        private Label label9;
        private Label BacktoAdmin;
        private Label label10;
        private Button BtnCopyAdminIDv;
    }
}
