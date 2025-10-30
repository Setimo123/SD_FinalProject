using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM_Consultation_App_MAUI.Model
{
    public partial class ResponseModel : ObservableObject
    {
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string courseCode;

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string dateStarted;

        [ObservableProperty]
        public string dateEnded;

        [ObservableProperty]
        public string schedule;

        [ObservableProperty]
        public string status;

        [ObservableProperty]
        public Color statusColor;

        public ResponseModel(int Id, string coursecode, string Name, string datestarted, string dateended
            , string Schedule, string Status)
        {
            id = Id;
            name = Name;
            dateStarted = datestarted;
            dateEnded = dateended;
            schedule = Schedule;
            status = Status;
            courseCode = coursecode;
            statusColor = Status switch
            {
                "Approved" => Colors.Green,
                "Declined" => Colors.Red,
                "Pending" => Colors.Orange,
                _ => Colors.Gray
            };

        }
    }
}
