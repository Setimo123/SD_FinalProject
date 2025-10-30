using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using Consultation.Domain;
using Consultation.Service;
using Consultation.Service.IService;
using Consultation.Services.Service.IService;
using UM_Consultation_App_MAUI.ViewModels;


namespace UM_Consultation_App_MAUI.Views.Common;

public partial class ChangePassword : Popup
{
    private readonly IAuthService _authService;
    private bool result { get; set; }
    public ChangePassword(IAuthService authService)
	{
        _authService = authService;
        InitializeComponent();
	}
	
	private void OnCancelClicked(object sender, EventArgs e)
	{
        Close();
    }

    private async void OnUpdateClicked(object sender, EventArgs e)
	{
        if (
            string.IsNullOrWhiteSpace(NewPasswordEntry.Text) ||
            string.IsNullOrWhiteSpace(ConfirmPasswordEntry.Text))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }
        if (ConfirmPasswordEntry.Text != NewPasswordEntry.Text)
        {
            MvvmHelper.Helper.DisplayMessage("Password does not match");
            return;
        }

        Student student = LoginViewModel.Student;
        Faculty faculty = LoginViewModel.Faculty;
        if (student == null || faculty == null)
        {
            MvvmHelper.Helper.DisplayMessage($"Hello world");
            return;
        }
         

        if (LoginViewModel.AccountVerification == true)
        {
            Message(await 
                _authService.ChangePassword(NewPasswordEntry.Text, student.Email, OldPasswordEntry.Text));
            return;
        }
        if (LoginViewModel.AccountVerification == false)
        {
            Message(await
              _authService.ChangePassword(NewPasswordEntry.Text, faculty.FacultyEmail, OldPasswordEntry.Text));
            return;
        }
        Close(true);
    }

    private void Message(bool result)
    {
        if (result)
            MvvmHelper.Helper.DisplayMessage("Password changed successfully.");
        else
            MvvmHelper.Helper.DisplayMessage($"Password changed was not successful. {OldPasswordEntry.Text}");
    }
}  