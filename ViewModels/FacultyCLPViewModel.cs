using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Consultation.Domain;
using Consultation.Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM_Consultation_App_MAUI.MvvmHelper.Interface;

namespace UM_Consultation_App_MAUI.ViewModels
{
    public partial class FacultyCLPViewModel : ObservableObject
    {
        public ObservableCollection<Consultations> ConsultationsList { get; set; } = new ObservableCollection<Consultations>();
        private readonly IFacultyRepository _faculty;
        private readonly ILoadingServices _loadingservices;

        public FacultyCLPViewModel(IFacultyRepository faculty,ILoadingServices loadingServices)
        {
            _loadingservices = loadingServices;
            _faculty = faculty;
   

        }

        [RelayCommand]
        private async void DisplayConsultation()
        {
            try
            {
                _loadingservices.Show();
                await Task.Delay(1000);
                ConsultationsList.Clear();
                Faculty faculty = LoginViewModel.Faculty;
                var facultyConsultation = await _faculty.FacultyConsultation(faculty.FacultyID);
                if (facultyConsultation == null)
                {
                    MvvmHelper.Helper.DisplayMessage("No Consultation List");
                    return;
                }
                foreach (var x in facultyConsultation.Where(fc => fc.Status != Consultation.Domain.Enum.Status.Pending))
                {
                    ConsultationsList.Add(new Consultations
                        (
                        $"{x.ConsultationID.ToString()}",
                        $"{x.SubjectCode}",
                        $"{x.DateSchedule.ToString("MM/dd/yyyy")}",
                        $"{x.StartedTime.ToString("hh:mm tt") + " - " + x.EndedTime.ToString("hh:mm tt")}",
                        $"{x.Status.ToString()}",
                        $"{x.Student.StudentName}")
                        );
                }
            }
            finally
            {
                _loadingservices.Hide();
            }
         
        }
    }

    public partial class Consultations : ObservableObject
    {
        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private string coursecode;

        [ObservableProperty]
        private string date;

        [ObservableProperty]
        private string time;

        [ObservableProperty]
        private string studentname;

        [ObservableProperty]
        private Color statusColor;

        [ObservableProperty]
        private string status;

        public Consultations(string id, string coursecode, string date, string time, string status, string studentname)
        {
            Id = id;
            Coursecode = coursecode;
            Date = date;
            Time = time;
            Status = status;
            Studentname = studentname;
        }
    }


}
