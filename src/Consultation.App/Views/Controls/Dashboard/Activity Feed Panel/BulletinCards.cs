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
    public partial class BulletinCards : UserControl
    {


        public BulletinCards(string bulletintitle, string bulletinstatus, string bulletinbody, DateTime bulletinDatePosted)
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

            BulletinTitle.Text = bulletintitle;
            BulletinStatusLabel.Text = bulletinstatus;
            BulletinBody.Text = bulletinbody;
            BulletinDate.Text = bulletinDatePosted.ToString("MMM dd, yyyy");
            
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
            string status = BulletinStatusLabel.Text.Trim();

            if (string.Equals(status, "Pending", StringComparison.OrdinalIgnoreCase))
            {
                BulletinStatusPanel.FillColor = Color.Firebrick;
                BulletinStatusLabel.ForeColor = Color.White;
                BulletinStatusLabel.BackColor = Color.Firebrick;
                BulletinStatusLabel.Font = new Font(
                     BulletinStatusLabel.Font.FontFamily,
                     BulletinStatusLabel.Font.Size,
                     FontStyle.Bold | FontStyle.Italic
                );
            }
            else if (string.Equals(status, "Approved", StringComparison.OrdinalIgnoreCase))
            {
                BulletinStatusPanel.FillColor = Color.LightGreen;
                BulletinStatusLabel.ForeColor = Color.Black;
                BulletinStatusLabel.BackColor = Color.LightGreen;
                BulletinStatusLabel.Font = new Font(
                     BulletinStatusLabel.Font.FontFamily,
                     BulletinStatusLabel.Font.Size,
                     FontStyle.Bold | FontStyle.Italic
                );
            }
        }

    }
}
