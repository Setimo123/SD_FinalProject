namespace Consultation.App.Views
{
    partial class LogInView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label2 = new Label();
            label1 = new Label();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            dockingClientPanel1 = new Syncfusion.Windows.Forms.Tools.DockingClientPanel();
            showpass = new Guna.UI2.WinForms.Guna2CheckBox();
            Emtextbox = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Login_button = new Guna.UI2.WinForms.Guna2Button();
            PassTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            dockingClientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Archivo SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.GhostWhite;
            label2.Location = new Point(1202, 527);
            label2.Name = "label2";
            label2.Size = new Size(118, 32);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Archivo SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.GhostWhite;
            label1.Location = new Point(1202, 410);
            label1.Name = "label1";
            label1.Size = new Size(282, 32);
            label1.TabIndex = 1;
            label1.Text = "Umindanao E-mail Address:";
            label1.Click += label1_Click;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.Anchor = AnchorStyles.None;
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.BackgroundImage = Properties.Icons.LOGO_FINAL;
            guna2PictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            guna2PictureBox1.CustomizableEdges = customizableEdges1;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(35, 84);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox1.Size = new Size(1090, 889);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 16;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.Click += guna2PictureBox1_Click;
            // 
            // dockingClientPanel1
            // 
            dockingClientPanel1.BackColor = Color.Transparent;
            dockingClientPanel1.BackgroundImage = Properties.Icons.User_Name;
            dockingClientPanel1.Controls.Add(showpass);
            dockingClientPanel1.Controls.Add(Emtextbox);
            dockingClientPanel1.Controls.Add(guna2HtmlLabel1);
            dockingClientPanel1.Controls.Add(Login_button);
            dockingClientPanel1.Controls.Add(guna2PictureBox1);
            dockingClientPanel1.Controls.Add(label1);
            dockingClientPanel1.Controls.Add(label2);
            dockingClientPanel1.Controls.Add(PassTextBox);
            dockingClientPanel1.Location = new Point(1, 1);
            dockingClientPanel1.Name = "dockingClientPanel1";
            dockingClientPanel1.Size = new Size(1940, 1080);
            dockingClientPanel1.TabIndex = 0;
            dockingClientPanel1.Paint += dockingClientPanel1_Paint;
            // 
            // showpass
            // 
            showpass.AutoSize = true;
            showpass.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            showpass.CheckedState.BorderRadius = 0;
            showpass.CheckedState.BorderThickness = 0;
            showpass.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            showpass.ForeColor = Color.White;
            showpass.Location = new Point(1546, 537);
            showpass.Name = "showpass";
            showpass.Size = new Size(108, 19);
            showpass.TabIndex = 21;
            showpass.Text = "Show Password";
            showpass.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            showpass.UncheckedState.BorderRadius = 0;
            showpass.UncheckedState.BorderThickness = 0;
            showpass.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            showpass.CheckedChanged += showpass_CheckedChanged;
            // 
            // Emtextbox
            // 
            Emtextbox.BorderColor = Color.Transparent;
            Emtextbox.CustomizableEdges = customizableEdges3;
            Emtextbox.DefaultText = "";
            Emtextbox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            Emtextbox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            Emtextbox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            Emtextbox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            Emtextbox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Emtextbox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Emtextbox.ForeColor = Color.Black;
            Emtextbox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            Emtextbox.Location = new Point(1202, 446);
            Emtextbox.Margin = new Padding(3, 4, 3, 4);
            Emtextbox.Name = "Emtextbox";
            Emtextbox.PlaceholderForeColor = Color.DimGray;
            Emtextbox.PlaceholderText = "Input Email";
            Emtextbox.SelectedText = "";
            Emtextbox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Emtextbox.Size = new Size(454, 47);
            Emtextbox.TabIndex = 20;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(43, 92);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(97, 17);
            guna2HtmlLabel1.TabIndex = 19;
            guna2HtmlLabel1.Text = "guna2HtmlLabel1";
            // 
            // Login_button
            // 
            Login_button.BorderRadius = 10;
            Login_button.CustomizableEdges = customizableEdges5;
            Login_button.DisabledState.BorderColor = Color.DarkGray;
            Login_button.DisabledState.CustomBorderColor = Color.DarkGray;
            Login_button.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Login_button.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Login_button.FillColor = Color.DarkRed;
            Login_button.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Login_button.ForeColor = Color.White;
            Login_button.Image = Properties.Icons.arrowin;
            Login_button.ImageSize = new Size(25, 25);
            Login_button.Location = new Point(1320, 657);
            Login_button.Name = "Login_button";
            Login_button.ShadowDecoration.CustomizableEdges = customizableEdges6;
            Login_button.Size = new Size(200, 45);
            Login_button.TabIndex = 17;
            Login_button.Text = "Log In";
            // 
            // PassTextBox
            // 
            PassTextBox.BorderColor = Color.Transparent;
            PassTextBox.CustomizableEdges = customizableEdges7;
            PassTextBox.DefaultText = "";
            PassTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            PassTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            PassTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            PassTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            PassTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            PassTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PassTextBox.ForeColor = Color.Black;
            PassTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            PassTextBox.Location = new Point(1202, 563);
            PassTextBox.Margin = new Padding(3, 4, 3, 4);
            PassTextBox.Name = "PassTextBox";
            PassTextBox.PlaceholderForeColor = Color.DimGray;
            PassTextBox.PlaceholderText = "Input password";
            PassTextBox.SelectedText = "";
            PassTextBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            PassTextBox.Size = new Size(454, 47);
            PassTextBox.TabIndex = 18;
            // 
            // LogInView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1924, 1041);
            Controls.Add(dockingClientPanel1);
            Name = "LogInView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogIn";
            WindowState = FormWindowState.Maximized;
            Load += LogIn_Load;
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            dockingClientPanel1.ResumeLayout(false);
            dockingClientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Syncfusion.Windows.Forms.Tools.DockingClientPanel dockingClientPanel1;
        private Guna.UI2.WinForms.Guna2Button Login_button;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox PassTextBox;
        private Guna.UI2.WinForms.Guna2TextBox Emtextbox;
        private Guna.UI2.WinForms.Guna2CheckBox showpass;
    }
}