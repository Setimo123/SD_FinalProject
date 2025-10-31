using Consultation.Domain;
using Consultation.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Services.Service.IService
{
    public interface IStudentServices
    {
        Task<Student?> GetStudentInformation(string studentUMID);

        Task<List<EnrolledCourse?>> GetStudentEnrolledCourses(int id, Consultation.Domain.Enum.Semester sum);

        Task<List<EnrolledCourse?>> GetStudentEnrolledCourses(int id);

        Task<List<ConsultationRequest>> GetStudentConsultationRequests(int id);

        Task<List<EnrolledCourse?>> GetStudentEnrolledCoursesByTerm(Semester sem);
    }
}
