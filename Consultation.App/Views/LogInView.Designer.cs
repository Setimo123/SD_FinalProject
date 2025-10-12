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
            ShowPassButton = new Button();
            label2 = new Label();
            PasswordTextBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            EmailTextBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label1 = new Label();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            dockingClientPanel1 = new Syncfusion.Windows.Forms.Tools.DockingClientPanel();
            Login_button = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)PasswordTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmailTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            dockingClientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // ShowPassButton
            // 
            ShowPassButton.FlatStyle = FlatStyle.Flat;
            ShowPassButton.Image = Properties.Icons.Untitled_design;
            ShowPassButton.Location = new Point(1620, 511);
            ShowPassButton.Name = "ShowPassButton";
            ShowPassButton.Size = new Size(40, 30);
            ShowPassButton.TabIndex = 15;
            ShowPassButton.UseVisualStyleBackColor = true;
            ShowPassButton.Click += ShowPassButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Archivo SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.GhostWhite;
            label2.Location = new Point(1202, 475);
            label2.Name = "label2";
            label2.Size = new Size(118, 32);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.BackColor = Color.Transparent;
            PasswordTextBox.BeforeTouchSize = new Size(455, 32);
            PasswordTextBox.Border3DStyle = Border3DStyle.Flat;
            PasswordTextBox.Font = new Font("Microsoft Sans Serif", 14.25F);
            PasswordTextBox.Location = new Point(1206, 510);
            PasswordTextBox.Multiline = true;
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '●';
            PasswordTextBox.PlaceholderText = "Input Password";
            PasswordTextBox.Size = new Size(455, 32);
            PasswordTextBox.TabIndex = 2;
            PasswordTextBox.TextChanged += PasswordTextBoxV2_TextChanged;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Anchor = AnchorStyles.None;
            EmailTextBox.BackColor = Color.Transparent;
            EmailTextBox.BeforeTouchSize = new Size(455, 32);
            EmailTextBox.Border3DStyle = Border3DStyle.Flat;
            EmailTextBox.BorderColor = Color.Transparent;
            EmailTextBox.Cursor = Cursors.Cross;
            EmailTextBox.Font = new Font("Microsoft Sans Serif", 14.25F);
            EmailTextBox.Location = new Point(1205, 420);
            EmailTextBox.Margin = new Padding(5);
            EmailTextBox.MinimumSize = new Size(24, 20);
            EmailTextBox.Multiline = true;
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.PlaceholderText = "Input Email";
            EmailTextBox.Size = new Size(455, 32);
            EmailTextBox.TabIndex = 0;
            EmailTextBox.ThemeStyle.BackColor = Color.WhiteSmoke;
            EmailTextBox.ThemeStyle.CornerRadius = 0;
            EmailTextBox.TextChanged += SignInTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Archivo SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.GhostWhite;
            label1.Location = new Point(1199, 385);
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
            dockingClientPanel1.Controls.Add(Login_button);
            dockingClientPanel1.Controls.Add(guna2PictureBox1);
            dockingClientPanel1.Controls.Add(ShowPassButton);
            dockingClientPanel1.Controls.Add(label1);
            dockingClientPanel1.Controls.Add(EmailTextBox);
            dockingClientPanel1.Controls.Add(label2);
            dockingClientPanel1.Controls.Add(PasswordTextBox);
            dockingClientPanel1.Location = new Point(1, 1);
            dockingClientPanel1.Name = "dockingClientPanel1";
            dockingClientPanel1.Size = new Size(1940, 1080);
            dockingClientPanel1.TabIndex = 0;
            dockingClientPanel1.Paint += dockingClientPanel1_Paint;
            // 
            // Login_button
            // 
            Login_button.BorderRadius = 10;
            Login_button.CustomizableEdges = customizableEdges3;
            Login_button.DisabledState.BorderColor = Color.DarkGray;
            Login_button.DisabledState.CustomBorderColor = Color.DarkGray;
            Login_button.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Login_button.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Login_button.FillColor = Color.DarkRed;
            Login_button.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Login_button.ForeColor = Color.White;
            Login_button.Image = Properties.Icons.arrowin;
            Login_button.ImageSize = new Size(25, 25);
            Login_button.Location = new Point(1332, 590);
            Login_button.Name = "Login_button";
            Login_button.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Login_button.Size = new Size(200, 45);
            Login_button.TabIndex = 17;
            Login_button.Text = "Log In";
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
            ((System.ComponentModel.ISupportInitialize)PasswordTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmailTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            dockingClientPanel1.ResumeLayout(false);
            dockingClientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Button ShowPassButton;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt PasswordTextBox;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt EmailTextBox;
        private Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Syncfusion.Windows.Forms.Tools.DockingClientPanel dockingClientPanel1;
        private Guna.UI2.WinForms.Guna2Button Login_button;
    }
}