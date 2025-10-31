namespace Consultation.App.Views
{
    partial class NotificationView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel2 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            buttonClose = new Button();
            label1 = new Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            panel2.SuspendLayout();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Controls.Add(materialCard1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(450, 545);
            panel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(34, 67);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(383, 466);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(buttonClose);
            materialCard1.Controls.Add(label1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Top;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(450, 50);
            materialCard1.TabIndex = 0;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.Transparent;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.ForeColor = Color.Transparent;
            buttonClose.Image = Properties.Icons.close;
            buttonClose.Location = new Point(393, 3);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(45, 45);
            buttonClose.TabIndex = 1;
            buttonClose.TextAlign = ContentAlignment.MiddleLeft;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 14);
            label1.Name = "label1";
            label1.Size = new Size(164, 23);
            label1.TabIndex = 0;
            label1.Text = "Recent Notification ";
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 12;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // NotificationView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 545);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NotificationView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NotificationView";
            panel2.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonClose;
    }
}