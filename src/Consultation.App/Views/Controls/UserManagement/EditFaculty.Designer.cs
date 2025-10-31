namespace Consultation.App.Views.Controls.UserManagement
{
    partial class EditFaculty
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
            btnEditSaveFac = new Button();
            btnEditCancelFac = new Button();
            CBEditProgramFac = new ComboBox();
            label11 = new Label();
            label9 = new Label();
            CBEditJobtitleFac = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tBEditIDFac = new TextBox();
            tBEditContactNumFac = new TextBox();
            tBEditEmailAddFac = new TextBox();
            tBEditLastNameFac = new TextBox();
            tBEditMiddleNameFac = new TextBox();
            tBEditFirstNameFac = new TextBox();
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
            panel1.Size = new Size(754, 133);
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
            BacktoFaculty.TabIndex = 1;
            BacktoFaculty.Text = "<- Back to Faculty";
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
            panel2.Controls.Add(btnEditSaveFac);
            panel2.Controls.Add(btnEditCancelFac);
            panel2.Controls.Add(CBEditProgramFac);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(CBEditJobtitleFac);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(tBEditIDFac);
            panel2.Controls.Add(tBEditContactNumFac);
            panel2.Controls.Add(tBEditEmailAddFac);
            panel2.Controls.Add(tBEditLastNameFac);
            panel2.Controls.Add(tBEditMiddleNameFac);
            panel2.Controls.Add(tBEditFirstNameFac);
            panel2.Location = new Point(27, 142);
            panel2.Name = "panel2";
            panel2.Size = new Size(701, 470);
            panel2.TabIndex = 3;
            // 
            // btnEditSaveFac
            // 
            btnEditSaveFac.BackColor = Color.Crimson;
            btnEditSaveFac.ForeColor = SystemColors.ControlLightLight;
            btnEditSaveFac.Location = new Point(498, 419);
            btnEditSaveFac.Name = "btnEditSaveFac";
            btnEditSaveFac.Size = new Size(141, 29);
            btnEditSaveFac.TabIndex = 19;
            btnEditSaveFac.Text = "Save Changes ";
            btnEditSaveFac.UseVisualStyleBackColor = false;
            // 
            // btnEditCancelFac
            // 
            btnEditCancelFac.ForeColor = Color.Red;
            btnEditCancelFac.Location = new Point(389, 419);
            btnEditCancelFac.Name = "btnEditCancelFac";
            btnEditCancelFac.Size = new Size(94, 29);
            btnEditCancelFac.TabIndex = 18;
            btnEditCancelFac.Text = "Cancel";
            btnEditCancelFac.UseVisualStyleBackColor = true;
            // 
            // CBEditProgramFac
            // 
            CBEditProgramFac.FormattingEnabled = true;
            CBEditProgramFac.Location = new Point(393, 274);
            CBEditProgramFac.Name = "CBEditProgramFac";
            CBEditProgramFac.Size = new Size(209, 28);
            CBEditProgramFac.TabIndex = 17;
            CBEditProgramFac.Text = "Select Program";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(393, 220);
            label11.Name = "label11";
            label11.Size = new Size(90, 51);
            label11.TabIndex = 16;
            label11.Text = "Program";
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
            // CBEditJobtitleFac
            // 
            CBEditJobtitleFac.FormattingEnabled = true;
            CBEditJobtitleFac.Location = new Point(393, 189);
            CBEditJobtitleFac.Name = "CBEditJobtitleFac";
            CBEditJobtitleFac.Size = new Size(209, 28);
            CBEditJobtitleFac.TabIndex = 14;
            CBEditJobtitleFac.Text = "Select Role/ Job Title ";
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
            label7.Size = new Size(99, 51);
            label7.TabIndex = 12;
            label7.Text = "Faculty ID";
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
            label5.Size = new Size(131, 51);
            label5.TabIndex = 10;
            label5.Text = "Email Address";
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
            // tBEditIDFac
            // 
            tBEditIDFac.Location = new Point(393, 105);
            tBEditIDFac.Name = "tBEditIDFac";
            tBEditIDFac.Size = new Size(209, 27);
            tBEditIDFac.TabIndex = 5;
            tBEditIDFac.Text = "Enter Faculty ID";
            // 
            // tBEditContactNumFac
            // 
            tBEditContactNumFac.Location = new Point(62, 421);
            tBEditContactNumFac.Name = "tBEditContactNumFac";
            tBEditContactNumFac.Size = new Size(224, 27);
            tBEditContactNumFac.TabIndex = 4;
            tBEditContactNumFac.Text = "Enter Contact Number";
            // 
            // tBEditEmailAddFac
            // 
            tBEditEmailAddFac.Location = new Point(62, 339);
            tBEditEmailAddFac.Name = "tBEditEmailAddFac";
            tBEditEmailAddFac.Size = new Size(224, 27);
            tBEditEmailAddFac.TabIndex = 3;
            tBEditEmailAddFac.Text = "Enter Email Address";
            // 
            // tBEditLastNameFac
            // 
            tBEditLastNameFac.Location = new Point(62, 255);
            tBEditLastNameFac.Name = "tBEditLastNameFac";
            tBEditLastNameFac.Size = new Size(224, 27);
            tBEditLastNameFac.TabIndex = 2;
            tBEditLastNameFac.Text = "Enter Last Name";
            // 
            // tBEditMiddleNameFac
            // 
            tBEditMiddleNameFac.Location = new Point(62, 171);
            tBEditMiddleNameFac.Name = "tBEditMiddleNameFac";
            tBEditMiddleNameFac.Size = new Size(224, 27);
            tBEditMiddleNameFac.TabIndex = 1;
            tBEditMiddleNameFac.Text = "Enter Middle Name";
            // 
            // tBEditFirstNameFac
            // 
            tBEditFirstNameFac.Location = new Point(62, 87);
            tBEditFirstNameFac.Name = "tBEditFirstNameFac";
            tBEditFirstNameFac.Size = new Size(224, 27);
            tBEditFirstNameFac.TabIndex = 0;
            tBEditFirstNameFac.Text = "Enter First Name";
            // 
            // EditFaculty
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "EditFaculty";
            Size = new Size(761, 636);
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
        private Button btnEditSaveFac;
        private Button btnEditCancelFac;
        private ComboBox CBEditProgramFac;
        private Label label11;
        private Label label9;
        private ComboBox CBEditJobtitleFac;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tBEditIDFac;
        private TextBox tBEditContactNumFac;
        private TextBox tBEditEmailAddFac;
        private TextBox tBEditLastNameFac;
        private TextBox tBEditMiddleNameFac;
        private TextBox tBEditFirstNameFac;
    }
}
