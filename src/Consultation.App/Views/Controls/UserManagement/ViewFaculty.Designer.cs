namespace Consultation.App.Views.Controls.UserManagement
{
    partial class ViewFaculty
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
            panVFac = new Panel();
            panel3 = new Panel();
            btnFacDelv = new Button();
            btnFacResPasv = new Button();
            btnFacEUPv = new Button();
            label9 = new Label();
            w = new Panel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            tBFacProgramv = new TextBox();
            tBFacRoleJobv = new TextBox();
            tBFacContactNumv = new TextBox();
            tBFacUMEmailv = new TextBox();
            tBFacultyIDv = new TextBox();
            label4 = new Label();
            label3 = new Label();
            FacMemPositionv = new Label();
            FacMemNamev = new Label();
            panel1 = new Panel();
            BacktoFaculty = new Label();
            label10 = new Label();
            BtnCopyFacIDv = new Button();
            panVFac.SuspendLayout();
            panel3.SuspendLayout();
            w.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panVFac
            // 
            panVFac.Controls.Add(panel3);
            panVFac.Controls.Add(w);
            panVFac.Controls.Add(panel1);
            panVFac.Location = new Point(3, 3);
            panVFac.Name = "panVFac";
            panVFac.Size = new Size(938, 544);
            panVFac.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnFacDelv);
            panel3.Controls.Add(btnFacResPasv);
            panel3.Controls.Add(btnFacEUPv);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(691, 147);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 394);
            panel3.TabIndex = 4;
            // 
            // btnFacDelv
            // 
            btnFacDelv.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            btnFacDelv.ForeColor = Color.Crimson;
            btnFacDelv.Location = new Point(32, 158);
            btnFacDelv.Name = "btnFacDelv";
            btnFacDelv.Size = new Size(188, 40);
            btnFacDelv.TabIndex = 4;
            btnFacDelv.Text = "Delete";
            btnFacDelv.UseVisualStyleBackColor = true;
            // 
            // btnFacResPasv
            // 
            btnFacResPasv.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            btnFacResPasv.ForeColor = Color.Crimson;
            btnFacResPasv.Location = new Point(32, 112);
            btnFacResPasv.Name = "btnFacResPasv";
            btnFacResPasv.Size = new Size(188, 40);
            btnFacResPasv.TabIndex = 3;
            btnFacResPasv.Text = "Reset Password";
            btnFacResPasv.UseVisualStyleBackColor = true;
            // 
            // btnFacEUPv
            // 
            btnFacEUPv.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            btnFacEUPv.ForeColor = Color.Crimson;
            btnFacEUPv.Location = new Point(32, 66);
            btnFacEUPv.Name = "btnFacEUPv";
            btnFacEUPv.Size = new Size(188, 40);
            btnFacEUPv.TabIndex = 2;
            btnFacEUPv.Text = "Edit User Profile";
            btnFacEUPv.UseVisualStyleBackColor = true;
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
            // w
            // 
            w.Controls.Add(BtnCopyFacIDv);
            w.Controls.Add(label8);
            w.Controls.Add(label7);
            w.Controls.Add(label6);
            w.Controls.Add(label5);
            w.Controls.Add(tBFacProgramv);
            w.Controls.Add(tBFacRoleJobv);
            w.Controls.Add(tBFacContactNumv);
            w.Controls.Add(tBFacUMEmailv);
            w.Controls.Add(tBFacultyIDv);
            w.Controls.Add(label4);
            w.Controls.Add(label3);
            w.Controls.Add(FacMemPositionv);
            w.Controls.Add(FacMemNamev);
            w.Location = new Point(11, 147);
            w.Name = "w";
            w.Size = new Size(674, 394);
            w.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(374, 281);
            label8.Name = "label8";
            label8.Size = new Size(83, 51);
            label8.TabIndex = 12;
            label8.Text = "Program";
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
            label5.Size = new Size(201, 51);
            label5.TabIndex = 9;
            label5.Text = "Umindanao Email Address";
            // 
            // tBFacProgramv
            // 
            tBFacProgramv.BackColor = SystemColors.ControlLight;
            tBFacProgramv.Location = new Point(374, 335);
            tBFacProgramv.Name = "tBFacProgramv";
            tBFacProgramv.Size = new Size(281, 27);
            tBFacProgramv.TabIndex = 8;
            // 
            // tBFacRoleJobv
            // 
            tBFacRoleJobv.BackColor = SystemColors.ControlLight;
            tBFacRoleJobv.Location = new Point(374, 251);
            tBFacRoleJobv.Name = "tBFacRoleJobv";
            tBFacRoleJobv.Size = new Size(281, 27);
            tBFacRoleJobv.TabIndex = 7;
            // 
            // tBFacContactNumv
            // 
            tBFacContactNumv.BackColor = SystemColors.ControlLight;
            tBFacContactNumv.Location = new Point(13, 335);
            tBFacContactNumv.Name = "tBFacContactNumv";
            tBFacContactNumv.Size = new Size(289, 27);
            tBFacContactNumv.TabIndex = 6;
            // 
            // tBFacUMEmailv
            // 
            tBFacUMEmailv.BackColor = SystemColors.ControlLight;
            tBFacUMEmailv.Location = new Point(13, 251);
            tBFacUMEmailv.Name = "tBFacUMEmailv";
            tBFacUMEmailv.Size = new Size(289, 27);
            tBFacUMEmailv.TabIndex = 5;
            // 
            // tBFacultyIDv
            // 
            tBFacultyIDv.BackColor = SystemColors.ControlLight;
            tBFacultyIDv.Location = new Point(13, 166);
            tBFacultyIDv.Name = "tBFacultyIDv";
            tBFacultyIDv.Size = new Size(160, 27);
            tBFacultyIDv.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 121);
            label4.Name = "label4";
            label4.Size = new Size(89, 51);
            label4.TabIndex = 3;
            label4.Text = "Faculty ID";
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
            // FacMemPositionv
            // 
            FacMemPositionv.AutoSize = true;
            FacMemPositionv.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FacMemPositionv.Location = new Point(109, 53);
            FacMemPositionv.Name = "FacMemPositionv";
            FacMemPositionv.Size = new Size(78, 51);
            FacMemPositionv.TabIndex = 1;
            FacMemPositionv.Text = "Position";
            // 
            // FacMemNamev
            // 
            FacMemNamev.AutoSize = true;
            FacMemNamev.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FacMemNamev.Location = new Point(109, 12);
            FacMemNamev.Name = "FacMemNamev";
            FacMemNamev.Size = new Size(67, 51);
            FacMemNamev.TabIndex = 0;
            FacMemNamev.Text = "Name";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Crimson;
            panel1.Controls.Add(BacktoFaculty);
            panel1.Controls.Add(label10);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(935, 133);
            panel1.TabIndex = 1;
            // 
            // BacktoFaculty
            // 
            BacktoFaculty.AutoSize = true;
            BacktoFaculty.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BacktoFaculty.ForeColor = SystemColors.ControlLightLight;
            BacktoFaculty.Location = new Point(8, 3);
            BacktoFaculty.Name = "BacktoFaculty";
            BacktoFaculty.Size = new Size(156, 51);
            BacktoFaculty.TabIndex = 3;
            BacktoFaculty.Text = "<- Back to Faculty";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Sans Serif Collection", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(8, 29);
            label10.Name = "label10";
            label10.Size = new Size(244, 112);
            label10.TabIndex = 2;
            label10.Text = "User Details";
            // 
            // BtnCopyFacIDv
            // 
            BtnCopyFacIDv.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnCopyFacIDv.ForeColor = Color.Red;
            BtnCopyFacIDv.Location = new Point(180, 166);
            BtnCopyFacIDv.Name = "BtnCopyFacIDv";
            BtnCopyFacIDv.Size = new Size(64, 28);
            BtnCopyFacIDv.TabIndex = 25;
            BtnCopyFacIDv.Text = "Copy";
            BtnCopyFacIDv.UseVisualStyleBackColor = true;
            // 
            // ViewFaculty
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panVFac);
            Name = "ViewFaculty";
            Size = new Size(944, 544);
            panVFac.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            w.ResumeLayout(false);
            w.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panVFac;
        private Panel panel1;
        private Panel panel3;
        private Button btnFacDelv;
        private Button btnFacResPasv;
        private Button btnFacEUPv;
        private Label label9;
        private Panel w;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox tBFacProgramv;
        private TextBox tBFacRoleJobv;
        private TextBox tBFacContactNumv;
        private TextBox tBFacUMEmailv;
        private TextBox tBFacultyIDv;
        private Label label4;
        private Label label3;
        private Label FacMemPositionv;
        private Label FacMemNamev;
        private Label BacktoFaculty;
        private Label label10;
        private Button BtnCopyFacIDv;
    }
}
