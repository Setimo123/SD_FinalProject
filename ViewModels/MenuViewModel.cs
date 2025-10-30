using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Consultation.Domain;
using Consultation.Service;
using Consultation.Service.IService;
using Microsoft.Maui.Storage;
using Microsoft.VisualStudio.Telemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM_Consultation_App_MAUI.MvvmHelper.Interface;
using UM_Consultation_App_MAUI.Views.Common;

namespace UM_Consultation_App_MAUI.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {

        [ObservableProperty]
        private string studentname;

        [ObservableProperty]
        private string course;


        [ObservableProperty]
        private string email;

        private readonly IAuthService _authService;
        private readonly ILoadingServices _loadingScreen;
        private readonly ChangePassword _changePassword;

        public static string UmId { get; set; }

        public MenuViewModel(IAuthService authService, ILoadingServices loadingScreen,ChangePassword cp)
        {
            _changePassword = cp;
            DisplayStudentInformation();
            _authService = authService;
            _loadingScreen = loadingScreen;
        }

       private async void DisplayStudentInformation()
       {
            Student student = LoginViewModel.Student;
            Faculty faculty = LoginViewModel.Faculty;
            if (student == null || faculty == null) return;

            if (LoginViewModel.AccountVerification == true)
            {
                Studentname = student.StudentName;
                UmId = student.StudentUMID;
                Email = student.Email;
                Course = student.Program.Description;
                return;
            }
            if (LoginViewModel.AccountVerification == false)
            {
                Studentname = faculty.FacultyName;
                UmId = faculty.FacultyUMID;
                Email = faculty.FacultyEmail;
                Course = faculty.Program.Description;
                return;
            }
        }

        [RelayCommand]
        private async Task ChangePassword()
        {
            var result = await Application.Current.MainPage.ShowPopupAsync(_changePassword);

            if (result is true)
            {
                MvvmHelper.Helper.DisplayMessage("Password changed successfully.");
            }
            else
            {
                MvvmHelper.Helper.DisplayMessage("Password was not cancelled.");
            }
        }

        [RelayCommand]
        public async void LogoutButton()
        {
            //navigate back to the log-in page

            bool option = await MvvmHelper.Helper.DisplayOption(
                     $"Are you sure you want to log out?",
                    "Log out",
                     "Cancel");
            if (option == true)
            {
                Application.Current.MainPage = new AppShell();

                await Shell.Current.GoToAsync("//LoginPage");
                return;
            }
            if (option == false)
            {
                return;
            }
         

        }
    }
}
