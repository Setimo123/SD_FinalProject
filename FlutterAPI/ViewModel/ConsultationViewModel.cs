using Consultation.Domain.Enum;

namespace FlutterAPI.ViewModel
{
    public class ConsultationViewModel
    {
        public string StudentName { get; set; }

        public string FacultyName { get; set; }

        public string CourseCode { get; set; }

        public string Concern { get; set; }

        public string DisapprovedReason { get; set; }

        public DateTime DateOfConsultation { get; set; }

        public UserType Usertype { get; set; }


    }
}
