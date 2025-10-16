namespace Consultation.App.Views
{
    partial class UserManagementView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            buttonAdmin = new Button();
            flPanelUserCard = new FlowLayoutPanel();
            buttonFaculty = new Button();
            buttonStudents = new Button();
            pictureBox1 = new PictureBox();
            TotalStudents = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            TotalFacultyMem = new Label();
            label4 = new Label();
            backStageView1 = new Syncfusion.Windows.Forms.BackStageView(components);
            pictureBox3 = new PictureBox();
            TotalAdmin = new Label();
            label6 = new Label();
            BtnRefresh = new Button();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            materialCard3 = new MaterialSkin.Controls.MaterialCard();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            materialCard5 = new MaterialSkin.Controls.MaterialCard();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            cboxSort = new Guna.UI2.WinForms.Guna2ComboBox();
            USMsearchbar = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            materialCard1.SuspendLayout();
            materialCard2.SuspendLayout();
            materialCard3.SuspendLayout();
            materialCard4.SuspendLayout();
            materialCard5.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAdmin
            // 
            buttonAdmin.BackColor = Color.Transparent;
            buttonAdmin.FlatAppearance.BorderSize = 0;
            buttonAdmin.FlatStyle = FlatStyle.Flat;
            buttonAdmin.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            buttonAdmin.ForeColor = Color.FromArgb(192, 0, 0);
            buttonAdmin.Location = new Point(1090, 101);
            buttonAdmin.Name = "buttonAdmin";
            buttonAdmin.Size = new Size(72, 25);
            buttonAdmin.TabIndex = 7;
            buttonAdmin.Text = "Admin";
            buttonAdmin.UseVisualStyleBackColor = false;
            // 
            // flPanelUserCard
            // 
            flPanelUserCard.AutoScroll = true;
            flPanelUserCard.BackColor = Color.Transparent;
            flPanelUserCard.FlowDirection = FlowDirection.TopDown;
            flPanelUserCard.Location = new Point(178, 223);
            flPanelUserCard.Name = "flPanelUserCard";
            flPanelUserCard.Size = new Size(993, 508);
            flPanelUserCard.TabIndex = 6;
            flPanelUserCard.WrapContents = false;
            flPanelUserCard.Paint += flPanelUserCard_Paint;
            // 
            // buttonFaculty
            // 
            buttonFaculty.BackColor = Color.Transparent;
            buttonFaculty.FlatAppearance.BorderSize = 0;
            buttonFaculty.FlatStyle = FlatStyle.Flat;
            buttonFaculty.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            buttonFaculty.ForeColor = Color.FromArgb(192, 0, 0);
            buttonFaculty.Location = new Point(1015, 101);
            buttonFaculty.Name = "buttonFaculty";
            buttonFaculty.Size = new Size(72, 25);
            buttonFaculty.TabIndex = 1;
            buttonFaculty.Text = "Faculty";
            buttonFaculty.UseVisualStyleBackColor = false;
            // 
            // buttonStudents
            // 
            buttonStudents.BackColor = Color.Transparent;
            buttonStudents.BackgroundImageLayout = ImageLayout.None;
            buttonStudents.FlatAppearance.BorderSize = 0;
            buttonStudents.FlatStyle = FlatStyle.Flat;
            buttonStudents.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            buttonStudents.ForeColor = Color.FromArgb(192, 0, 0);
            buttonStudents.Location = new Point(929, 101);
            buttonStudents.Name = "buttonStudents";
            buttonStudents.Size = new Size(78, 25);
            buttonStudents.TabIndex = 0;
            buttonStudents.Text = "Students";
            buttonStudents.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Icons.Selection;
            pictureBox1.Location = new Point(135, 26);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // TotalStudents
            // 
            TotalStudents.AutoSize = true;
            TotalStudents.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            TotalStudents.Location = new Point(17, 39);
            TotalStudents.Name = "TotalStudents";
            TotalStudents.Size = new Size(56, 29);
            TotalStudents.TabIndex = 1;
            TotalStudents.Text = "N/A";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label1.Location = new Point(17, 14);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Total Students";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Icons.Selection_faculty;
            pictureBox2.Location = new Point(127, 26);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(56, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // TotalFacultyMem
            // 
            TotalFacultyMem.AutoSize = true;
            TotalFacultyMem.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            TotalFacultyMem.Location = new Point(17, 40);
            TotalFacultyMem.Name = "TotalFacultyMem";
            TotalFacultyMem.Size = new Size(56, 29);
            TotalFacultyMem.TabIndex = 1;
            TotalFacultyMem.Text = "N/A";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label4.Location = new Point(17, 14);
            label4.Name = "label4";
            label4.Size = new Size(116, 15);
            label4.TabIndex = 0;
            label4.Text = "Faculty Members";
            // 
            // backStageView1
            // 
            backStageView1.BackStage = null;
            backStageView1.HostControl = null;
            backStageView1.HostForm = null;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Icons.Admin;
            pictureBox3.Location = new Point(127, 26);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(56, 48);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // TotalAdmin
            // 
            TotalAdmin.AutoSize = true;
            TotalAdmin.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            TotalAdmin.Location = new Point(17, 39);
            TotalAdmin.Name = "TotalAdmin";
            TotalAdmin.Size = new Size(56, 29);
            TotalAdmin.TabIndex = 1;
            TotalAdmin.Text = "N/A";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label6.Location = new Point(17, 14);
            label6.Name = "label6";
            label6.Size = new Size(92, 15);
            label6.TabIndex = 0;
            label6.Text = "Administrator";
            // 
            // BtnRefresh
            // 
            BtnRefresh.Image = Properties.Icons.refresh;
            BtnRefresh.Location = new Point(1320, 167);
            BtnRefresh.Margin = new Padding(3, 2, 3, 2);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(76, 23);
            BtnRefresh.TabIndex = 6;
            BtnRefresh.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(TotalStudents);
            materialCard1.Controls.Add(pictureBox1);
            materialCard1.Controls.Add(label1);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(140, 14);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(200, 100);
            materialCard1.TabIndex = 7;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(TotalFacultyMem);
            materialCard2.Controls.Add(pictureBox2);
            materialCard2.Controls.Add(label4);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(390, 14);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(200, 100);
            materialCard2.TabIndex = 8;
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Controls.Add(pictureBox3);
            materialCard3.Controls.Add(TotalAdmin);
            materialCard3.Controls.Add(label6);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(640, 14);
            materialCard3.Margin = new Padding(14);
            materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(14);
            materialCard3.Size = new Size(200, 100);
            materialCard3.TabIndex = 9;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(flPanelUserCard);
            materialCard4.Controls.Add(materialCard5);
            materialCard4.Controls.Add(cboxSort);
            materialCard4.Controls.Add(USMsearchbar);
            materialCard4.Controls.Add(buttonStudents);
            materialCard4.Controls.Add(buttonAdmin);
            materialCard4.Controls.Add(buttonFaculty);
            materialCard4.Depth = 0;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(140, 137);
            materialCard4.Margin = new Padding(14);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(14);
            materialCard4.Size = new Size(1396, 765);
            materialCard4.TabIndex = 10;
            // 
            // materialCard5
            // 
            materialCard5.BackColor = Color.FromArgb(255, 255, 255);
            materialCard5.Controls.Add(label7);
            materialCard5.Controls.Add(label5);
            materialCard5.Controls.Add(label3);
            materialCard5.Controls.Add(label2);
            materialCard5.Depth = 0;
            materialCard5.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard5.Location = new Point(178, 143);
            materialCard5.Margin = new Padding(14);
            materialCard5.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard5.Name = "materialCard5";
            materialCard5.Padding = new Padding(14);
            materialCard5.Size = new Size(993, 63);
            materialCard5.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14F);
            label7.Location = new Point(874, 20);
            label7.Name = "label7";
            label7.Size = new Size(63, 24);
            label7.TabIndex = 3;
            label7.Text = "Action";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14F);
            label5.Location = new Point(622, 20);
            label5.Name = "label5";
            label5.Size = new Size(57, 24);
            label5.TabIndex = 2;
            label5.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14F);
            label3.Location = new Point(306, 20);
            label3.Name = "label3";
            label3.Size = new Size(101, 24);
            label3.TabIndex = 1;
            label3.Text = "ID Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14F);
            label2.Location = new Point(90, 20);
            label2.Name = "label2";
            label2.Size = new Size(61, 24);
            label2.TabIndex = 0;
            label2.Text = "Name";
            // 
            // cboxSort
            // 
            cboxSort.BackColor = Color.Transparent;
            cboxSort.BorderRadius = 6;
            cboxSort.CustomizableEdges = customizableEdges1;
            cboxSort.DrawMode = DrawMode.OwnerDrawFixed;
            cboxSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxSort.FocusedColor = Color.FromArgb(94, 148, 255);
            cboxSort.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboxSort.Font = new Font("Segoe UI", 10F);
            cboxSort.ForeColor = Color.FromArgb(68, 88, 112);
            cboxSort.ItemHeight = 30;
            cboxSort.Location = new Point(178, 90);
            cboxSort.Name = "cboxSort";
            cboxSort.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cboxSort.Size = new Size(224, 36);
            cboxSort.TabIndex = 16;
            cboxSort.SelectedIndexChanged += cboxSort_SelectedIndexChanged;
            // 
            // USMsearchbar
            // 
            USMsearchbar.BorderRadius = 6;
            USMsearchbar.CustomizableEdges = customizableEdges3;
            USMsearchbar.DefaultText = "\r\n";
            USMsearchbar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            USMsearchbar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            USMsearchbar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            USMsearchbar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            USMsearchbar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            USMsearchbar.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            USMsearchbar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            USMsearchbar.Location = new Point(178, 25);
            USMsearchbar.Margin = new Padding(4);
            USMsearchbar.Name = "USMsearchbar";
            USMsearchbar.PlaceholderForeColor = Color.Gray;
            USMsearchbar.PlaceholderText = "Search by Name, Email or Umindanao ID";
            USMsearchbar.SelectedText = "";
            USMsearchbar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            USMsearchbar.Size = new Size(993, 49);
            USMsearchbar.TabIndex = 15;
            USMsearchbar.TextChanged += USMsearchbar_TextChanged;
            // 
            // UserManagementView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(materialCard4);
            Controls.Add(materialCard3);
            Controls.Add(materialCard2);
            Controls.Add(materialCard1);
            Controls.Add(BtnRefresh);
            Name = "UserManagementView";
            Size = new Size(1644, 941);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            materialCard3.ResumeLayout(false);
            materialCard3.PerformLayout();
            materialCard4.ResumeLayout(false);
            materialCard5.ResumeLayout(false);
            materialCard5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        //private ComboBox CBoxYear;
        //private ComboBox CBoxCourse;
        //private ComboBox CBoxSort;
        private Button buttonFaculty;
        private Button buttonStudents;
        private Label TotalStudents;
        private Label label1;
        private Label TotalFacultyMem;
        private Label label4;
        private FlowLayoutPanel flPanelUserCard;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Syncfusion.Windows.Forms.BackStageView backStageView1;
        private PictureBox pictureBox3;
        private Label TotalAdmin;
        private Label label6;
        private Button buttonAdmin;
        private Button BtnRefresh;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private Guna.UI2.WinForms.Guna2ComboBox cboxSort;
        private Guna.UI2.WinForms.Guna2TextBox USMsearchbar;
        private MaterialSkin.Controls.MaterialCard materialCard5;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label7;
    }
}
