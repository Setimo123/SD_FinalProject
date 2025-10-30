using UM_Consultation_App_MAUI.ViewModels;

namespace UM_Consultation_App_MAUI.Views;


public partial class CreateAccountPage : ContentPage
{
    bool isPasswordHidden = true;
    bool isConfirmPasswordHidden = true;
    public CreateAccountPage(CreateAccountViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }


    private void TogglePasswordVisibility(object sender, EventArgs e)
    {
        isPasswordHidden = !isPasswordHidden;
        txtboxPassword.IsPassword = isPasswordHidden;
        btnPasswordEye.Source = isPasswordHidden ? "eyeclosed.png" : "eyeopen.png";
    }

    private void ToggleConfirmPasswordVisibility(object sender, EventArgs e)
    {
        isConfirmPasswordHidden = !isConfirmPasswordHidden;
        txtboxConfirmPassword.IsPassword = isConfirmPasswordHidden;
        btnConfirmPasswordEye.Source = isConfirmPasswordHidden ? "eyeclosed.png" : "eyeopen.png";
    }

    private void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
    {
        string password = txtboxPassword.Text;
        string confirmPassword = txtboxConfirmPassword.Text;
        lblPasswordMatch.IsVisible = false;
        iconStatus.IsVisible = false;

        if (!string.IsNullOrEmpty(password) || !string.IsNullOrEmpty(confirmPassword))
        {
            lblPasswordMatch.IsVisible = true;
            iconStatus.IsVisible = true;

            if (password == confirmPassword)
            {
                lblPasswordMatch.Text = "Passwords match!";
                lblPasswordMatch.TextColor = Colors.Green;
                iconStatus.Source = "checkicon.png";
                btnSignUp.BackgroundColor = Color.FromArgb("#b61c1c");
                btnSignUp.TextColor = Colors.White;
                btnSignUp.IsEnabled = true;
            }
            else
            {
                lblPasswordMatch.Text = "Passwords do not match";
                lblPasswordMatch.TextColor = Colors.OrangeRed;
                iconStatus.Source = "dissaproveicon.png";
                btnSignUp.BackgroundColor = Colors.LightPink;
                btnSignUp.TextColor = Colors.White;
                btnSignUp.IsEnabled = false;
            }
        }
        else
        {
            lblPasswordMatch.IsVisible = false;
        }
    }
}
