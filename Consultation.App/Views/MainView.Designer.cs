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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            sidePanel = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            pictureBox1 = new PictureBox();
            button1 = new Button();
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
            profilePanel = new Panel();
            labelProfileRole = new Label();
            labelProfileName = new Label();
            pictureBoxProfile = new PictureBox();
            settings_icon = new ImageList(components);
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            buttonNotification = new Guna.UI2.WinForms.Guna2CircleButton();
            labelForm = new Label();
            panel1 = new Panel();
            panelContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)sidePanel).BeginInit();
            sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            profilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
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
            sidePanel.Controls.Add(pictureBox1);
            sidePanel.Controls.Add(button1);
            sidePanel.Controls.Add(pictureBoxLogo);
            sidePanel.Controls.Add(label2);
            sidePanel.Controls.Add(buttonSFManagement);
            sidePanel.Controls.Add(buttonConsultation);
            sidePanel.Controls.Add(buttonBulletin);
            sidePanel.Controls.Add(label1);
            sidePanel.Controls.Add(buttonDashboard);
            sidePanel.Controls.Add(profilePanel);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.ForeColor = SystemColors.ControlText;
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(260, 1041);
            sidePanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(44, 939);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 37);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 11F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(30, 939);
            button1.Name = "button1";
            button1.Size = new Size(131, 36);
            button1.TabIndex = 8;
            button1.Text = "              Sign out";
            button1.UseVisualStyleBackColor = false;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = Properties.Icons.LOGO_name__Custom___1_;
            pictureBoxLogo.Location = new Point(6, 25);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(248, 96);
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(24, 424);
            label2.Name = "label2";
            label2.Size = new Size(131, 24);
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
            buttonSFManagement.Location = new Point(30, 464);
            buttonSFManagement.Name = "buttonSFManagement";
            buttonSFManagement.Size = new Size(247, 48);
            buttonSFManagement.TabIndex = 6;
            buttonSFManagement.Text = "   User Management";
            buttonSFManagement.TextAlign = ContentAlignment.MiddleLeft;
            buttonSFManagement.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonSFManagement.UseVisualStyleBackColor = false;
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
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(24, 192);
            label1.Name = "label1";
            label1.Size = new Size(55, 24);
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
            // 
            // dashboard_icon
            // 
            dashboard_icon.ColorDepth = ColorDepth.Depth32Bit;
            dashboard_icon.ImageStream = (ImageListStreamer)resources.GetObject("dashboard_icon.ImageStream");
            dashboard_icon.TransparentColor = Color.Transparent;
            dashboard_icon.Images.SetKeyName(0, "m_dashboard.png");
            dashboard_icon.Images.SetKeyName(1, "m_dashboard_select.png");
            // 
            // profilePanel
            // 
            profilePanel.BackColor = Color.Transparent;
            profilePanel.Controls.Add(labelProfileRole);
            profilePanel.Controls.Add(labelProfileName);
            profilePanel.Controls.Add(pictureBoxProfile);
            profilePanel.Location = new Point(3, 805);
            profilePanel.Name = "profilePanel";
            profilePanel.Size = new Size(260, 95);
            profilePanel.TabIndex = 1;
            // 
            // labelProfileRole
            // 
            labelProfileRole.AutoSize = true;
            labelProfileRole.BackColor = Color.Transparent;
            labelProfileRole.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelProfileRole.Location = new Point(88, 48);
            labelProfileRole.Name = "labelProfileRole";
            labelProfileRole.Size = new Size(39, 18);
            labelProfileRole.TabIndex = 2;
            labelProfileRole.Text = "Role";
            // 
            // labelProfileName
            // 
            labelProfileName.AutoSize = true;
            labelProfileName.BackColor = Color.Transparent;
            labelProfileName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelProfileName.Location = new Point(88, 24);
            labelProfileName.Name = "labelProfileName";
            labelProfileName.Size = new Size(94, 18);
            labelProfileName.TabIndex = 1;
            labelProfileName.Text = "John Name";
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.BackColor = Color.White;
            pictureBoxProfile.Location = new Point(16, 24);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(56, 56);
            pictureBoxProfile.TabIndex = 0;
            pictureBoxProfile.TabStop = false;
            // 
            // settings_icon
            // 
            settings_icon.ColorDepth = ColorDepth.Depth32Bit;
            settings_icon.ImageStream = (ImageListStreamer)resources.GetObject("settings_icon.ImageStream");
            settings_icon.TransparentColor = Color.Transparent;
            settings_icon.Images.SetKeyName(0, "m_settings.png");
            settings_icon.Images.SetKeyName(1, "m_settings_select.png");
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
            buttonNotification.ImageAlign = HorizontalAlignment.Left;
            buttonNotification.ImageOffset = new Point(2, 0);
            buttonNotification.ImageSize = new Size(32, 32);
            buttonNotification.Location = new Point(1560, 25);
            buttonNotification.Name = "buttonNotification";
            buttonNotification.ShadowDecoration.CustomizableEdges = customizableEdges1;
            buttonNotification.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            buttonNotification.Size = new Size(56, 56);
            buttonNotification.TabIndex = 13;
            buttonNotification.Tile = false;
            buttonNotification.UseTransparentBackground = true;
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.BackColor = Color.Transparent;
            labelForm.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelForm.Location = new Point(17, 25);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(197, 37);
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
            IsMdiContainer = true;
            Name = "MainView";
            Text = "UMECA";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)sidePanel).EndInit();
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            profilePanel.ResumeLayout(false);
            profilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
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
        private Label labelProfileRole;
        private Label labelProfileName;
        private PictureBox pictureBoxProfile;
        private ImageList dashboard_icon;
        private ImageList consultation_icon;
        private ImageList bulletin_icon;
        private ImageList settings_icon;
        private ImageList userManagement_icon;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private Label labelForm;
        private Panel panel1;
        private Panel panelContainer;
        private Guna.UI2.WinForms.Guna2CircleButton buttonNotification;
        private PictureBox pictureBox1;
        private Button button1;
    }
}