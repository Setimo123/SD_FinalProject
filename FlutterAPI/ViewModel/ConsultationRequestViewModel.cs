using Consultation.Domain.Enum;

namespace FlutterAPI.ViewModel
{
    public class ConsultationRequestViewModel
    {
        public int ConsultationID { get; set; }
        public string CourseCode { get; set; }
        public string StudentName { get; set; }
        public DateTime DateSchedule { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public Status Status { get; set; }
    }
}





