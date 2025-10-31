using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.App.ViewModels.DashboardModels
{
    public class ConsultationModel
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string Body { get; set; }
        public DateTime DateScheduled { get; set; }
        public string Course { get; set; }
    }
}
