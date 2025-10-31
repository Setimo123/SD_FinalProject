namespace Consultation.App.Views.Controls.Dashboard.Quick_Actions_Panel
{
    partial class ManageConsultation
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
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(panel1);
            materialCard1.Controls.Add(label2);
            materialCard1.Controls.Add(label1);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(251, 58);
            materialCard1.TabIndex = 0;
            materialCard1.Click += materialCard1_Click;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Icons.schedule__1_;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(18, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(32, 32);
            panel1.TabIndex = 3;
            panel1.Click += materialCard1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(68, 29);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 3;
            label2.Text = "Review appointment";
            label2.Click += materialCard1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter Medium", 11F, FontStyle.Bold);
            label1.Location = new Point(68, 11);
            label1.Name = "label1";
            label1.Size = new Size(164, 18);
            label1.TabIndex = 2;
            label1.Text = "Manage Consultation";
            label1.Click += materialCard1_Click;
            // 
            // ManageConsultation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(materialCard1);
            Name = "ManageConsultation";
            Size = new Size(255, 62);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Label label2;
        private Label label1;
        private Panel panel1;
    }
}
