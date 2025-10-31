namespace Student_Faculty
{
    partial class StudentListCard
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
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            fLayPanStud = new FlowLayoutPanel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(3, 4);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(948, 70);
            panel2.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label8.Location = new Point(768, 17);
            label8.Name = "label8";
            label8.Size = new Size(80, 51);
            label8.TabIndex = 5;
            label8.Text = "Actions";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label6.Location = new Point(490, 17);
            label6.Name = "label6";
            label6.Size = new Size(158, 51);
            label6.TabIndex = 3;
            label6.Text = "Umindanao Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label4.Location = new Point(316, 17);
            label4.Name = "label4";
            label4.Size = new Size(40, 51);
            label4.TabIndex = 1;
            label4.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 9F, FontStyle.Bold);
            label3.Location = new Point(74, 17);
            label3.Name = "label3";
            label3.Size = new Size(130, 51);
            label3.TabIndex = 0;
            label3.Text = "Student Name";
            // 
            // fLayPanStud
            // 
            fLayPanStud.AutoScroll = true;
            fLayPanStud.Location = new Point(3, 81);
            fLayPanStud.Name = "fLayPanStud";
            fLayPanStud.Size = new Size(948, 442);
            fLayPanStud.TabIndex = 2;
            fLayPanStud.Paint += flowLayoutPanel2_Paint;
            // 
            // StudentListCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(fLayPanStud);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StudentListCard";
            Size = new Size(954, 526);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label label8;
        private Label label6;
        private Label label4;
        private Label label3;
        private FlowLayoutPanel fLayPanStud;
    }
}
