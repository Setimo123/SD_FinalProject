using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Infrastructure.Data;
using Consultation.Repository.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) => _context = context;


        //For mobile repository
        public async Task<Student> GetStudentInformation(string studentUMNumber)
        {
            try
            {
                var students = _context.Students
                      .AsNoTracking()
                       .AsSplitQuery()
                       .Include(s => s.SchoolYear)
                       .ThenInclude(s => s.EnrolledCourses)
                       .Include(s => s.ConsultationRequests)
                       .Include(s => s.Program)
                       .FirstOrDefaultAsync(s => s.StudentUMID == studentUMNumber);
                return await students ?? new Student();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Student Repository Error: {ex.Message}");
                return new Student();
            }
        }

        public async Task<List<EnrolledCourse?>> 
            GetStudentEnrolledCourses(int id, Consultation.Domain.Enum.Semester sum)
        {
            try
            {
              var enrolledcourse = await _context.EnrolledCourse
                    .Include(f => f.Faculty)
                    .Include(sc => sc.SchoolYear).Where(sy => sy.SchoolYear.Semester == 
                    sum)
                    .Include(ec => ec.Student).Where(s => s.StudentID == id)
                    .ToListAsync();
                return enrolledcourse ?? new List<EnrolledCourse>();
            }
            catch (Exception ex)    
            {
                Console.WriteLine($"Student Repository Error: {ex.Message}");
                return new List<EnrolledCourse>();
            }
        }


        public async Task<List<EnrolledCourse?>> GetStudentEnrolledCourses(int id)
        {
            try
            {
                var enrolledcourse = await _context.EnrolledCourse
                      .Include(f => f.Faculty)
                      .Include(sc => sc.SchoolYear)
                      .Where(sy => sy.SchoolYear.Semester != Consultation.Domain.Enum.Semester.Summer)

                      .Include(ec => ec.Student).Where(s => s.StudentID == id)
                      .ToListAsync();
                return enrolledcourse ?? new List<EnrolledCourse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Student Repository Error: {ex.Message}");
                return new List<EnrolledCourse>();
            }
        }

        public async Task<List<EnrolledCourse?>> GetStudentEnrolledCoursesByTerm(Semester sem)
        {
            try
            {
                var enrolledcourse = await _context.EnrolledCourse
                      .Include(f => f.Faculty)
                      .Include(sc => sc.SchoolYear).Where(sy => sy.SchoolYear.Semester == sem)
                      .ToListAsync();
                return enrolledcourse ?? new List<EnrolledCourse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Student Repository Error: {ex.Message}");
                return new List<EnrolledCourse>();
            }
        }

        public async Task<List<ConsultationRequest>> GetAllStudentConsultationRequests(int id)
        {
            var consultationRequests = await _context.ConsultationRequest
                .Include(cr => cr.Student)
                .Where(cr => cr.StudentID == id)
                .ToListAsync();
            return consultationRequests;
        }

        public async Task<List<ConsultationRequest>> GetStudentConsultationRequests(int id,
            Consultation.Domain.Enum.Status status)
        {
            var consultationRequests = await _context.ConsultationRequest
                .Include(cr => cr.Student)
                .Where(cr => cr.StudentID == id && cr.Status == status)
                .ToListAsync();
            return consultationRequests;
        }
    }
}
