using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms.Suite;

namespace Consultation.App.Views.Controls.BulletinManagement
{
    public partial class ArchiveCard : UserControl
    {
        private int _bulletinId;
        
        public ArchiveCard()
        {
            InitializeComponent();
        }
        
        // Constructor with bulletin data
        public ArchiveCard(string id, string title, string author, string content, string status, DateTime datePosted)
        {
            InitializeComponent();
            
            // Parse the ID as integer for database operations
            if (int.TryParse(id, out int bulletinId))
            {
                _bulletinId = bulletinId;
            }
            
            tagId.Text = $"ID: {id}";
            lblTitle.Text = title;
            tagAuthor.Text = author;
            txtContent.Text = content;
            tagStatus.Text = status;
            tagDate.Text = datePosted.ToString("yyyy-MM-dd");
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            Initialize_btnMoreComponents();
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            btn.FillColor = Color.FromArgb(255, 240, 240);
            btn.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn.ForeColor = Color.FromArgb(190, 0, 2);

            if (btn.Name == "btnView") btn.Image = Properties.Icons.more_view_hovered;
            else if (btn.Name == "btnEdit") btn.Image = Properties.Icons.more_edit_hovered;
            else if (btn.Name == "btnArchive") btn.Image = Properties.Icons.more_archive_hovered;
            else btn.Image = Properties.Icons.more_delete_hovered;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            btn.FillColor = Color.White;
            btn.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn.ForeColor = Color.FromArgb(86, 93, 109);

            if (btn.Name == "btnView") btn.Image = Properties.Icons.more_view;
            else if (btn.Name == "btnEdit") btn.Image = Properties.Icons.more_edit;
            else if (btn.Name == "btnArchive") btn.Image = Properties.Icons.more_archive;
            else btn.Image = Properties.Icons.more_delete;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            BulletinOverlay bulletinOverlay = new BulletinOverlay();
            bulletinOverlay.tagId.Text = tagId.Text;
            bulletinOverlay.tagDate.Text = tagDate.Text;
            bulletinOverlay.tagAuthor.Text = tagAuthor.Text;
            bulletinOverlay.lblTitle.Text = lblTitle.Text;
            bulletinOverlay.txtContent.Text = txtContent.Text;
            bulletinOverlay.ShowDialog();

            // backend
            // retrieve attachment/s from db
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            CreateBulletin bulletinForm = new CreateBulletin();
            bulletinForm.lblHeader.Text = "Edit Bulletin";
            bulletinForm.txtAuthor.Text = tagAuthor.Text;
            bulletinForm.txtTitle.Text = lblTitle.Text;
            bulletinForm.txtContent.Text = txtContent.Text;
            bulletinForm.ShowDialog();

            // backend
        }
        private async void btnArchive_Click(object sender, EventArgs e)
        {
            // Restore from archive
            var result = MessageBox.Show(
                $"Do you want to restore the bulletin '{lblTitle.Text}' to active bulletins?",
                "Restore Bulletin",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Restore through the service (database)
                    bool success = await Consultation.App.Services.BulletinService.Instance.RestoreBulletin(_bulletinId);
                    
                    if (success)
                    {
                        MessageBox.Show(
                            "Bulletin has been restored successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to restore the bulletin. Please try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"An error occurred: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Confirm delete action
            var result = MessageBox.Show(
                $"Are you sure you want to permanently delete the bulletin '{lblTitle.Text}'? This action cannot be undone.",
                "Delete Bulletin",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Delete through the service (database)
                    bool success = await Consultation.App.Services.BulletinService.Instance.DeleteBulletin(_bulletinId);
                    
                    if (success)
                    {
                        MessageBox.Show(
                            "Bulletin has been permanently deleted!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to delete the bulletin. Please try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"An error occurred: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void Initialize_btnMoreComponents()
        {
            FlowLayoutPanel dropPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(6),
                Margin = Padding.Empty
            };

            Guna.UI2.WinForms.Guna2Button btnView = new Guna.UI2.WinForms.Guna2Button();
            Guna.UI2.WinForms.Guna2Button btnEdit = new Guna.UI2.WinForms.Guna2Button();
            Guna.UI2.WinForms.Guna2Button btnArchive = new Guna.UI2.WinForms.Guna2Button();
            Guna.UI2.WinForms.Guna2Button btnDelete = new Guna.UI2.WinForms.Guna2Button();

            btnView.Cursor = Cursors.Hand;
            btnView.DisabledState.BorderColor = Color.DarkGray;
            btnView.DisabledState.CustomBorderColor = Color.DarkGray;
            btnView.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnView.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnView.FillColor = Color.White;
            btnView.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnView.ForeColor = Color.FromArgb(86, 93, 109);
            btnView.Image = Properties.Icons.more_view;
            btnView.ImageAlign = HorizontalAlignment.Left;
            btnView.ImageOffset = new Point(6, 0);
            btnView.ImageSize = new Size(22, 15);
            btnView.Location = new Point(8, 10);
            btnView.Name = "btnView";
            btnView.Size = new Size(115, 40);
            btnView.TabIndex = 35;
            btnView.Text = "View";
            btnView.TextAlign = HorizontalAlignment.Left;
            btnView.TextOffset = new Point(6, 0);
            btnView.Margin = Padding.Empty;
            btnView.MouseEnter += button_MouseEnter;
            btnView.MouseLeave += button_MouseLeave;
            btnView.Click += btnView_Click;

            btnEdit.Cursor = Cursors.Hand;
            btnEdit.DisabledState.BorderColor = Color.DarkGray;
            btnEdit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEdit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEdit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEdit.FillColor = Color.White;
            btnEdit.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.FromArgb(86, 93, 109);
            btnEdit.Image = Properties.Icons.more_edit;
            btnEdit.ImageAlign = HorizontalAlignment.Left;
            btnEdit.ImageOffset = new Point(6, 0);
            btnEdit.ImageSize = new Size(22, 22);
            btnEdit.Location = new Point(8, 50);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(115, 40);
            btnEdit.TabIndex = 36;
            btnEdit.Text = "Edit";
            btnEdit.TextAlign = HorizontalAlignment.Left;
            btnEdit.TextOffset = new Point(6, 0);
            btnEdit.Margin = Padding.Empty;
            btnEdit.MouseEnter += button_MouseEnter;
            btnEdit.MouseLeave += button_MouseLeave;
            btnEdit.Click += btnEdit_Click;

            btnArchive.Cursor = Cursors.Hand;
            btnArchive.DisabledState.BorderColor = Color.DarkGray;
            btnArchive.DisabledState.CustomBorderColor = Color.DarkGray;
            btnArchive.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnArchive.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnArchive.FillColor = Color.White;
            btnArchive.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnArchive.ForeColor = Color.FromArgb(86, 93, 109);
            btnArchive.Image = Properties.Icons.more_archive;
            btnArchive.ImageAlign = HorizontalAlignment.Left;
            btnArchive.ImageOffset = new Point(6, 0);
            btnArchive.ImageSize = new Size(22, 20);
            btnArchive.Location = new Point(8, 90);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(115, 40);
            btnArchive.TabIndex = 37;
            btnArchive.Text = "Restore";
            btnArchive.TextAlign = HorizontalAlignment.Left;
            btnArchive.TextOffset = new Point(6, 0);
            btnArchive.Margin = Padding.Empty;
            btnArchive.MouseEnter += button_MouseEnter;
            btnArchive.MouseLeave += button_MouseLeave;
            btnArchive.Click += btnArchive_Click;

            btnDelete.Cursor = Cursors.Hand;
            btnDelete.DisabledState.BorderColor = Color.DarkGray;
            btnDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDelete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDelete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDelete.FillColor = Color.White;
            btnDelete.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.FromArgb(86, 93, 109);
            btnDelete.Image = Properties.Icons.more_delete;
            btnDelete.ImageAlign = HorizontalAlignment.Left;
            btnDelete.ImageOffset = new Point(6, 0);
            btnDelete.ImageSize = new Size(22, 22);
            btnDelete.Location = new Point(8, 130);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 40);
            btnDelete.TabIndex = 38;
            btnDelete.Text = "Delete";
            btnDelete.TextAlign = HorizontalAlignment.Left;
            btnDelete.TextOffset = new Point(6, 0);
            btnDelete.Margin = Padding.Empty;
            btnDelete.MouseEnter += button_MouseEnter;
            btnDelete.MouseLeave += button_MouseLeave;
            btnDelete.Click += btnDelete_Click;

            dropPanel.Controls.Add(btnView);
            dropPanel.Controls.Add(btnEdit);
            dropPanel.Controls.Add(btnArchive);
            dropPanel.Controls.Add(btnDelete);

            ToolStripControlHost host = new ToolStripControlHost(dropPanel)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = true
            };

            ToolStripDropDown dropDown = new ToolStripDropDown
            {
                AutoClose = true,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };
            dropDown.Items.Add(host);

            dropDown.Show(btnMore, new Point(0, btnMore.Height));
        }
    }
}