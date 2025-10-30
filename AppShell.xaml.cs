using UM_Consultation_App_MAUI.Views;
using UM_Consultation_App_MAUI.Views.StudentView;

namespace UM_Consultation_App_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Common Page
            Routing.RegisterRoute("Login", typeof(LoginPage));
            Routing.RegisterRoute("CreateAccountPage", typeof(CreateAccountPage));


            //For students routings
            Routing.RegisterRoute("LogIn", typeof(LoginPage));
            Routing.RegisterRoute("HomePage", typeof(HomePage));
            Routing.RegisterRoute("RequestConsultationPage", typeof(RequestConsultationPage));
        }
    }
}
