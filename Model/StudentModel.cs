using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM_Consultation_App_MAUI.Model
{
    public partial class StudentModel : ObservableObject
    {
        [ObservableProperty]
        public string studentname;

        [ObservableProperty]
        public string umid;

        [ObservableProperty]
        public string schoolyear;

        [ObservableProperty]
        public string useryearlevel;

        [ObservableProperty]
        public string pendingconsultation;


    }
}
