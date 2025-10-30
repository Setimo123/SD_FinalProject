using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Repository.Repository.IRepository;
using Consultation.Service;
using Consultation.Service.IService;
using Consultation.Services.Service;
using Consultation.Services.Service.IService;
using Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM_Consultation_App_MAUI.MvvmHelper;
using UM_Consultation_App_MAUI.MvvmHelper.Interface;


namespace UM_Consultation_App_MAUI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {

        [ObservableProperty]
        private string studentname;

        [ObservableProperty]
        private string umid;

        [ObservableProperty]
        private string schoolyear;

        [ObservableProperty]
        private string program;

        [ObservableProperty]
        private string useryearlevel;

        [ObservableProperty]
        private string pendingconsultation;

        [ObservableProperty]
        private bool refereshing;

        private readonly ILoadingServices _loadingservices;
        private readonly IStudentServices _studentservices;

        public HomeViewModel(ILoadingServices loadingservices,
            IStudentServices studentServices)
        {
            _loadingservices = loadingservices;
            _studentservices = studentServices; 
            DisplayStudentUserInformation();

        }

        private async void DisplayStudentUserInformation()
        {
            try
            {
                Student StudentInfo = LoginViewModel.Student;
                if (StudentInfo == null)
                {
                    Studentname = "No name";
                    return;
                }

            }
            catch (Exception ex)
            {
                Helper.DisplayMessage($"{ex.Message}");
            }
        }
        private void UserInformation(Student studentInfo)
        {
            List<string> fullname = Helper.StringSplitter(' ', studentInfo.StudentName);

            string firstNames = string.Empty;
            string lastName = fullname[fullname.Count - 1];

            for (int i = 0; i < fullname.Count - 1; i++)
            {
                firstNames += fullname[i] + " ";
            }

            Studentname = $"{lastName}, {firstNames.TrimEnd()}";

            Umid = studentInfo.StudentUMID;
            Schoolyear = $"{Helper.GetSemesterName(studentInfo.SchoolYear.Semester)} " +
                $"{studentInfo.SchoolYear.Year1}-{studentInfo.SchoolYear.Year2}";

            Useryearlevel = $"{Helper.GetYearLevelName(studentInfo.yearLevel)} Bachelors of ";
            Program = $"{studentInfo.Program.Description}";
        }

        [RelayCommand]
        public async Task Refresh()
        {
            try
            {
                _loadingservices.Show();
                 await Task.Delay(1000);
                    Student StudentInfo = LoginViewModel.Student;
                    UserInformation(StudentInfo);
                    var totalConsultation = await
                        _studentservices.GetStudentConsultationRequests(StudentInfo.StudentID,
                        Consultation.Domain.Enum.Status.Pending);
                    Pendingconsultation = (totalConsultation?.Count ?? 0).ToString();

            }
            finally
            {
                _loadingservices.Hide();
            }
        }
    }
}
