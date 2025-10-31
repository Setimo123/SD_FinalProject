using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Dashboard.Activity_Feed_Panel
{
    public partial class Bulletin : UserControl
    {
        public Bulletin()
        {
            InitializeComponent();

           // for (int i = 0; i < 10; i++)
          //  {
           //     flowLayoutPanel1.Controls.Add(new BulletinCard());
           // }
        }
        
         public int BulletinId { get; set; }
         public string BulletinTitle { get; set; }
         public string BulletinBody { get; set; }
         public string BulletinStatus { get; set; }
         public DateTime BulletinDatePosted { get; set; }
    }
 }
