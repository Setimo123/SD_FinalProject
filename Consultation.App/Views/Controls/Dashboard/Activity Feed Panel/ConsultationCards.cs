using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Dashboard.Activity_Feed_Panel
{
    public partial class ConsultationCards : UserControl
    {
        public ConsultationCards(string consultationtitle, string consultationstatus, string consultationbody, string consultationdepartment, DateTime consultationdateScheduled)
        {
            InitializeComponent();

            this.MouseEnter += OnHoverEnter;
            this.MouseLeave += OnHoverLeave;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.MouseEnter += OnHoverEnter;
                ctrl.MouseLeave += OnHoverLeave;
            }

            ApplyRoundedCorners(15);

             ConsultationTitle.Text = consultationtitle;
             ConsultationStatusLabel.Text = consultationstatus;
             ConsultationBody.Text = consultationbody;
             ConsultationDepartment.Text = consultationdepartment;
             ConsultationDate.Text = consultationdateScheduled.ToString("MMM dd, yyyy");

             UpdateStatusAppearance();
        }

        private void OnHoverEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Gainsboro;
            this.Cursor = Cursors.Hand;
        }

        private void OnHoverLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
            this.Cursor = Cursors.Default;
        }

        private void ApplyRoundedCorners(int radius)
        {
            Rectangle bounds = this.ClientRectangle;
            int diameter = radius * 2;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
                path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
                path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
            }
        }

        private void UpdateStatusAppearance()
        {
            string status = ConsultationStatusLabel.Text.Trim();

            // Status 1: Pending - Red/Firebrick
            if (string.Equals(status, "Pending", StringComparison.OrdinalIgnoreCase))
            {
                ConsultationStatusPanel.FillColor = Color.Firebrick;
                ConsultationStatusLabel.ForeColor = Color.White;
                ConsultationStatusLabel.BackColor = Color.Firebrick;
                ConsultationStatusLabel.Font = new Font(
                    ConsultationStatusLabel.Font.FontFamily,
                    ConsultationStatusLabel.Font.Size,
                    FontStyle.Bold | FontStyle.Italic
                );
            }
            // Status 2: Approved - Green
            else if (string.Equals(status, "Approved", StringComparison.OrdinalIgnoreCase))
            {
                ConsultationStatusPanel.FillColor = Color.FromArgb(220, 252, 231); // Light green
                ConsultationStatusLabel.ForeColor = Color.FromArgb(21, 128, 61); // Dark green
                ConsultationStatusLabel.BackColor = Color.FromArgb(220, 252, 231);
                ConsultationStatusLabel.Font = new Font(
                    ConsultationStatusLabel.Font.FontFamily,
                    ConsultationStatusLabel.Font.Size,
                    FontStyle.Bold | FontStyle.Italic
                );
            }
            // Status 3: Disapproved - Dark Red
            else if (string.Equals(status, "Disapproved", StringComparison.OrdinalIgnoreCase))
            {
                ConsultationStatusPanel.FillColor = Color.FromArgb(254, 226, 226); // Very light red
                ConsultationStatusLabel.ForeColor = Color.FromArgb(153, 27, 27); // Dark red
                ConsultationStatusLabel.BackColor = Color.FromArgb(254, 226, 226);
                ConsultationStatusLabel.Font = new Font(
                    ConsultationStatusLabel.Font.FontFamily,
                    ConsultationStatusLabel.Font.Size,
                    FontStyle.Bold | FontStyle.Italic
                );
            }
            // Status 4: Cancelled - Orange/Amber
            else if (string.Equals(status, "Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                ConsultationStatusPanel.FillColor = Color.FromArgb(254, 243, 199); // Light amber
                ConsultationStatusLabel.ForeColor = Color.FromArgb(146, 64, 14); // Dark amber
                ConsultationStatusLabel.BackColor = Color.FromArgb(254, 243, 199);
                ConsultationStatusLabel.Font = new Font(
                    ConsultationStatusLabel.Font.FontFamily,
                    ConsultationStatusLabel.Font.Size,
                    FontStyle.Bold | FontStyle.Italic
                );
            }
            // Status 5: Done - Blue/Gray
            else if (string.Equals(status, "Done", StringComparison.OrdinalIgnoreCase))
            {
                ConsultationStatusPanel.FillColor = Color.FromArgb(224, 242, 254); // Light blue
                ConsultationStatusLabel.ForeColor = Color.FromArgb(30, 64, 175); // Dark blue
                ConsultationStatusLabel.BackColor = Color.FromArgb(224, 242, 254);
                ConsultationStatusLabel.Font = new Font(
                    ConsultationStatusLabel.Font.FontFamily,
                    ConsultationStatusLabel.Font.Size,
                    FontStyle.Bold | FontStyle.Italic
                );
            }
            // Default fallback
            else
            {
                ConsultationStatusPanel.FillColor = Color.FromArgb(243, 244, 246); // Light gray
                ConsultationStatusLabel.ForeColor = Color.FromArgb(75, 85, 99); // Dark gray
                ConsultationStatusLabel.BackColor = Color.FromArgb(243, 244, 246);
                ConsultationStatusLabel.Font = new Font(
                    ConsultationStatusLabel.Font.FontFamily,
                    ConsultationStatusLabel.Font.Size,
                    FontStyle.Regular
                );
            }
        }
    }
}
