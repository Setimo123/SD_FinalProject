using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Consultation.Service.IService;
using Consultation.Services.Service;
using Consultation.Services.Service.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UM_Consultation_App_MAUI.MvvmHelper.Interface;

namespace UM_Consultation_App_MAUI.ViewModels
{
    public partial class CreateAccountViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private readonly ILoadingServices _loadingScreen;
        private readonly IConsultationRequestServices _requestServices;
        public ObservableCollection<string> Usertypes { get; } = new ObservableCollection<string>();

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmpassword;

        [ObservableProperty]
        private string username;


        private string selectedUserType;

        public string SelectedUserType
        {
            get => selectedUserType;
            set => SetProperty(ref selectedUserType, value);
        }

        private string selectedYearLevel;

        public string SelectedYearLevel
        {
            get => selectedYearLevel;
            set => SetProperty(ref selectedYearLevel, value);
        }


        private string selectedProgramList;

        public string SelectedProgramList
        {
            get => selectedProgramList;
            set => SetProperty(ref selectedProgramList, value);
        }

        public CreateAccountViewModel(IAuthService authService,ILoadingServices 
            loadingservices,IConsultationRequestServices requestServices)
        {
            _requestServices = requestServices;
            _loadingScreen = loadingservices;
            _authService = authService;
            DisplayComboBox();
        }

        public void DisplayComboBox()
        {
            var list = LoginViewModel.ProgramList;
            Usertypes.Add("Student");
            Usertypes.Add("Faculty");
        }

        [RelayCommand]
        private async Task CreateAccoute()
        {    
            try
            {
                _loadingScreen.Show();
                await Task.Delay(1000);
                var emailPattern = @"^[a-zA-Z]+\.[a-zA-Z]+\.(\d{6})@umindanao\.edu\.ph$";
                var match = Regex.Match(Email, emailPattern, RegexOptions.IgnoreCase);
                string umid = match.Groups[1].Value;
             
                //Condition to check all fields
                if (string.IsNullOrWhiteSpace(Email)
                   || string.IsNullOrWhiteSpace(Password)
                   || string.IsNullOrWhiteSpace(Confirmpassword)
                   || string.IsNullOrWhiteSpace(SelectedUserType))
                {
                    MvvmHelper.Helper.DisplayMessage("Please fill in all fields");
                    return;
                }
                //Check if the Email is correct
                if (!match.Success)
                {
                    MvvmHelper.Helper.DisplayMessage("" +
                        "Incorrect Email Format. " +
                        "Please use your UM email " +
                        "(e.g., j.delacruz.123456@umindanao.edu.ph).");
                    return;
                }
           
                //Condition to check all password and confirm password
                if (Password != Confirmpassword)
                {
                    MvvmHelper.Helper.DisplayMessage("Password did not match");
                    return;
                }
                
                await _authService.CreateAccount(Username,Email,
                    Password,
                    UserTypeChecker(),
                    umid.ToString());
                
                MvvmHelper.Helper.DisplayMessage("Account has been Registered");
                return;
            }
            catch (Exception ex)
            {
                MvvmHelper.Helper.DisplayMessage($"{ex.Message}");
            }
            finally
            {
                _loadingScreen.Hide();
            }
        }


        private Consultation.Domain.Enum.UserType UserTypeChecker()
        {
            if(SelectedUserType == "Student")
            {
                return Consultation.Domain.Enum.UserType.Student;
            }
            if (SelectedUserType == "Faculty")
            {
                return Consultation.Domain.Enum.UserType.Faculty;
            }

            return Consultation.Domain.Enum.UserType.Admin;
        }
    }   
        public partial class Program : ObservableObject
        {

            [ObservableProperty]
            private string _programname;
            public Program(string programname)
            {
                _programname = programname;
            }
        }
 }
