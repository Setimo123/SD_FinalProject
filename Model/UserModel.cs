using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM_Consultation_App_MAUI.Model
{
    public partial class UserModel : ObservableObject
    {
        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public bool isPasswordHidden = true;

        [ObservableProperty]
        public string passwordhashed = "eyeclosed.png";
    }
}
