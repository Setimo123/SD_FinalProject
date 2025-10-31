using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Views.Controls.BulletinManagement
{
    public partial class BulletinOverlay : Form
    {
        public BulletinOverlay()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Close();
            CreateBulletin bulletinForm = new CreateBulletin();
            bulletinForm.lblHeader.Text = "Edit Bulletin";
            bulletinForm.txtAuthor.Text = tagAuthor.Text;
            bulletinForm.txtTitle.Text = lblTitle.Text;
            bulletinForm.txtContent.Text = txtContent.Text;
            bulletinForm.ShowDialog();
            
            // backend
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // backend
            this.Close();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            // backend
            this.Close();
        }

        private void picDownload_Click(object sender, EventArgs e)
        {
            // download attachment logic
        }
    }
}