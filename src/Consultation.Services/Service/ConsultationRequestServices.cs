using Consultation.App.Repository;
using Consultation.App.Repository.IRepository;
using Consultation.Service.IService;
using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultation.Repository;
using Consultation.Repository.IRepository;
using Consultation.Repository.Repository.IRepository;
using Consultation.Services.Service.IService;
using Consultation.Repository.Repository;

namespace Consultation.Service
{
    public class ConsultationRequestServices : IConsultationRequestServices
    {
        private readonly IConsultationRequestRepository _repository;
        private readonly IAuthRepository _userRepository;
        private readonly IStudentRepository _studentServices;
        public ConsultationRequestServices(AppDbContext context)
        {
            _repository = new ConsultationRequestRepository(context);
            _userRepository = new UserRepository(context);
            _studentServices = new StudentRepository(context);
        }
        //Desktop Services
        //Getting the total list by int which one number
        public async Task<int> TotalPendingConsultation(string programName, Status status)
        {
            try
            {
                var consultations = await _repository.GetConsultation(programName);

                if (consultations == null)
                    return 0;

                int totalpending = consultations.Where(c => c.Status == status).Count();
                return totalpending;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ConsultationRequestServices Error{ex.Message}");
                return 0;
            }
        }

        public async Task<List<ConsultationRequest>> ListOfConsultation(string programName)
        {
            try
            {
                var consultations = await _repository.GetConsultation(programName);
                if (consultations == null)
                    Console.WriteLine("Error on the list");
                return consultations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message: {ex.Message}");
                return new List<ConsultationRequest>();
            }
        }

        public async Task<Faculty> GetFacultyInformation(int facultyID)
        {
            try
            {
                var consultationFacultyInfo = await _repository.GetFacultyaInfoConsultationRequests(facultyID);

                if (consultationFacultyInfo.Faculty == null)
                    Console.WriteLine("No faculty information found.");

                return new Faculty
                {
                    FacultyName = consultationFacultyInfo.Faculty.FacultyName
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message: {ex.Message}");
                return null;
            }
        }

        public async Task<Student> GetStudentInformation(string studentUMID)
        {
            try
            {
                var consultationStudentInfo = await _repository.GetStudentInformation(studentUMID);

                if (consultationStudentInfo == null)
                    Console.WriteLine("No student information found.");

                return new Student
                {
                    StudentName = consultationStudentInfo.StudentName
                };
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error Message: {ex.Message}");
                //return null;
                return new Student
                {
                    StudentName = $"Error Message {ex.Message}",
                };
            }
        }
        public string ErrorMessage()
        {
            return message;
        }
        //For mobile display the number of the consultations

        private string message = "";
        public async Task<List<ConsultationRequest>> GetStudentPendingList(string studentUMID, Status status)
        {
            try
            {
                var studentConsultation = await _studentServices.GetStudentInformation(studentUMID);


                if (studentConsultation == null || studentConsultation.ConsultationRequests == null)
                    return new List<ConsultationRequest>();



                List<ConsultationRequest> filteredStatus = studentConsultation.ConsultationRequests
                    .Where(x => x.Status == status).ToList();

                return filteredStatus;

            }
            catch (Exception ex)
            {
                message = $"error message {ex.Message}";
                return new List<ConsultationRequest>();
            }
        }


    }
}
