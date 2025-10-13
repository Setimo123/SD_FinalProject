namespace Consultation.App.Views
{
    partial class MainView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            sidePanel = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            profilePanel = new Panel();
            userole = new Label();
            username = new Label();
            pictureBoxProfile = new PictureBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            pictureBoxLogo = new PictureBox();
            label2 = new Label();
            buttonSFManagement = new Button();
            userManagement_icon = new ImageList(components);
            buttonConsultation = new Button();
            consultation_icon = new ImageList(components);
            buttonBulletin = new Button();
            bulletin_icon = new ImageList(components);
            label1 = new Label();
            buttonDashboard = new Button();
            dashboard_icon = new ImageList(components);
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            buttonNotification = new Guna.UI2.WinForms.Guna2CircleButton();
            labelForm = new Label();
            panel1 = new Panel();
            panelContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)sidePanel).BeginInit();
            sidePanel.SuspendLayout();
            profilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            materialCard2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // sidePanel
            // 
            sidePanel.BackColor = SystemColors.ActiveCaption;
            sidePanel.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, Color.FromArgb(117, 7, 39), Color.FromArgb(197, 62, 63));
            sidePanel.Border3DStyle = Border3DStyle.Flat;
            sidePanel.BorderStyle = BorderStyle.None;
            sidePanel.Controls.Add(profilePanel);
            sidePanel.Controls.Add(guna2Button1);
            sidePanel.Controls.Add(pictureBoxLogo);
            sidePanel.Controls.Add(label2);
            sidePanel.Controls.Add(buttonSFManagement);
            sidePanel.Controls.Add(buttonConsultation);
            sidePanel.Controls.Add(buttonBulletin);
            sidePanel.Controls.Add(label1);
            sidePanel.Controls.Add(buttonDashboard);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.ForeColor = SystemColors.ControlText;
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(260, 1041);
            sidePanel.TabIndex = 0;
            sidePanel.Paint += sidePanel_Paint;
            // 
            // profilePanel
            // 
            profilePanel.Anchor = AnchorStyles.None;
            profilePanel.BackColor = Color.Transparent;
            profilePanel.BackgroundImageLayout = ImageLayout.None;
            profilePanel.Controls.Add(userole);
            profilePanel.Controls.Add(username);
            profilePanel.Controls.Add(pictureBoxProfile);
            profilePanel.ForeColor = Color.Transparent;
            profilePanel.Location = new Point(0, 898);
            profilePanel.Margin = new Padding(0);
            profilePanel.Name = "profilePanel";
            profilePanel.Size = new Size(260, 63);
            profilePanel.TabIndex = 1;
            profilePanel.Paint += profilePanel_Paint;
            // 
            // userole
            // 
            userole.AutoSize = true;
            userole.BackColor = Color.Transparent;
            userole.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userole.ForeColor = Color.GhostWhite;
            userole.Location = new Point(58, 34);
            userole.Name = "userole";
            userole.Size = new Size(39, 18);
            userole.TabIndex = 2;
            userole.Text = "Role";
            userole.Click += labelProfileRole_Click;
            // 
            // username
            // 
            username.AutoSize = true;
            username.BackColor = Color.Transparent;
            username.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            username.ForeColor = Color.GhostWhite;
            username.Location = new Point(58, 12);
            username.Name = "username";
            username.Size = new Size(99, 20);
            username.TabIndex = 1;
            username.Text = "John Name";
            username.Click += labelProfileName_Click;
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.BackColor = Color.Transparent;
            pictureBoxProfile.Image = Properties.Icons.user1;
            pictureBoxProfile.Location = new Point(8, 12);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(40, 40);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProfile.TabIndex = 0;
            pictureBoxProfile.TabStop = false;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BackgroundImageLayout = ImageLayout.None;
            guna2Button1.BorderRadius = 5;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Transparent;
            guna2Button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.GhostWhite;
            guna2Button1.Image = Properties.Icons.arrowout;
            guna2Button1.ImageSize = new Size(25, 25);
            guna2Button1.Location = new Point(61, 989);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(125, 40);
            guna2Button1.TabIndex = 10;
            guna2Button1.Text = "Sign out";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.BackgroundImageLayout = ImageLayout.None;
            pictureBoxLogo.Image = Properties.Icons.LOGO_FINAL;
            pictureBoxLogo.Location = new Point(-12, -1);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(283, 153);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Click += pictureBoxLogo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Archivo ExtraBold", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(24, 424);
            label2.Name = "label2";
            label2.Size = new Size(139, 29);
            label2.TabIndex = 7;
            label2.Text = "Management";
            // 
            // buttonSFManagement
            // 
            buttonSFManagement.BackColor = Color.Transparent;
            buttonSFManagement.FlatAppearance.BorderSize = 0;
            buttonSFManagement.FlatStyle = FlatStyle.Flat;
            buttonSFManagement.Font = new Font("Microsoft Sans Serif", 12F);
            buttonSFManagement.ForeColor = SystemColors.ControlLightLight;
            buttonSFManagement.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSFManagement.ImageIndex = 0;
            buttonSFManagement.ImageList = userManagement_icon;
            buttonSFManagement.Location = new Point(30, 469);
            buttonSFManagement.Name = "buttonSFManagement";
            buttonSFManagement.Size = new Size(247, 48);
            buttonSFManagement.TabIndex = 6;
            buttonSFManagement.Text = "   User Management";
            buttonSFManagement.TextAlign = ContentAlignment.MiddleLeft;
            buttonSFManagement.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonSFManagement.UseVisualStyleBackColor = false;
            buttonSFManagement.Click += buttonSFManagement_Click;
            // 
            // userManagement_icon
            // 
            userManagement_icon.ColorDepth = ColorDepth.Depth32Bit;
            userManagement_icon.ImageStream = (ImageListStreamer)resources.GetObject("userManagement_icon.ImageStream");
            userManagement_icon.TransparentColor = Color.Transparent;
            userManagement_icon.Images.SetKeyName(0, "m_user.png");
            userManagement_icon.Images.SetKeyName(1, "m_user_select.png");
            // 
            // buttonConsultation
            // 
            buttonConsultation.BackColor = Color.Transparent;
            buttonConsultation.FlatAppearance.BorderSize = 0;
            buttonConsultation.FlatStyle = FlatStyle.Flat;
            buttonConsultation.Font = new Font("Microsoft Sans Serif", 12F);
            buttonConsultation.ForeColor = SystemColors.ControlLightLight;
            buttonConsultation.ImageAlign = ContentAlignment.MiddleLeft;
            buttonConsultation.ImageIndex = 0;
            buttonConsultation.ImageList = consultation_icon;
            buttonConsultation.Location = new Point(30, 328);
            buttonConsultation.Name = "buttonConsultation";
            buttonConsultation.Size = new Size(247, 48);
            buttonConsultation.TabIndex = 5;
            buttonConsultation.Text = "   Consultation";
            buttonConsultation.TextAlign = ContentAlignment.MiddleLeft;
            buttonConsultation.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonConsultation.UseVisualStyleBackColor = false;
            // 
            // consultation_icon
            // 
            consultation_icon.ColorDepth = ColorDepth.Depth32Bit;
            consultation_icon.ImageStream = (ImageListStreamer)resources.GetObject("consultation_icon.ImageStream");
            consultation_icon.TransparentColor = Color.Transparent;
            consultation_icon.Images.SetKeyName(0, "m_consult.png");
            consultation_icon.Images.SetKeyName(1, "m_consult_select.png");
            // 
            // buttonBulletin
            // 
            buttonBulletin.BackColor = Color.Transparent;
            buttonBulletin.FlatAppearance.BorderSize = 0;
            buttonBulletin.FlatStyle = FlatStyle.Flat;
            buttonBulletin.Font = new Font("Microsoft Sans Serif", 12F);
            buttonBulletin.ForeColor = SystemColors.ControlLightLight;
            buttonBulletin.ImageAlign = ContentAlignment.MiddleLeft;
            buttonBulletin.ImageIndex = 0;
            buttonBulletin.ImageList = bulletin_icon;
            buttonBulletin.Location = new Point(30, 280);
            buttonBulletin.Name = "buttonBulletin";
            buttonBulletin.Size = new Size(247, 42);
            buttonBulletin.TabIndex = 4;
            buttonBulletin.Text = "   Bulletin";
            buttonBulletin.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonBulletin.UseVisualStyleBackColor = false;
            // 
            // bulletin_icon
            // 
            bulletin_icon.ColorDepth = ColorDepth.Depth32Bit;
            bulletin_icon.ImageStream = (ImageListStreamer)resources.GetObject("bulletin_icon.ImageStream");
            bulletin_icon.TransparentColor = Color.Transparent;
            bulletin_icon.Images.SetKeyName(0, "m_bulletin.png");
            bulletin_icon.Images.SetKeyName(1, "m_bulletin-select.png");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Archivo ExtraBold", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(24, 192);
            label1.Name = "label1";
            label1.Size = new Size(59, 29);
            label1.TabIndex = 3;
            label1.Text = "Main";
            // 
            // buttonDashboard
            // 
            buttonDashboard.BackColor = Color.Transparent;
            buttonDashboard.Cursor = Cursors.Hand;
            buttonDashboard.FlatAppearance.BorderSize = 0;
            buttonDashboard.FlatStyle = FlatStyle.Flat;
            buttonDashboard.Font = new Font("Microsoft Sans Serif", 12F);
            buttonDashboard.ForeColor = SystemColors.ControlLightLight;
            buttonDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDashboard.ImageIndex = 0;
            buttonDashboard.ImageList = dashboard_icon;
            buttonDashboard.Location = new Point(30, 232);
            buttonDashboard.Name = "buttonDashboard";
            buttonDashboard.Size = new Size(247, 42);
            buttonDashboard.TabIndex = 2;
            buttonDashboard.Text = "   Dashboard";
            buttonDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDashboard.UseVisualStyleBackColor = false;
            buttonDashboard.Click += buttonDashboard_Click;
            // 
            // dashboard_icon
            // 
            dashboard_icon.ColorDepth = ColorDepth.Depth32Bit;
            dashboard_icon.ImageStream = (ImageListStreamer)resources.GetObject("dashboard_icon.ImageStream");
            dashboard_icon.TransparentColor = Color.Transparent;
            dashboard_icon.Images.SetKeyName(0, "m_dashboard.png");
            dashboard_icon.Images.SetKeyName(1, "m_dashboard_select.png");
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(buttonNotification);
            materialCard2.Controls.Add(labelForm);
            materialCard2.Depth = 0;
            materialCard2.Dock = DockStyle.Top;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(0, 0);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(1644, 100);
            materialCard2.TabIndex = 7;
            // 
            // buttonNotification
            // 
            buttonNotification.Anchor = AnchorStyles.None;
            buttonNotification.BackColor = Color.Transparent;
            buttonNotification.BackgroundImageLayout = ImageLayout.Center;
            buttonNotification.Cursor = Cursors.Hand;
            buttonNotification.DisabledState.BorderColor = Color.DarkGray;
            buttonNotification.DisabledState.CustomBorderColor = Color.DarkGray;
            buttonNotification.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            buttonNotification.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            buttonNotification.FillColor = Color.FromArgb(199, 38, 39);
            buttonNotification.Font = new Font("Segoe UI", 9F);
            buttonNotification.ForeColor = Color.White;
            buttonNotification.Image = Properties.Icons.notification;
            buttonNotification.ImageSize = new Size(25, 25);
            buttonNotification.Location = new Point(1550, 33);
            buttonNotification.Name = "buttonNotification";
            buttonNotification.ShadowDecoration.CustomizableEdges = customizableEdges3;
            buttonNotification.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            buttonNotification.Size = new Size(40, 40);
            buttonNotification.TabIndex = 13;
            buttonNotification.Tile = false;
            buttonNotification.UseTransparentBackground = true;
            buttonNotification.Click += buttonNotification_Click;
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.BackColor = Color.Transparent;
            labelForm.Font = new Font("Archivo ExtraBold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelForm.Location = new Point(17, 25);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(204, 48);
            labelForm.TabIndex = 12;
            labelForm.Text = "Form Name";
            // 
            // panel1
            // 
            panel1.Controls.Add(materialCard2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(260, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1644, 105);
            panel1.TabIndex = 10;
            // 
            // panelContainer
            // 
            panelContainer.BorderStyle = BorderStyle.FixedSingle;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(260, 105);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1644, 936);
            panelContainer.TabIndex = 11;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panelContainer);
            Controls.Add(panel1);
            Controls.Add(sidePanel);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Name = "MainView";
            Text = "UMECA";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)sidePanel).EndInit();
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            profilePanel.ResumeLayout(false);
            profilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.GradientPanel sidePanel;
        private Panel profilePanel;
        private PictureBox pictureBoxLogo;
        private Button buttonDashboard;
        private Label label1;
        private Button buttonConsultation;
        private Button buttonBulletin;
        private Label label2;
        private Button buttonSFManagement;
        private Label userole;
        private Label username;
        private PictureBox pictureBoxProfile;
        private ImageList dashboard_icon;
        private ImageList consultation_icon;
        private ImageList bulletin_icon;
        private ImageList userManagement_icon;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private Label labelForm;
        private Panel panel1;
        private Panel panelContainer;
        private Guna.UI2.WinForms.Guna2CircleButton buttonNotification;
        public Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}