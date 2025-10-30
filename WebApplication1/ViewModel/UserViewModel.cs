using Consultation.Domain.Enum;

namespace Consunltation.API.ViewModel
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}
