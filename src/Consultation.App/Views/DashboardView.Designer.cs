namespace Consultation.App
{
    partial class DashboardView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainDashboardUserControl1 = new Consultation.App.Dashboard.MainDashboardUserControl();
            SuspendLayout();
            // 
            // mainDashboardUserControl1
            // 
            mainDashboardUserControl1.BackColor = Color.White;
            mainDashboardUserControl1.Dock = DockStyle.Fill;
            mainDashboardUserControl1.ForeColor = Color.Red;
            mainDashboardUserControl1.Location = new Point(0, 0);
            mainDashboardUserControl1.Name = "mainDashboardUserControl1";
            mainDashboardUserControl1.Size = new Size(1644, 941);
            mainDashboardUserControl1.TabIndex = 0;
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1644, 941);
            Controls.Add(mainDashboardUserControl1);
            DoubleBuffered = true;
            //FormBorderStyle = FormBorderStyle.None;
            Name = "DashboardView";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Dashboard.MainDashboardUserControl mainDashboardUserControl1;
    }
}
