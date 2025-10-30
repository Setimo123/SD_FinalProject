using Shiny;
using Shiny.Push;
using UM_Consultation_App_MAUI.Views;
using UM_Consultation_App_MAUI.Views.Common;
using UM_Consultation_App_MAUI.Views.FacultyView;
using UM_Consultation_App_MAUI.Views.StudentView;


namespace UM_Consultation_App_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); 
        }
    }
}
