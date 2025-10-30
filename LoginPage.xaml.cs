
using UM_Consultation_App_MAUI.ViewModels;

namespace UM_Consultation_App_MAUI;

public partial class LoginPage : ContentPage
{

    public LoginPage(LoginViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
	}


    private void TogglePasswordVisibility(object sender, EventArgs e)
    {
        //isPasswordHidden = !isPasswordHidden;
        //txtboxPassword.IsPassword = isPasswordHidden;
        //btnPasswordEye.Source = isPasswordHidden ? "eyeclosed.png" : "eyeopen.png";

        MvvmHelper.Helper.DisplayMessage("Hello World");
    }
    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    if (BindingContext is LoginViewModel vm)
    //    {
    //        await vm.LoadProgramCommand.ExecuteAsync(null);
    //    }
    //}
}