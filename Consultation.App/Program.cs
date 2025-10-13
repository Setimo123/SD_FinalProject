using Consultation.App.Presenters;
using Consultation.App.Views;
using Consultation.App.Views.IViews;
using Consultation.BackEndCRUD.Service;
using Consultation.Infrastructure.Data;
using System.Linq;

namespace Consultation.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXpecXRcQ2BcV0BwVktWYUA=");

            ApplicationConfiguration.Initialize();

            AppDbContext appDbContext = new AppDbContext();
            var authservice = new AuthService(appDbContext);

            ILoginView loginView = new LogInView();
            new LogInPresenter(loginView, authservice);

            // Run the login form and check the result
            var loginResult = ((Form)loginView).ShowDialog();

            // If login was successful, the MainView will already be shown
            // and will be the active form, so we run the application with it
            if (loginResult == DialogResult.OK)
            {
                // Find the active MainView form
                var mainForm = Application.OpenForms.OfType<MainView>().FirstOrDefault();
                if (mainForm != null)
                {
                    Application.Run(mainForm);
                }
            }
        }
    }
           
}