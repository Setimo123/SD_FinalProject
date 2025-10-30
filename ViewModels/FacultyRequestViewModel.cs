using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Consultation.Domain;
using Consultation.Repository.Repository.IRepository;
using Microsoft.VisualStudio.Telemetry;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UM_Consultation_App_MAUI.MvvmHelper.Interface;

namespace UM_Consultation_App_MAUI.ViewModels
{
    public partial class FacultyRequestViewModel : ObservableObject
    {
        public ObservableCollection<RequestList> PendingRequests { get; set; } 
            = new ObservableCollection<RequestList>();

        private readonly ILoadingServices _loadingServices;

        private readonly IFacultyRepository _faculty;
        public FacultyRequestViewModel(IFacultyRepository faculty,ILoadingServices loadingServices)
        {
            _loadingServices = loadingServices;
            _faculty = faculty;

        }

        [RelayCommand]
        private async Task DisplayConsultataion()
        {
            try
            {
                _loadingServices.Show();
                await Task.Delay(1000);
                PendingRequests.Clear();
                Faculty faculty = LoginViewModel.Faculty;
                var facultyConsultation = await _faculty.FacultyConsultation(faculty.FacultyID);

                var sortStatus = facultyConsultation.Where(fc =>
                 fc.Status == Consultation.Domain.Enum.Status.Pending).ToList();

                if (faculty == null) return;

                if (sortStatus.Count == 0)
                {
                    MvvmHelper.Helper.DisplayMessage("No Consultation Request");
                    return;
                }

                foreach (var i in sortStatus)
                {
                    PendingRequests.Add(new RequestList(
                        i.ConsultationID,
                        i.SubjectCode,
                        i.Student.StudentName,
                        i.DateSchedule.ToString("MM/dd/yyyy"),
                        $"{i.StartedTime} - {i.EndedTime}"
                        ));
                }
            }
            finally
            {
                _loadingServices.Hide();
            }
         
        }

        [RelayCommand]
        private async Task ApproveRequest(RequestList selected)
        {
            //Change the status of the request to approved
            int id = selected.Id; 
            
            bool option = await MvvmHelper.Helper.DisplayOption(
                $"Are you sure you want to approve this request?",
                "Yes",
                "No");
            if (option == true)
            {
                await _faculty.ChangeConsultationByID(id,Consultation.Domain.Enum.Status.Approved,"Approved");
                PendingRequests.Remove(selected);
                return;
            }
            if (option == false)
            {
                return;
            }
        }

        [RelayCommand]
        private async Task DisApproveRequest(RequestList selected)
        {
            int id = selected.Id;

            bool option = await MvvmHelper.Helper.DisplayOption(
                $"Are you sure you want to approve this request?",
                "Yes",
                "No");
            if (option == true)
            {
                string reason = await App.Current.MainPage.DisplayPromptAsync(
                    "Reason",
                    "Please state the reason why you disapprove this request",
                    "Ok",
                    "Cancel",
                    "Type reason here");
                await _faculty.ChangeConsultationByID(id, Consultation.Domain.Enum.Status.Disapproved, reason);
                PendingRequests.Remove(selected);
                return;
            }
            if (option == false)
            {
                return;
            }
        }
    }


    public partial class RequestList : ObservableObject
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string StudentName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public RequestList(int id, string courseCode, string studentName,string date, string time)
        {
            Id = id;
            CourseCode = courseCode;
            StudentName = studentName;
            Date = date;
            Time = time;

        }
    }
}
