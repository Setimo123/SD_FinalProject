using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Consultation.Service;
using Consultation.Service.IService;
using Consultation.Services.Service.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UM_Consultation_App_MAUI.MvvmHelper.Interface;

namespace UM_Consultation_App_MAUI.ViewModels
{
    //Gi add ra nako kay na libog ko kung asa butang ang viewmodel para sa RequestConsultationPage.
    // balhin ra nako ni kung makabalo nako asa ang ViewModel sa RequestConsultationPage.
    public partial class RequestConsultationViewModel : ObservableObject
    {
        public ObservableCollection<EnrolledCourse> AvailableCourses { get; } = new();

        [ObservableProperty] private EnrolledCourse? selectedCourse;

        [ObservableProperty] private string courseCode = string.Empty;

        [ObservableProperty] private string courseInstructor = string.Empty;

        [ObservableProperty] private string studentname = string.Empty;

        [ObservableProperty] private string studentumid = string.Empty;

        [ObservableProperty] private DateTime dateOfConsultation = DateTime.Today;

        [ObservableProperty] private string? selectedStartTimeText; 

        [ObservableProperty] private string? selectedEndTimeText;   

        [ObservableProperty] private string? concern;


        private readonly ILoadingServices _loadingScreen;
        public RequestConsultationViewModel(IStudentServices studetnServices,
            IConsultationRequestServices consultationRequestServices, ILoadingServices loadingservices,
            IFacultyServices facultyServices)
        {
            _consultationRequestServices = consultationRequestServices;
            _studentServices = studetnServices;
            _loadingScreen = loadingservices;
        }


        [RelayCommand]
        private async Task DisplayUserInformationOption()
        {
  
            var fullname = MvvmHelper.Helper.StringSplitter(' ', 
                LoginViewModel.Student.StudentName);
            var last = fullname.Last();
            var firsts = string.Join(" ", fullname.Take(fullname.Count - 1));
            Studentname = $"{last}, {firsts}";
            Studentumid = LoginViewModel.Student.StudentUMID;

            var list = await _studentServices.GetStudentEnrolledCourses(
                LoginViewModel.Student.StudentID, RequestViewModel.Semester);

            AvailableCourses.Clear();
            foreach (var c in list)             
                AvailableCourses.Add(c);
        }

        [RelayCommand]
        public async Task FileConsultationClick()
        {
            try
            {
                _loadingScreen.Show();
                if (string.IsNullOrWhiteSpace(SelectedStartTimeText) ||
               string.IsNullOrWhiteSpace(SelectedEndTimeText))
                {
                    MvvmHelper.Helper.DisplayMessage("Please choose start and end time.");
                    return;
                }
                if (!TimeOnly.TryParseExact(SelectedStartTimeText, "h:mm tt",
                    CultureInfo.InvariantCulture,DateTimeStyles.None, out var start))
                {
                    MvvmHelper.Helper.DisplayMessage("Invalid start time.");
                    return;
                }
                if (!TimeOnly.TryParseExact(SelectedEndTimeText, "h:mm tt",
                    CultureInfo.InvariantCulture,DateTimeStyles.None, out var end))
                {
                    MvvmHelper.Helper.DisplayMessage("Invalid end time.");
                    return;
                }
                var studentId = LoginViewModel.Student.StudentID;
                var facultyId = SelectedCourse.Faculty?.FacultyID ?? 0;
                var subjectCode = SelectedCourse.CourseCode;
                var subjectName = SelectedCourse.CourseName;
                var programName = LoginViewModel.Student.Program.ProgramName;

                await _consultationRequestServices.AddConsultation(
               subjectCode,
               subjectName,
               start,
               end,
               studentId,
               facultyId,
               programName,
               Concern ?? string.Empty,
               DateOnly.FromDateTime(DateOfConsultation)
                 );
                MvvmHelper.Helper.DisplayMessage("Consultation request submitted Successfully.");
            }
            finally
            {
                _loadingScreen.Hide();
            }
        }

        partial void OnSelectedCourseChanged(EnrolledCourse? value)
        {
            CourseCode = value?.CourseCode ?? string.Empty;
            CourseInstructor = value?.Faculty?.FacultyName ?? string.Empty;
        }

        [RelayCommand]
        public async Task BackNavigation()
        {
            AvailableCourses.Clear();
            await Shell.Current.GoToAsync("///Student");
        }

        private readonly IStudentServices _studentServices;
        private readonly IConsultationRequestServices _consultationRequestServices;
        private readonly IFacultyServices _facultyServices; 
    }
}
