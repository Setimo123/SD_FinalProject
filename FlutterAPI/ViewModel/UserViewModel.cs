using Consultation.Domain;
using Consultation.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace FlutterAPI.ViewModel
{
    public class UserViewModel
    {
       
        public string UserID { get; set; }

        [Required, EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string UMID { get; set; }

        [Required]
        public string UserPassword { get; set; }
        public UserType UserType { get; set; }

        public string StudentName { get; set; }

        public string FacultyName { get; set; }

        public string AdminName { get; set; }
    }
}
