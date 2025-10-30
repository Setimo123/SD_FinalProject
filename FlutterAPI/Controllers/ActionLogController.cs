using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Infrastructure.Data;
using FlutterAPI.ViewModel;

namespace FlutterAPI.Controllers
{
    public class ActionLogController
    {
        //ActionLog for Log-in
        public static ActionLog ActionLogger(string message, string AccountName,
            UserType UserType, Users user)
        {
            ActionLog viewModel = new ActionLog()
            {
                ActionLogID = 0,
                Date = DateTime.Now,
                Description = message,
                Time = TimeOnly.FromDateTime(DateTime.Now),
                Users = user
            };
            return viewModel;
        }
    }
}
