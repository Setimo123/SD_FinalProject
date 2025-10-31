using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.App.ViewModels.DashboardModels
{
    public class BulletinModel
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string Body { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
