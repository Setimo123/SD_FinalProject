using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Service.IService;
using Consultation.Services.Service;
using Consultation.Services.Service.IService;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UM_Consultation_App_MAUI.MvvmHelper;
using UM_Consultation_App_MAUI.MvvmHelper.Interface;
using UM_Consultation_App_MAUI.Views.StudentView;

namespace UM_Consultation_App_MAUI.ViewModels
{

    [QueryProperty(nameof(Semester), "Semester")]
    public partial class RequestViewModel : ObservableObject
    {
        public ObservableCollection<StudentEnrolledCourses> EnrolledCourselist { get; } = new ObservableCollection<StudentEnrolledCourses>();
        public ObservableCollection<string> SchoolYear {  get; } = new ObservableCollection<string>();

        private readonly ILoadingServices _loadingScreen;

        private string selectedSchoolYear;
        public string SelectedSchoolYear
        {
            get => selectedSchoolYear;
            set => SetProperty(ref selectedSchoolYear, value);
        }

        public static string SelectedStudentSchoolYear = string.Empty;

        public RequestViewModel(IAuthService authService,IStudentServices studentServices,
            ILoadingServices loadingScreen)
        {
            _authService = authService;
            _studentServices = studentServices;
            _loadingScreen = loadingScreen;
            DisplayEnrolledCourses();
        }

        private async void DisplayEnrolledCourses()
        {
            Student StudentInfo = LoginViewModel.Student;

            try
            {
                var s = await _studentServices.GetStudentEnrolledCourses(StudentInfo.StudentID);

                foreach (var x in s)
                {
                    EnrolledCourselist.Add(
                   new StudentEnrolledCourses(x.CourseCode,x.CourseName,x.Faculty.FacultyName));

                }
               
                foreach (var y in s.DistinctBy(sy => sy.SchoolYearID == StudentInfo.SchoolYearID))
                {
                   
                    if (y.SchoolYear.Semester != Consultation.Domain.Enum.Semester.Summer)
                    {
                        string ComboBoxFormat
                         = $"{Helper.GetSemesterName(y.SchoolYear.Semester)}" +
                            $" {y.SchoolYear.Year1} - {y.SchoolYear.Year2}";
                        SchoolYear.Add(ComboBoxFormat);
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.DisplayMessage($"{ex.Message}");
            }

        }

        [RelayCommand]
        private async Task RequestConsultationClick()
        {
            //Condition if the user does not select a semester
            try
            {
                _loadingScreen.Show();
                if (string.IsNullOrEmpty(SelectedSchoolYear))
                {
                    MvvmHelper.Helper.DisplayMessage($"Please Select a Semester");
                    return;
                }
                string value = $"{SelectedSchoolYear.Split(' ')[0]} {SelectedSchoolYear.Split(' ')[1]}";
                switch (value)
                {
                    case "First Semester":
                        Semester = Consultation.Domain.Enum.Semester.Semester1;
                        break;

                    case "Second Semester":
                        Semester = Consultation.Domain.Enum.Semester.Semester2;
                        break;

                    case "Summer Semester":
                        Semester = Consultation.Domain.Enum.Semester.Summer;
                        break;
                }
                //Route the shell based on the semester
                await Shell.Current.GoToAsync($"//RequestConsultationPage?Semester={Semester}");
            }
            finally
            {
                _loadingScreen.Hide();
            }
        }

        //Interface Call (Optional)
        private readonly IAuthService _authService;

        private readonly IStudentServices _studentServices;

        public static Consultation.Domain.Enum.Semester Semester;
    }


    public partial class StudentEnrolledCourses : ObservableObject
    {
        [ObservableProperty]
        private string coursecode;

        [ObservableProperty]
        private string coursename;

        [ObservableProperty]
        private string instructorname;

        public StudentEnrolledCourses(string _coursecode, string _coursename, string _instructorname)
        {
            coursecode =  _coursecode;
            coursename = _coursename;
            instructorname = _instructorname;
        }
    }
}
