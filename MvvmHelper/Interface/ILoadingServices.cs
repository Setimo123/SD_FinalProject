using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM_Consultation_App_MAUI.MvvmHelper.Interface
{
    public interface ILoadingServices
    {
        void Hide();
        void Show();

        void NoInternet();
    }
}
