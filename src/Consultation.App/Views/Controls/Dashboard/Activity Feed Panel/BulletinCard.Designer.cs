namespace Consultation.App.Dashboard.Activity_Feed_Panel
{
    partial class BulletinCard
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
            BulletinTitle = new Label();
            BulletinBody = new Label();
            SuspendLayout();
            // 
            // BulletinTitle
            // 
            BulletinTitle.AutoSize = true;
            BulletinTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BulletinTitle.Location = new Point(36, 25);
            BulletinTitle.Name = "BulletinTitle";
            BulletinTitle.Size = new Size(30, 15);
            BulletinTitle.TabIndex = 0;
            BulletinTitle.Text = "Title";
            // 
            // BulletinBody
            // 
            BulletinBody.AutoSize = true;
            BulletinBody.Location = new Point(36, 58);
            BulletinBody.Name = "BulletinBody";
            BulletinBody.Size = new Size(34, 15);
            BulletinBody.TabIndex = 1;
            BulletinBody.Text = "Body";
            // 
            // BulletinCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(BulletinBody);
            Controls.Add(BulletinTitle);
            Name = "BulletinCard";
            Size = new Size(925, 170);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label BulletinTitle;
        private Label BulletinBody;
    }
}
