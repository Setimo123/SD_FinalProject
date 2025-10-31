namespace Consultation.App.Views
{
    partial class BulletinView
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
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            panelUnderline = new Panel();
            btnBulletinView = new Guna.UI2.WinForms.Guna2Button();
            btnArchive = new Guna.UI2.WinForms.Guna2Button();
            btnCreateBulletin = new Guna.UI2.WinForms.Guna2Button();
            panelHeader = new MaterialSkin.Controls.MaterialCard();
            lblBulletinHeader = new Label();
            flpBulletinList = new FlowLayoutPanel();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            materialCard1.SuspendLayout();
            panelHeader.SuspendLayout();
            materialCard2.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnRefresh);
            materialCard1.Controls.Add(panelUnderline);
            materialCard1.Controls.Add(btnBulletinView);
            materialCard1.Controls.Add(btnArchive);
            materialCard1.Controls.Add(btnCreateBulletin);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(21, 15);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1600, 80);
            materialCard1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BorderColor = Color.Transparent;
            btnRefresh.BorderRadius = 6;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.CustomizableEdges = customizableEdges1;
            btnRefresh.DisabledState.BorderColor = Color.DarkGray;
            btnRefresh.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRefresh.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRefresh.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRefresh.FillColor = Color.FromArgb(190, 0, 2);
            btnRefresh.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Image = Properties.Icons.refresh;
            btnRefresh.ImageOffset = new Point(-2, 0);
            btnRefresh.ImageSize = new Size(14, 14);
            btnRefresh.Location = new Point(1319, 22);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnRefresh.Size = new Size(97, 36);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panelUnderline
            // 
            panelUnderline.BackColor = Color.FromArgb(190, 0, 2);
            panelUnderline.Location = new Point(315, 47);
            panelUnderline.Name = "panelUnderline";
            panelUnderline.Size = new Size(190, 4);
            panelUnderline.TabIndex = 6;
            // 
            // btnBulletinView
            // 
            btnBulletinView.Cursor = Cursors.Hand;
            btnBulletinView.CustomizableEdges = customizableEdges3;
            btnBulletinView.DisabledState.BorderColor = Color.DarkGray;
            btnBulletinView.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBulletinView.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBulletinView.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBulletinView.FillColor = Color.White;
            btnBulletinView.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBulletinView.ForeColor = Color.FromArgb(190, 0, 2);
            btnBulletinView.Location = new Point(12, 12);
            btnBulletinView.Name = "btnBulletinView";
            btnBulletinView.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnBulletinView.Size = new Size(136, 56);
            btnBulletinView.TabIndex = 5;
            btnBulletinView.Text = "Bulletin View";
            btnBulletinView.Click += btnBulletinView_Click;
            // 
            // btnArchive
            // 
            btnArchive.BackColor = Color.White;
            btnArchive.Cursor = Cursors.Hand;
            btnArchive.CustomizableEdges = customizableEdges5;
            btnArchive.DisabledState.BorderColor = Color.DarkGray;
            btnArchive.DisabledState.CustomBorderColor = Color.DarkGray;
            btnArchive.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnArchive.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnArchive.FillColor = Color.White;
            btnArchive.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnArchive.ForeColor = Color.FromArgb(86, 93, 109);
            btnArchive.Location = new Point(154, 12);
            btnArchive.Name = "btnArchive";
            btnArchive.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnArchive.Size = new Size(136, 56);
            btnArchive.TabIndex = 4;
            btnArchive.Text = "Archive";
            btnArchive.Click += btnArchive_Click;
            // 
            // btnCreateBulletin
            // 
            btnCreateBulletin.BorderColor = Color.Transparent;
            btnCreateBulletin.BorderRadius = 6;
            btnCreateBulletin.Cursor = Cursors.Hand;
            btnCreateBulletin.CustomizableEdges = customizableEdges7;
            btnCreateBulletin.DisabledState.BorderColor = Color.DarkGray;
            btnCreateBulletin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCreateBulletin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCreateBulletin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCreateBulletin.FillColor = Color.FromArgb(190, 0, 2);
            btnCreateBulletin.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreateBulletin.ForeColor = Color.White;
            btnCreateBulletin.Image = Properties.Icons.add;
            btnCreateBulletin.ImageOffset = new Point(-2, 0);
            btnCreateBulletin.ImageSize = new Size(14, 14);
            btnCreateBulletin.Location = new Point(1431, 22);
            btnCreateBulletin.Name = "btnCreateBulletin";
            btnCreateBulletin.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCreateBulletin.Size = new Size(143, 36);
            btnCreateBulletin.TabIndex = 3;
            btnCreateBulletin.Text = "Create Bulletin";
            btnCreateBulletin.Click += btnCreateBulletin_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(255, 255, 255);
            panelHeader.Controls.Add(lblBulletinHeader);
            panelHeader.Depth = 0;
            panelHeader.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelHeader.Location = new Point(88, 123);
            panelHeader.Margin = new Padding(14);
            panelHeader.MouseState = MaterialSkin.MouseState.HOVER;
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(14);
            panelHeader.Size = new Size(1460, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblBulletinHeader
            // 
            lblBulletinHeader.AutoSize = true;
            lblBulletinHeader.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBulletinHeader.ForeColor = Color.FromArgb(23, 26, 31);
            lblBulletinHeader.Location = new Point(17, 17);
            lblBulletinHeader.Name = "lblBulletinHeader";
            lblBulletinHeader.Size = new Size(194, 29);
            lblBulletinHeader.TabIndex = 0;
            lblBulletinHeader.Text = "Bulletin Header";
            // 
            // flpBulletinList
            // 
            flpBulletinList.AutoScroll = true;
            flpBulletinList.Location = new Point(10, 4);
            flpBulletinList.Name = "flpBulletinList";
            flpBulletinList.Size = new Size(1440, 690);
            flpBulletinList.TabIndex = 1;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(flpBulletinList);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(88, 195);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(1460, 724);
            materialCard2.TabIndex = 0;
            // 
            // BulletinView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1642, 941);
            Controls.Add(panelHeader);
            Controls.Add(materialCard1);
            Controls.Add(materialCard2);
            DoubleBuffered = true;
            //FormBorderStyle = FormBorderStyle.None;
            Name = "BulletinView";
            Text = "BulletinsForm";
            materialCard1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            materialCard2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Guna.UI2.WinForms.Guna2Button btnCreateBulletin;
        private Guna.UI2.WinForms.Guna2Button btnBulletinView;
        private Guna.UI2.WinForms.Guna2Button btnArchive;
        private Panel panelUnderline;
        private Label lblBulletinHeader;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private FlowLayoutPanel flpBulletinList;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialCard panelHeader;
    }
}