using Consultation.App.Views;
using Consultation.App.Views.IViews;
using Consultation.BackEndCRUD.Service.IService;
using Consultation.Domain;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Presenters
{
    public class LogInPresenter
    {
        private readonly ILoginView _loginView;
        private readonly IAuthService _authService;
        private bool _isLoggingIn;

        public LogInPresenter(ILoginView loginView, IAuthService authService)
        {
            _loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _isLoggingIn = false;

            _loginView.LogInEvent += LoginAsync;
        }

        private async void LoginAsync(object? sender, EventArgs e)
        {
            // Prevent multiple login attempts while processing
            if (_isLoggingIn) return;

            try
            {
                _isLoggingIn = true;
                DisableLoginControls();

                if (!ValidateInput())
                {
                    return;
                }

                var user = await AttemptLoginAsync();
                HandleLoginResult(user);
            }
            catch (Exception ex)
            {
                HandleLoginError(ex);
            }
            finally
            {
                _isLoggingIn = false;
                EnableLoginControls();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_loginView.useremail))
            {
                _loginView.ShowMessage("Please enter your email address.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(_loginView.password))
            {
                _loginView.ShowMessage("Please enter your password.");
                return false;
            }

            if (!IsValidEmail(_loginView.useremail))
            {
                _loginView.ShowMessage("Please enter a valid email address.");
                return false;
            }

            return true;
        }

        private async Task<Users?> AttemptLoginAsync()
        {
            try
            {
                return await _authService.Login(_loginView.useremail.Trim(), _loginView.password.Trim());
            }
            catch (Exception)
            {
                throw; // Let the calling method handle the error
            }
        }

        private void HandleLoginResult(Users? user)
        {
            if (user == null)
            {
                _loginView.ShowMessage("Invalid email or password. Please try again.");
                return;
            }

            try
            {
                // Create and show main view with user information
                IMainView mainView = new MainView();
                new MainPresenter(mainView, user); // Pass the logged-in user

                _loginView.ShowMessage("Login successful!");
                _loginView.DialogResult = DialogResult.OK;
                _loginView.HideForm();
                mainView.ShowForm();
            }
            catch (Exception ex)
            {
                HandleLoginError(ex);
            }
        }

        private void HandleLoginError(Exception ex)
        {
            string errorMessage = "An error occurred during login. ";

            // Add more specific error messages based on exception type
            if (ex is System.Net.WebException)
            {
                errorMessage += "Please check your internet connection.";
            }
            else
            {
                errorMessage += "Please try again later.";
            }

            _loginView.ShowMessage(errorMessage);
            // Log the error for debugging (implement logging as needed)
            System.Diagnostics.Debug.WriteLine($"Login Error: {ex}");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void DisableLoginControls()
        {
            // If ILoginView has these properties, add them to the interface
            if (_loginView is LogInView loginView)
            {
                loginView.Login_button.Enabled = false;
                loginView.Emtextbox.Enabled = false;
                loginView.PassTextBox.Enabled = false;
            }
        }

        private void EnableLoginControls()
        {
            // If ILoginView has these properties, add them to the interface
            if (_loginView is LogInView loginView)
            {
                loginView.Login_button.Enabled = true;
                loginView.Emtextbox.Enabled = true;
                loginView.PassTextBox.Enabled = true;
            }
        }
    }
}