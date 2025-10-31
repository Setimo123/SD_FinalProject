namespace Consultation.App.Views
{
    partial class StudentCard
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
            lblStudName = new Label();
            lblStudID = new Label();
            lblStudEmail = new Label();
            pictureBox = new PictureBox();
            StudAction = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // lblStudName
            // 
            lblStudName.AutoSize = true;
            lblStudName.Font = new Font("Sans Serif Collection", 9F);
            lblStudName.Location = new Point(93, 16);
            lblStudName.Name = "lblStudName";
            lblStudName.Size = new Size(118, 51);
            lblStudName.TabIndex = 0;
            lblStudName.Text = "Student Name";
            // 
            // lblStudID
            // 
            lblStudID.AutoSize = true;
            lblStudID.Font = new Font("Sans Serif Collection", 9F);
            lblStudID.Location = new Point(314, 16);
            lblStudID.Name = "lblStudID";
            lblStudID.Size = new Size(42, 51);
            lblStudID.TabIndex = 1;
            lblStudID.Text = "I.D";
            // 
            // lblStudEmail
            // 
            lblStudEmail.AutoSize = true;
            lblStudEmail.Font = new Font("Sans Serif Collection", 9F);
            lblStudEmail.Location = new Point(488, 16);
            lblStudEmail.Name = "lblStudEmail";
            lblStudEmail.Size = new Size(143, 51);
            lblStudEmail.TabIndex = 3;
            lblStudEmail.Text = "Umindanao Email";
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Icons.person_b;
            pictureBox.Location = new Point(3, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(84, 64);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.TabIndex = 11;
            pictureBox.TabStop = false;
            // 
            // StudAction
            // 
            StudAction.AutoSize = true;
            StudAction.Font = new Font("Sans Serif Collection", 9F);
            StudAction.Location = new Point(766, 16);
            StudAction.Name = "StudAction";
            StudAction.Size = new Size(34, 51);
            StudAction.TabIndex = 12;
            StudAction.Text = "...";
            // 
            // StudentCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(StudAction);
            Controls.Add(pictureBox);
            Controls.Add(lblStudEmail);
            Controls.Add(lblStudID);
            Controls.Add(lblStudName);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StudentCard";
            Size = new Size(948, 70);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudName;
        private Label lblStudID;
        private Label lblStudEmail;
        private PictureBox pictureBox;
        private Label StudAction;
    }
}
