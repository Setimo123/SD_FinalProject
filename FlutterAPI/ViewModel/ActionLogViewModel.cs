using Consultation.Domain.Enum;

namespace FlutterAPI.ViewModel
{
    public class ActionLogViewModel
    {
        public int ActionLogID { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public TimeOnly Time { get; set; }

        public UserType UserType { get; set; }

        public string AccountName { get; set; }

    }
}
