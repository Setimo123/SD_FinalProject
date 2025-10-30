using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Consultation.Domain;
using Consultation.Service;
using Consultation.Service.IService;
using Consultation.Services.Service;
using Consultation.Services.Service.IService;
using System.Windows.Input;
using UM_Consultation_App_MAUI.Views;
using UM_Consultation_App_MAUI.MvvmHelper.Interface;

namespace UM_Consultation_App_MAUI.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isPasswordHidden = true;

        [ObservableProperty]
        private string passwordhashed = "eyeclosed.png";

        [ObservableProperty]
        private bool isBusy;



        [RelayCommand]
        private void TogglePasswordVisibility()
        {
            IsPasswordHidden = !IsPasswordHidden;
            UpdateIcon();
        }

        private void UpdateIcon()
        {
            passwordhashed = IsPasswordHidden ? "eyeclosed.png" : "eyeopen.png";
        }

        public LoginViewModel(IAuthService authService,IStudentServices studetnServices,
            IFacultyServices facultyServices, ILoadingServices loadingScreen, 
            IConsultationRequestServices requestServices)
        {
            _loadingScreen = loadingScreen;
            _facultyServices = facultyServices;
            _authService = authService;
            _studentServices = studetnServices;
            _requestServices = requestServices;
        }


        //Command for the log-in button
        [RelayCommand]
        private async Task ClickLogIn()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.None)
            {
                MvvmHelper.Helper.DisplayMessage("No Internet Connection");
            }
            else
            {
                try
                {
                    _loadingScreen.Show();
                    await Task.Delay(1000);
                    Users studentUsers = await _authService.Login(Email, Password, "Student");
                    Users facultyUsers = await _authService.Login(Email, Password, "Faculty");

                    if (studentUsers != null)
                    {

                        await StudentInformation(studentUsers.UMID);
                        await Shell.Current.GoToAsync($"///Student");
                        AccountVerification = true;
                        return;
                    }
                    else if (facultyUsers != null)
                    {
                        await FacultyInformation(facultyUsers.UMID);
                        await Shell.Current.GoToAsync("///FacultyHomePage");
                        AccountVerification = false;
                        return;
                    }
                    else
                    {
                        _loadingScreen.Hide();
                        MvvmHelper.Helper.DisplayMessage("Invalid Credential");
                        return;
                    }
                }
                finally
                {
                    _loadingScreen.Hide();
                }
            }        
        }

        [RelayCommand]
        private async Task LoadProgram()
        {
            foreach (var i in await _requestServices.GetProgram())
            {
                ProgramList.Add(i.Description);
            }
        }

        //Command to route the create account
        [RelayCommand]
        private async Task CreateAccountClick()
        {
            try
            {
                _loadingScreen.Show();
                await Shell.Current.GoToAsync("CreateAccountPage");
            }
            finally
            {
                _loadingScreen.Hide();
            }
        }

        private async Task StudentInformation(string userUMIDNumber)
        {
            Student = await _studentServices.GetStudentInformation(userUMIDNumber);
        }

        private async Task FacultyInformation(string userUMIDNumber)
        {
            Faculty = await _facultyServices.GetFacultyInformation(userUMIDNumber);
        }

        //Read only types or the Interface caller
        private readonly IAuthService _authService;

        private readonly IStudentServices _studentServices;

        private readonly IFacultyServices _facultyServices;

        private readonly IConsultationRequestServices _requestServices;

        //Statics function so all pages has the flexibility to access data that only needed
        public static Student Student { get; set; } = new Student();
        public static Faculty Faculty { get; set; } = new Faculty();
        public static bool AccountVerification { get; set; }

        public static List<string> ProgramList { get; set; } = new List<string>();
        public string userUMIDNumber { get; set; }

        private readonly ILoadingServices _loadingScreen;
    }
}
