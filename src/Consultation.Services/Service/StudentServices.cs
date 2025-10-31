using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Repository;
using Consultation.Repository.Repository;
using Consultation.Repository.Repository.IRepository;
using Consultation.Services.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Services.Service
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;

        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        //This is for mobile, to get the needed student information
        public async Task<Student?> GetStudentInformation(string studentUMID)
        {
            return await _studentRepository.GetStudentInformation(studentUMID);
        }

        public async Task<List<EnrolledCourse?>> GetStudentEnrolledCourses(int id, Consultation.Domain.Enum.Semester sum)
        {
            return await _studentRepository.GetStudentEnrolledCourses(id,sum); 
        }

        public async Task<List<EnrolledCourse?>> GetStudentEnrolledCourses(int id)
        {
            return await _studentRepository.GetStudentEnrolledCourses(id);
        }


        public async Task<List<ConsultationRequest>> GetStudentConsultationRequests(int id)
        {
           return await _studentRepository.GetStudentConsultationRequests(id);
        }

        public async Task<List<EnrolledCourse?>> GetStudentEnrolledCoursesByTerm(Semester sem)
        {
            return await _studentRepository.GetStudentEnrolledCoursesByTerm(sem);
        }
       
    }
   
}
