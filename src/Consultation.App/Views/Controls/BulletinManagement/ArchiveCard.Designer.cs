namespace Consultation.App.Views.Controls.BulletinManagement
{
    partial class ArchiveCard
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveCard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tagStatus = new Guna.UI2.WinForms.Guna2Button();
            btnMore = new Guna.UI2.WinForms.Guna2Button();
            txtContent = new RichTextBox();
            lblTitle = new Label();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            flpTags = new FlowLayoutPanel();
            tagDate = new Guna.UI2.WinForms.Guna2Button();
            tagId = new Guna.UI2.WinForms.Guna2Button();
            tagAuthor = new Guna.UI2.WinForms.Guna2Button();
            tagAttachments = new Guna.UI2.WinForms.Guna2Button();
            materialCard1.SuspendLayout();
            flpTags.SuspendLayout();
            SuspendLayout();
            // 
            // tagStatus
            // 
            tagStatus.BackColor = Color.White;
            tagStatus.BorderColor = Color.Transparent;
            tagStatus.BorderRadius = 12;
            tagStatus.CustomizableEdges = customizableEdges1;
            tagStatus.DisabledState.BorderColor = Color.DarkGray;
            tagStatus.DisabledState.CustomBorderColor = Color.DarkGray;
            tagStatus.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            tagStatus.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            tagStatus.FillColor = Color.FromArgb(238, 253, 243);
            tagStatus.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tagStatus.ForeColor = Color.FromArgb(17, 123, 52);
            tagStatus.ImageSize = new Size(16, 16);
            tagStatus.Location = new Point(1232, 26);
            tagStatus.Name = "tagStatus";
            tagStatus.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tagStatus.Size = new Size(100, 32);
            tagStatus.TabIndex = 38;
            tagStatus.Text = "Published";
            // 
            // btnMore
            // 
            btnMore.Cursor = Cursors.Hand;
            btnMore.CustomizableEdges = customizableEdges3;
            btnMore.DisabledState.BorderColor = Color.DarkGray;
            btnMore.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMore.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMore.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMore.FillColor = Color.Transparent;
            btnMore.Font = new Font("Segoe UI", 9F);
            btnMore.ForeColor = Color.White;
            btnMore.Image = Properties.Icons.more;
            btnMore.ImageSize = new Size(24, 6);
            btnMore.Location = new Point(1338, 26);
            btnMore.Name = "btnMore";
            btnMore.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnMore.Size = new Size(32, 32);
            btnMore.TabIndex = 37;
            btnMore.Click += btnMore_Click;
            // 
            // txtContent
            // 
            txtContent.BackColor = Color.White;
            txtContent.BorderStyle = BorderStyle.None;
            txtContent.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContent.ForeColor = Color.FromArgb(23, 26, 31);
            txtContent.Location = new Point(33, 75);
            txtContent.Name = "txtContent";
            txtContent.ReadOnly = true;
            txtContent.ScrollBars = RichTextBoxScrollBars.None;
            txtContent.Size = new Size(1270, 42);
            txtContent.TabIndex = 36;
            txtContent.Text = resources.GetString("txtContent.Text");
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(23, 26, 31);
            lblTitle.Location = new Point(28, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(117, 24);
            lblTitle.TabIndex = 35;
            lblTitle.Text = "Skibidi Rizz";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(flpTags);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(10, 7);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1380, 180);
            materialCard1.TabIndex = 39;
            // 
            // flpTags
            // 
            flpTags.AutoSize = true;
            flpTags.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpTags.Controls.Add(tagDate);
            flpTags.Controls.Add(tagId);
            flpTags.Controls.Add(tagAuthor);
            flpTags.Controls.Add(tagAttachments);
            flpTags.Location = new Point(23, 127);
            flpTags.Name = "flpTags";
            flpTags.Size = new Size(441, 31);
            flpTags.TabIndex = 0;
            // 
            // tagDate
            // 
            tagDate.BackColor = Color.White;
            tagDate.BorderRadius = 12;
            tagDate.CustomizableEdges = customizableEdges5;
            tagDate.DefaultAutoSize = true;
            tagDate.DisabledState.BorderColor = Color.DarkGray;
            tagDate.DisabledState.CustomBorderColor = Color.DarkGray;
            tagDate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            tagDate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            tagDate.FillColor = Color.FromArgb(243, 244, 246);
            tagDate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tagDate.ForeColor = Color.FromArgb(50, 55, 67);
            tagDate.Image = Properties.Icons.tag_date2;
            tagDate.ImageOffset = new Point(-1, 0);
            tagDate.ImageSize = new Size(16, 15);
            tagDate.Location = new Point(3, 3);
            tagDate.Margin = new Padding(3, 3, 10, 3);
            tagDate.Name = "tagDate";
            tagDate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tagDate.Size = new Size(109, 25);
            tagDate.TabIndex = 31;
            tagDate.Text = "2069-04-20";
            // 
            // tagId
            // 
            tagId.BackColor = Color.White;
            tagId.BorderRadius = 12;
            tagId.CustomizableEdges = customizableEdges7;
            tagId.DefaultAutoSize = true;
            tagId.DisabledState.BorderColor = Color.DarkGray;
            tagId.DisabledState.CustomBorderColor = Color.DarkGray;
            tagId.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            tagId.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            tagId.FillColor = Color.FromArgb(243, 244, 246);
            tagId.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tagId.ForeColor = Color.FromArgb(50, 55, 67);
            tagId.Location = new Point(125, 3);
            tagId.Margin = new Padding(3, 3, 10, 3);
            tagId.Name = "tagId";
            tagId.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tagId.Size = new Size(114, 25);
            tagId.TabIndex = 30;
            tagId.Text = "ID: 0H106Y477";
            // 
            // tagAuthor
            // 
            tagAuthor.BackColor = Color.White;
            tagAuthor.BorderRadius = 12;
            tagAuthor.CustomizableEdges = customizableEdges9;
            tagAuthor.DefaultAutoSize = true;
            tagAuthor.DisabledState.BorderColor = Color.DarkGray;
            tagAuthor.DisabledState.CustomBorderColor = Color.DarkGray;
            tagAuthor.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            tagAuthor.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            tagAuthor.FillColor = Color.FromArgb(243, 244, 246);
            tagAuthor.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tagAuthor.ForeColor = Color.FromArgb(50, 55, 67);
            tagAuthor.Image = Properties.Icons.tag_person2;
            tagAuthor.ImageSize = new Size(16, 16);
            tagAuthor.Location = new Point(252, 3);
            tagAuthor.Margin = new Padding(3, 3, 10, 3);
            tagAuthor.Name = "tagAuthor";
            tagAuthor.ShadowDecoration.CustomizableEdges = customizableEdges10;
            tagAuthor.Size = new Size(77, 25);
            tagAuthor.TabIndex = 32;
            tagAuthor.Text = "Diddy";
            // 
            // tagAttachments
            // 
            tagAttachments.BackColor = Color.White;
            tagAttachments.BorderRadius = 12;
            tagAttachments.CustomizableEdges = customizableEdges11;
            tagAttachments.DefaultAutoSize = true;
            tagAttachments.DisabledState.BorderColor = Color.DarkGray;
            tagAttachments.DisabledState.CustomBorderColor = Color.DarkGray;
            tagAttachments.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            tagAttachments.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            tagAttachments.FillColor = Color.FromArgb(243, 244, 246);
            tagAttachments.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tagAttachments.ForeColor = Color.FromArgb(50, 55, 67);
            tagAttachments.Image = Properties.Icons.tag_attachment;
            tagAttachments.ImageOffset = new Point(-1, 0);
            tagAttachments.ImageSize = new Size(16, 16);
            tagAttachments.Location = new Point(342, 3);
            tagAttachments.Margin = new Padding(3, 3, 10, 3);
            tagAttachments.Name = "tagAttachments";
            tagAttachments.ShadowDecoration.CustomizableEdges = customizableEdges12;
            tagAttachments.Size = new Size(89, 25);
            tagAttachments.TabIndex = 33;
            tagAttachments.Text = "1 file (s)";
            // 
            // ArchiveCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tagStatus);
            Controls.Add(btnMore);
            Controls.Add(txtContent);
            Controls.Add(lblTitle);
            Controls.Add(materialCard1);
            Margin = new Padding(20, 0, 0, 0);
            Name = "ArchiveCard";
            Size = new Size(1400, 194);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            flpTags.ResumeLayout(false);
            flpTags.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button tagStatus;
        private Guna.UI2.WinForms.Guna2Button btnMore;
        private RichTextBox txtContent;
        private Label lblTitle;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private FlowLayoutPanel flpTags;
        private Guna.UI2.WinForms.Guna2Button tagDate;
        private Guna.UI2.WinForms.Guna2Button tagId;
        private Guna.UI2.WinForms.Guna2Button tagAuthor;
        private Guna.UI2.WinForms.Guna2Button tagAttachments;
    }
}
