using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM_Consultation_App_MAUI.Model
{
    public partial class StudentRequestModel : ObservableObject
    {
        [ObservableProperty]
        public string studentname;

        [ObservableProperty]
        public string studentumid;

        [ObservableProperty]
        public string coursecode;

        [ObservableProperty]
        public string courseinstructor;

        [ObservableProperty]
        public string starttime;

        [ObservableProperty]
        public string endtime;

        [ObservableProperty]
        public string selectedcourses;
    }
}
