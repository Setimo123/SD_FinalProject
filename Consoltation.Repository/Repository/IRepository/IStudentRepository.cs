using Consultation.Domain;
using Consultation.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository.Repository.IRepository
{
    public interface IStudentRepository
    {

        Task<Student> GetStudentInformation(string studentUMNumber);

        Task<List<EnrolledCourse?>> GetStudentEnrolledCourses(int id, Consultation.Domain.Enum.Semester sum);

        Task<List<EnrolledCourse?>> GetStudentEnrolledCourses(int id);

        Task<List<ConsultationRequest>> GetStudentConsultationRequests(int id,
            Consultation.Domain.Enum.Status status);

        Task<List<EnrolledCourse?>> GetStudentEnrolledCoursesByTerm(Semester sem);

        Task<List<ConsultationRequest>> GetAllStudentConsultationRequests(int id);
    }
}
