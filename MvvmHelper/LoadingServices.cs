using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM_Consultation_App_MAUI.MvvmHelper.Interface;


namespace UM_Consultation_App_MAUI.MvvmHelper
{

    public class LoadingServices : ILoadingServices
    {
        private Views.Common.LoadingScreen _popup; 

        public void NoInternet()
        {
            var _noInternet = new Views.Common.NoInternetPage();
            Application.Current.MainPage.ShowPopup(_noInternet);
        }
        public void Show()
        {
            _popup = new Views.Common.LoadingScreen();
            Application.Current.MainPage.ShowPopup(_popup);
        }

        public void Hide()
        {
            if (_popup != null)
            {
                _popup.Close();
            }
            _popup = null;
        }
    }
}
