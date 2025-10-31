namespace Consultation.App.Views.Controls.UserManagement
{
    partial class EditAdmin
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
            BacktoAdmin = new Label();
            label10 = new Label();
            panel2 = new Panel();
            btnEditSaveAdmin = new Button();
            btnEditCancelAdmin = new Button();
            comboBox2 = new ComboBox();
            label11 = new Label();
            label9 = new Label();
            comboBox1 = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tBEditIDAdmin = new TextBox();
            tBEditContactNumAdmin = new TextBox();
            tBEditEmailAddAdmin = new TextBox();
            tBEditLastNameAdmin = new TextBox();
            tBEditMiddleNameAdmin = new TextBox();
            tBEditFirstNameAdmin = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Crimson;
            panel1.Controls.Add(BacktoAdmin);
            panel1.Controls.Add(label10);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(754, 133);
            panel1.TabIndex = 1;
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
            label10.Size = new Size(304, 112);
            label10.TabIndex = 0;
            label10.Text = "Edit User Profile";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(btnEditSaveAdmin);
            panel2.Controls.Add(btnEditCancelAdmin);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(tBEditIDAdmin);
            panel2.Controls.Add(tBEditContactNumAdmin);
            panel2.Controls.Add(tBEditEmailAddAdmin);
            panel2.Controls.Add(tBEditLastNameAdmin);
            panel2.Controls.Add(tBEditMiddleNameAdmin);
            panel2.Controls.Add(tBEditFirstNameAdmin);
            panel2.Location = new Point(27, 142);
            panel2.Name = "panel2";
            panel2.Size = new Size(701, 470);
            panel2.TabIndex = 3;
            // 
            // btnEditSaveAdmin
            // 
            btnEditSaveAdmin.BackColor = Color.Crimson;
            btnEditSaveAdmin.ForeColor = SystemColors.ControlLightLight;
            btnEditSaveAdmin.Location = new Point(498, 419);
            btnEditSaveAdmin.Name = "btnEditSaveAdmin";
            btnEditSaveAdmin.Size = new Size(141, 29);
            btnEditSaveAdmin.TabIndex = 19;
            btnEditSaveAdmin.Text = "Save Changes ";
            btnEditSaveAdmin.UseVisualStyleBackColor = false;
            // 
            // btnEditCancelAdmin
            // 
            btnEditCancelAdmin.ForeColor = Color.Red;
            btnEditCancelAdmin.Location = new Point(389, 419);
            btnEditCancelAdmin.Name = "btnEditCancelAdmin";
            btnEditCancelAdmin.Size = new Size(94, 29);
            btnEditCancelAdmin.TabIndex = 18;
            btnEditCancelAdmin.Text = "Cancel";
            btnEditCancelAdmin.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(393, 274);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(209, 28);
            comboBox2.TabIndex = 17;
            comboBox2.Text = "Select Department";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(393, 220);
            label11.Name = "label11";
            label11.Size = new Size(115, 51);
            label11.TabIndex = 16;
            label11.Text = "Department";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(393, 0);
            label9.Name = "label9";
            label9.Size = new Size(174, 51);
            label9.TabIndex = 15;
            label9.Text = "Academic Information";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(393, 189);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(209, 28);
            comboBox1.TabIndex = 14;
            comboBox1.Text = "Select Role/ Job Title ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(393, 135);
            label8.Name = "label8";
            label8.Size = new Size(131, 51);
            label8.TabIndex = 13;
            label8.Text = "Role / Job Title";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(393, 51);
            label7.Name = "label7";
            label7.Size = new Size(103, 51);
            label7.TabIndex = 12;
            label7.Text = "Student ID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label6.Location = new Point(62, 369);
            label6.Name = "label6";
            label6.Size = new Size(150, 51);
            label6.TabIndex = 11;
            label6.Text = "Contact Number ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label5.Location = new Point(62, 285);
            label5.Name = "label5";
            label5.Size = new Size(178, 51);
            label5.TabIndex = 10;
            label5.Text = "Umindanao Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label4.Location = new Point(62, 201);
            label4.Name = "label4";
            label4.Size = new Size(102, 51);
            label4.TabIndex = 9;
            label4.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label3.Location = new Point(62, 117);
            label3.Name = "label3";
            label3.Size = new Size(124, 51);
            label3.TabIndex = 8;
            label3.Text = "Middle Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(62, 33);
            label2.Name = "label2";
            label2.Size = new Size(105, 51);
            label2.TabIndex = 7;
            label2.Text = "First Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 51);
            label1.TabIndex = 6;
            label1.Text = "User Information";
            // 
            // tBEditIDAdmin
            // 
            tBEditIDAdmin.Location = new Point(393, 105);
            tBEditIDAdmin.Name = "tBEditIDAdmin";
            tBEditIDAdmin.Size = new Size(209, 27);
            tBEditIDAdmin.TabIndex = 5;
            tBEditIDAdmin.Text = "Enter Employee ID";
            // 
            // tBEditContactNumAdmin
            // 
            tBEditContactNumAdmin.Location = new Point(62, 421);
            tBEditContactNumAdmin.Name = "tBEditContactNumAdmin";
            tBEditContactNumAdmin.Size = new Size(224, 27);
            tBEditContactNumAdmin.TabIndex = 4;
            tBEditContactNumAdmin.Text = "Enter Contact Number";
            // 
            // tBEditEmailAddAdmin
            // 
            tBEditEmailAddAdmin.Location = new Point(62, 339);
            tBEditEmailAddAdmin.Name = "tBEditEmailAddAdmin";
            tBEditEmailAddAdmin.Size = new Size(224, 27);
            tBEditEmailAddAdmin.TabIndex = 3;
            tBEditEmailAddAdmin.Text = "Enter Email Address";
            // 
            // tBEditLastNameAdmin
            // 
            tBEditLastNameAdmin.Location = new Point(62, 255);
            tBEditLastNameAdmin.Name = "tBEditLastNameAdmin";
            tBEditLastNameAdmin.Size = new Size(224, 27);
            tBEditLastNameAdmin.TabIndex = 2;
            tBEditLastNameAdmin.Text = "Enter Last Name";
            // 
            // tBEditMiddleNameAdmin
            // 
            tBEditMiddleNameAdmin.Location = new Point(62, 171);
            tBEditMiddleNameAdmin.Name = "tBEditMiddleNameAdmin";
            tBEditMiddleNameAdmin.Size = new Size(224, 27);
            tBEditMiddleNameAdmin.TabIndex = 1;
            tBEditMiddleNameAdmin.Text = "Enter Middle Name";
            // 
            // tBEditFirstNameAdmin
            // 
            tBEditFirstNameAdmin.Location = new Point(62, 87);
            tBEditFirstNameAdmin.Name = "tBEditFirstNameAdmin";
            tBEditFirstNameAdmin.Size = new Size(224, 27);
            tBEditFirstNameAdmin.TabIndex = 0;
            tBEditFirstNameAdmin.Text = "Enter First Name";
            // 
            // EditAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "EditAdmin";
            Size = new Size(761, 636);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label BacktoAdmin;
        private Label label10;
        private Panel panel2;
        private Button btnEditSaveAdmin;
        private Button btnEditCancelAdmin;
        private ComboBox comboBox2;
        private Label label11;
        private Label label9;
        private ComboBox comboBox1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tBEditIDAdmin;
        private TextBox tBEditContactNumAdmin;
        private TextBox tBEditEmailAddAdmin;
        private TextBox tBEditLastNameAdmin;
        private TextBox tBEditMiddleNameAdmin;
        private TextBox tBEditFirstNameAdmin;
    }
}
