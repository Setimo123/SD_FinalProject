namespace Consultation.App.Views
{
    partial class FacultyCard
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
            FacAction = new Label();
            lblFacEmail = new Label();
            lblFacID = new Label();
            lblFacName = new Label();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // FacAction
            // 
            FacAction.AutoSize = true;
            FacAction.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FacAction.Location = new Point(765, 16);
            FacAction.Name = "FacAction";
            FacAction.Size = new Size(37, 51);
            FacAction.TabIndex = 21;
            FacAction.Text = "...";
            // 
            // lblFacEmail
            // 
            lblFacEmail.AutoSize = true;
            lblFacEmail.Font = new Font("Sans Serif Collection", 9F);
            lblFacEmail.Location = new Point(485, 16);
            lblFacEmail.Name = "lblFacEmail";
            lblFacEmail.Size = new Size(143, 51);
            lblFacEmail.TabIndex = 20;
            lblFacEmail.Text = "Umindanao Email";
            // 
            // lblFacID
            // 
            lblFacID.AutoSize = true;
            lblFacID.Font = new Font("Sans Serif Collection", 9F);
            lblFacID.Location = new Point(310, 16);
            lblFacID.Name = "lblFacID";
            lblFacID.Size = new Size(42, 51);
            lblFacID.TabIndex = 19;
            lblFacID.Text = "I.D";
            // 
            // lblFacName
            // 
            lblFacName.AutoSize = true;
            lblFacName.Font = new Font("Sans Serif Collection", 9F);
            lblFacName.Location = new Point(93, 16);
            lblFacName.Name = "lblFacName";
            lblFacName.Size = new Size(114, 51);
            lblFacName.TabIndex = 18;
            lblFacName.Text = "Faculty Name";
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Icons.person_b;
            pictureBox.Location = new Point(3, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(84, 64);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.TabIndex = 22;
            pictureBox.TabStop = false;
            // 
            // FacultyCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(pictureBox);
            Controls.Add(FacAction);
            Controls.Add(lblFacEmail);
            Controls.Add(lblFacID);
            Controls.Add(lblFacName);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FacultyCard";
            Size = new Size(944, 70);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FacAction;
        private Label lblFacEmail;
        private Label lblFacID;
        private Label lblFacName;
        private PictureBox pictureBox;
    }
}
