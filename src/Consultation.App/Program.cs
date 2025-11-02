using Consultation.App.Presenters;
using Consultation.App.Services;
using Consultation.App.Views;
using Consultation.App.Views.IViews;
using Consultation.BackEndCRUD.Service;
using Consultation.Infrastructure.Data;
using System.Linq;

namespace Consultation.App
{
    internal static class Program
    {
        private static BulletinApiServer _apiServer;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXpecXRcQ2BcV0BwVktWYUA=");

            ApplicationConfiguration.Initialize();

            // Start API Server for Next.js integration
            _apiServer = new BulletinApiServer();
            try
            {
                await _apiServer.StartAsync();

                // Optional: Show notification that API is ready
                MessageBox.Show(
              "Bulletin API Bridge is running on http://localhost:5000\n\n" +
          "You can now start your Next.js application.",
      "API Bridge Started",
              MessageBoxButtons.OK,
         MessageBoxIcon.Information);
             }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not start API server: {ex.Message}");
          MessageBox.Show(
              $"Failed to start API Bridge:\n{ex.Message}\n\n" +
            "The application will continue without API access.",
            "API Bridge Error",
         MessageBoxButtons.OK,
          MessageBoxIcon.Warning);
              // Continue running the app even if API server fails
       }

            AppDbContext appDbContext = new AppDbContext();
            var authservice = new AuthService(appDbContext);

            ILoginView loginView = new LogInView();
            new LogInPresenter(loginView, authservice, appDbContext);

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

            // Stop API Server when app closes
            if (_apiServer != null && _apiServer.IsRunning)
            {
                await _apiServer.StopAsync();
            }
        }
    }
}

