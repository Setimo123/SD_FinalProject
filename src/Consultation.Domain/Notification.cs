using Consultation.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Domain
{
    public class Notification
    {
        [Key]
        public int NotificationNumber { get; set; }

        public string NotificationMessage { get; set; }

        //Create an enum for notification for students notification and admin notification

        public NotificationType NotificationType { get; set; }

    }
}
