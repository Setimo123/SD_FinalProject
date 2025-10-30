using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Consultation.Domain;
using Consultation.Services.Service.IService;
using System.Collections.ObjectModel;
using UM_Consultation_App_MAUI.MvvmHelper;
using UM_Consultation_App_MAUI.MvvmHelper.Interface;


namespace UM_Consultation_App_MAUI.ViewModels
{

    public partial class ResponseViewModel : ObservableObject
    {
        public ObservableCollection<Response> Responses { get; set; } = new ObservableCollection<Response>();
        public ObservableCollection<string> Options { get; set; } = new ObservableCollection<string>();
        private readonly IStudentServices _studentServices;
        private readonly ILoadingServices _loadingServices;


        private string selectedSemester;

        public string SelectedSemester
        {
            get => selectedSemester;
            set => SetProperty(ref selectedSemester, value);
        }

        public ResponseViewModel(IStudentServices studentServices,ILoadingServices 
            loadingservices)
        {
            _loadingServices = loadingservices;
            _studentServices = studentServices;
        }

        [RelayCommand]
        private async void LoadResponses()
        {
            try
            {
                _loadingServices.Show();
                await Task.Delay(1000);
                Responses.Clear();
                Options.Clear();
                Options.Add("All");
                var student = LoginViewModel.Student;
               
                var list = await _studentServices.GetAllStudentConsultationRequests(student.StudentID);
                var s = await _studentServices.GetStudentEnrolledCourses(student.StudentID);

                foreach (var y in s.DistinctBy(sy => sy.SchoolYearID == student.SchoolYearID))
                {
                    if (y.SchoolYear.Semester != Consultation.Domain.Enum.Semester.Summer)
                    {
                        string ComboBoxFormat
                         = $"{Helper.GetSemesterName(y.SchoolYear.Semester)}" +
                            $" {y.SchoolYear.Year1} - {y.SchoolYear.Year2}";
                        Options.Add(ComboBoxFormat);
                    }
                }
               
                foreach (var i in list)
                {
                    Responses.Add(
                        new Response(i.ConsultationID, i.SubjectCode, i.Faculty.FacultyName, i.StartedTime.ToString()
                        ,i.EndedTime.ToString(), i.DateSchedule.ToString(), i.Status.ToString()));
                }
            }
            finally
            {
                _loadingServices.Hide();
            }
        }
     }
    
       public partial class Response : ObservableObject
      {
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string courseCode;

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string dateStarted;

        [ObservableProperty]
        public string dateEnded;

        [ObservableProperty]
        public string schedule;

        [ObservableProperty]
        public string status;

        [ObservableProperty]
        public Color statusColor;

        public Response(int Id,string coursecode,string Name,string datestarted,string dateended
            ,string Schedule, string Status)
        {
            id = Id;
            name = Name;
            dateStarted = datestarted;
             dateEnded = dateended;
            schedule = Schedule;
            status = Status;
            courseCode = coursecode;
            statusColor = Status switch
            {
                "Approved" => Colors.Green,
                "Declined" => Colors.Red,
                "Pending" => Colors.Orange,
                _ => Colors.Gray
            };

        }

    }
}
