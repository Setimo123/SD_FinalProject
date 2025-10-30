using Consultation.Domain;
using System.Drawing;

namespace FlutterAPI.ViewModel
{
    public class DashboardViewModel
    {
        public Student Student { get; set; }
        public string SchoolYear { get; set; } 
        public int PendingConsultation {  get; set; }
        public List<string> Notifications { get; set; }

    }
}
