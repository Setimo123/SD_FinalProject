using Consultation.Domain;
using Consultation.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Service.IService
{
    public interface IConsultationRequestServices
    {
        Task<int> TotalPendingConsultation(string programName, Status status);
        Task<List<ConsultationRequest>> ListOfConsultation(string programName);

        Task<Student> GetStudentInformation(string StudentID);

        Task<Faculty> GetFacultyInformation(int facultyID);

        Task<List<ConsultationRequest>> GetStudentPendingList(string studentUMID, Status status);

        string ErrorMessage();

    }
}
