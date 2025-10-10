namespace Consultation.App.Views.Controls.UserManagement
{
    partial class UserCard
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
            button1 = new Button();
            labelUserEmail = new Label();
            labelUserID = new Label();
            labelName = new Label();
            pictureBox1 = new PictureBox();
            contextMenuStripEx1 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            viewToolStripMenuItem = new ToolStripMenuItem();
            resetPasswordToolStripMenuItem = new ToolStripMenuItem();
            deleteUserToolStripMenuItem = new ToolStripMenuItem();
            deleterUserToolStripMenuItem = new ToolStripMenuItem();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStripEx1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(button1);
            materialCard1.Controls.Add(labelUserEmail);
            materialCard1.Controls.Add(labelUserID);
            materialCard1.Controls.Add(labelName);
            materialCard1.Controls.Add(pictureBox1);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(5, 5);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(950, 70);
            materialCard1.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Icons.more;
            button1.Location = new Point(869, 23);
            button1.Name = "button1";
            button1.Size = new Size(46, 23);
            button1.TabIndex = 2;
            button1.TabStop = false;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelUserEmail
            // 
            labelUserEmail.AutoSize = true;
            labelUserEmail.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUserEmail.Location = new Point(553, 23);
            labelUserEmail.Name = "labelUserEmail";
            labelUserEmail.Size = new Size(169, 20);
            labelUserEmail.TabIndex = 1;
            labelUserEmail.Text = "UserEmail@email.com";
            // 
            // labelUserID
            // 
            labelUserID.AutoSize = true;
            labelUserID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUserID.Location = new Point(308, 23);
            labelUserID.Name = "labelUserID";
            labelUserID.Size = new Size(63, 20);
            labelUserID.TabIndex = 1;
            labelUserID.Text = "545454";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelName.Location = new Point(80, 23);
            labelName.Name = "labelName";
            labelName.Size = new Size(89, 20);
            labelName.TabIndex = 1;
            labelName.Text = "User Name";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Icons.tag_person;
            pictureBox1.Location = new Point(18, 17);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // contextMenuStripEx1
            // 
            contextMenuStripEx1.Font = new Font("Microsoft Sans Serif", 11F);
            contextMenuStripEx1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem, resetPasswordToolStripMenuItem, deleteUserToolStripMenuItem, deleterUserToolStripMenuItem });
            contextMenuStripEx1.MetroColor = Color.FromArgb(204, 236, 249);
            contextMenuStripEx1.Name = "contextMenuStripEx1";
            contextMenuStripEx1.Size = new Size(187, 92);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(186, 22);
            viewToolStripMenuItem.Text = "View";
            // 
            // resetPasswordToolStripMenuItem
            // 
            resetPasswordToolStripMenuItem.Name = "resetPasswordToolStripMenuItem";
            resetPasswordToolStripMenuItem.Size = new Size(186, 22);
            resetPasswordToolStripMenuItem.Text = "Reset Password";
            // 
            // deleteUserToolStripMenuItem
            // 
            deleteUserToolStripMenuItem.Name = "deleteUserToolStripMenuItem";
            deleteUserToolStripMenuItem.Size = new Size(186, 22);
            deleteUserToolStripMenuItem.Text = "Edit User";
            // 
            // deleterUserToolStripMenuItem
            // 
            deleterUserToolStripMenuItem.Name = "deleterUserToolStripMenuItem";
            deleterUserToolStripMenuItem.Size = new Size(186, 22);
            deleterUserToolStripMenuItem.Text = "Deleter user";
            // 
            // UserCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(materialCard1);
            Name = "UserCard";
            Padding = new Padding(5);
            Size = new Size(960, 80);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStripEx1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private PictureBox pictureBox1;
        private Label labelUserEmail;
        private Label labelUserID;
        private Label labelName;
        private Button button1;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx contextMenuStripEx1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem resetPasswordToolStripMenuItem;
        private ToolStripMenuItem deleteUserToolStripMenuItem;
        private ToolStripMenuItem deleterUserToolStripMenuItem;
    }
}
