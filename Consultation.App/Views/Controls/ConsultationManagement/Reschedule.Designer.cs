namespace Consultation.App.Views.Controls.ConsultationManagement
{
    partial class Reschedule
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            CurrentTime = new Label();
            CurrentDate = new Label();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnReschedule = new Guna.UI2.WinForms.Guna2Button();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            Reason = new Guna.UI2.WinForms.Guna2TextBox();
            comboboxTime = new Guna.UI2.WinForms.Guna2ComboBox();
            pictureBox1 = new PictureBox();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Archivo", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(25, 20);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(230, 31);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Reschedule Consultation\r\n\r\n\r\n";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Archivo", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(25, 46);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(327, 27);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "Update the date and time for this consultation.";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(CurrentTime);
            materialCard1.Controls.Add(CurrentDate);
            materialCard1.Controls.Add(guna2HtmlLabel3);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(23, 90);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(450, 80);
            materialCard1.TabIndex = 2;
            // 
            // CurrentTime
            // 
            CurrentTime.AutoSize = true;
            CurrentTime.Font = new Font("Archivo SemiBold", 14.2499981F, FontStyle.Bold);
            CurrentTime.Location = new Point(291, 40);
            CurrentTime.Name = "CurrentTime";
            CurrentTime.Size = new Size(96, 29);
            CurrentTime.TabIndex = 8;
            CurrentTime.Text = "11:01 AM";
            // 
            // CurrentDate
            // 
            CurrentDate.AutoSize = true;
            CurrentDate.Font = new Font("Archivo SemiBold", 14.2499981F, FontStyle.Bold);
            CurrentDate.Location = new Point(62, 37);
            CurrentDate.Name = "CurrentDate";
            CurrentDate.Size = new Size(119, 29);
            CurrentDate.TabIndex = 7;
            CurrentDate.Text = "July 6, 2025";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(17, 11);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(105, 18);
            guna2HtmlLabel3.TabIndex = 6;
            guna2HtmlLabel3.Text = "Current Schedule";
            // 
            // Date
            // 
            Date.Checked = true;
            Date.CustomFormat = "MMMM dd, yyyy";
            Date.CustomizableEdges = customizableEdges9;
            Date.FillColor = Color.White;
            Date.Font = new Font("Segoe UI", 9F);
            Date.Format = DateTimePickerFormat.Custom;
            Date.Location = new Point(23, 202);
            Date.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            Date.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            Date.Name = "Date";
            Date.ShadowDecoration.CustomizableEdges = customizableEdges10;
            Date.Size = new Size(202, 36);
            Date.TabIndex = 4;
            Date.TextAlign = HorizontalAlignment.Center;
            Date.Value = new DateTime(2025, 7, 6, 11, 1, 21, 130);
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.Location = new Point(26, 247);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(193, 20);
            guna2HtmlLabel4.TabIndex = 7;
            guna2HtmlLabel4.Text = "Reason for Rescheduling";
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel5.Location = new Point(25, 178);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(70, 18);
            guna2HtmlLabel5.TabIndex = 8;
            guna2HtmlLabel5.Text = "New Date";
            // 
            // guna2HtmlLabel6
            // 
            guna2HtmlLabel6.BackColor = Color.Transparent;
            guna2HtmlLabel6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel6.Location = new Point(273, 179);
            guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            guna2HtmlLabel6.Size = new Size(107, 18);
            guna2HtmlLabel6.TabIndex = 9;
            guna2HtmlLabel6.Text = "Schedule Time";
            // 
            // btnReschedule
            // 
            btnReschedule.BorderColor = Color.DarkRed;
            btnReschedule.BorderRadius = 8;
            btnReschedule.CustomizableEdges = customizableEdges5;
            btnReschedule.DisabledState.BorderColor = Color.DarkGray;
            btnReschedule.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReschedule.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReschedule.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReschedule.FillColor = Color.DarkRed;
            btnReschedule.Font = new Font("Archivo", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReschedule.ForeColor = Color.White;
            btnReschedule.Image = Properties.Icons.up_arrow;
            btnReschedule.ImageAlign = HorizontalAlignment.Left;
            btnReschedule.Location = new Point(326, 412);
            btnReschedule.Name = "btnReschedule";
            btnReschedule.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnReschedule.Size = new Size(147, 36);
            btnReschedule.TabIndex = 10;
            btnReschedule.Text = "Reschedule";
            btnReschedule.TextOffset = new Point(6, 0);
            btnReschedule.Click += btnReschedule_Click;
            // 
            // btnCancel
            // 
            btnCancel.BorderColor = Color.Red;
            btnCancel.BorderRadius = 8;
            btnCancel.BorderThickness = 1;
            btnCancel.CustomizableEdges = customizableEdges3;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Archivo", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Red;
            btnCancel.Image = Properties.Icons.close;
            btnCancel.ImageAlign = HorizontalAlignment.Left;
            btnCancel.ImageSize = new Size(10, 10);
            btnCancel.Location = new Point(216, 412);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancel.Size = new Size(92, 36);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.TextOffset = new Point(6, 0);
            btnCancel.Click += btnCancel_Click;
            // 
            // Reason
            // 
            Reason.AcceptsReturn = true;
            Reason.BorderRadius = 10;
            Reason.BorderThickness = 2;
            Reason.CustomizableEdges = customizableEdges7;
            Reason.DefaultText = "";
            Reason.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            Reason.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            Reason.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            Reason.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            Reason.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Reason.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Reason.ForeColor = Color.Black;
            Reason.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            Reason.Location = new Point(25, 270);
            Reason.Multiline = true;
            Reason.Name = "Reason";
            Reason.PlaceholderForeColor = Color.Gray;
            Reason.PlaceholderText = "Enter reason for rescheduling...";
            Reason.SelectedText = "";
            Reason.ShadowDecoration.CustomizableEdges = customizableEdges8;
            Reason.Size = new Size(450, 136);
            Reason.TabIndex = 5;
            // 
            // comboboxTime
            // 
            comboboxTime.BackColor = Color.Transparent;
            comboboxTime.CustomizableEdges = customizableEdges1;
            comboboxTime.DrawMode = DrawMode.OwnerDrawFixed;
            comboboxTime.DropDownHeight = 80;
            comboboxTime.DropDownStyle = ComboBoxStyle.DropDownList;
            comboboxTime.DropDownWidth = 150;
            comboboxTime.FillColor = Color.LightGray;
            comboboxTime.FocusedColor = Color.FromArgb(94, 148, 255);
            comboboxTime.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            comboboxTime.Font = new Font("Segoe UI", 9F);
            comboboxTime.ForeColor = Color.FromArgb(68, 88, 112);
            comboboxTime.IntegralHeight = false;
            comboboxTime.ItemHeight = 30;
            comboboxTime.Location = new Point(273, 202);
            comboboxTime.Name = "comboboxTime";
            comboboxTime.ShadowDecoration.CustomizableEdges = customizableEdges2;
            comboboxTime.Size = new Size(200, 36);
            comboboxTime.TabIndex = 40;
            comboboxTime.TextAlign = HorizontalAlignment.Center;
            comboboxTime.TextOffset = new Point(20, 0);
            comboboxTime.DropDown += comboboxTime_DropDown;
            comboboxTime.SelectedIndexChanged += comboboxTime_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightGray;
            pictureBox1.Image = Properties.Icons.clock;
            pictureBox1.Location = new Point(283, 212);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(15, 15);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // Reschedule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 460);
            Controls.Add(pictureBox1);
            Controls.Add(comboboxTime);
            Controls.Add(btnCancel);
            Controls.Add(btnReschedule);
            Controls.Add(guna2HtmlLabel6);
            Controls.Add(guna2HtmlLabel5);
            Controls.Add(guna2HtmlLabel4);
            Controls.Add(Reason);
            Controls.Add(Date);
            Controls.Add(materialCard1);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Reschedule";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reschedule";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker Date;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnReschedule;
        private Label CurrentTime;
        private Label CurrentDate;
        private Guna.UI2.WinForms.Guna2TextBox Reason;
        private Guna.UI2.WinForms.Guna2ComboBox comboboxTime;
        private PictureBox pictureBox1;
    }
}