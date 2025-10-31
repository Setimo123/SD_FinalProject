namespace Student_Faculty
{
    partial class FacultyListCard
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
            panel2 = new Panel();
            label8 = new Label();
            label5 = new Label();
            lblIDFM = new Label();
            label3 = new Label();
            fLayPanFac = new FlowLayoutPanel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(lblIDFM);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(3, 4);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(947, 70);
            panel2.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label8.Location = new Point(769, 17);
            label8.Name = "label8";
            label8.Size = new Size(80, 51);
            label8.TabIndex = 6;
            label8.Text = "Actions";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label5.Location = new Point(489, 17);
            label5.Name = "label5";
            label5.Size = new Size(134, 51);
            label5.TabIndex = 2;
            label5.Text = " Email Address\r\n";
            // 
            // lblIDFM
            // 
            lblIDFM.AutoSize = true;
            lblIDFM.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            lblIDFM.Location = new Point(311, 17);
            lblIDFM.Name = "lblIDFM";
            lblIDFM.Size = new Size(40, 51);
            lblIDFM.TabIndex = 1;
            lblIDFM.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label3.Location = new Point(76, 17);
            label3.Name = "label3";
            label3.Size = new Size(126, 51);
            label3.TabIndex = 0;
            label3.Text = "Faculty Name\r\n";
            // 
            // fLayPanFac
            // 
            fLayPanFac.AutoScroll = true;
            fLayPanFac.Location = new Point(3, 81);
            fLayPanFac.Name = "fLayPanFac";
            fLayPanFac.Size = new Size(948, 442);
            fLayPanFac.TabIndex = 3;
            // 
            // FacultyListCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(fLayPanFac);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FacultyListCard";
            Size = new Size(950, 526);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label lblIDFM;
        private Label label3;
        private Label label5;
        private FlowLayoutPanel fLayPanFac;
        private Label label8;
    }
}
