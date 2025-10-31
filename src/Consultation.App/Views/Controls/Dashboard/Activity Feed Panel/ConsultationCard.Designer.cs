namespace Consultation.App.Dashboard.Activity_Feed_Panel
{
    partial class ConsultationCard
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
            ConsultationTitle = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ConsultationBody = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            SuspendLayout();
            // 
            // ConsultationTitle
            // 
            ConsultationTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ConsultationTitle.Location = new Point(36, 25);
            ConsultationTitle.Name = "ConsultationTitle";
            ConsultationTitle.Size = new Size(32, 15);
            ConsultationTitle.TabIndex = 0;
            ConsultationTitle.Text = "Title";
            // 
            // ConsultationBody
            // 
            ConsultationBody.Location = new Point(36, 58);
            ConsultationBody.Name = "ConsultationBody";
            ConsultationBody.Size = new Size(34, 15);
            ConsultationBody.TabIndex = 1;
            ConsultationBody.Text = "Body";
            // 
            // ConsultationCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(ConsultationBody);
            Controls.Add(ConsultationTitle);
            Name = "ConsultationCard";
            Size = new Size(925, 170);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel ConsultationTitle;
        private Syncfusion.Windows.Forms.Tools.AutoLabel ConsultationBody;
    }
}
