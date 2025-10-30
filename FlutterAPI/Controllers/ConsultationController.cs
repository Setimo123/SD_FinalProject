using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Infrastructure.Data;

using FlutterAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlutterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConsultationController: ControllerBase
    {
        private readonly AppDbContext _context;
        public ConsultationController(AppDbContext context)
        {
            _context = context;
        }

        //Screen 3.1 API
        [HttpPost]
        public IActionResult RequestConsultation([FromBody] ConsultationViewModel ConsultationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //query para sa student
            var student = _context.Students.FirstOrDefault(s => s.StudentName
            == ConsultationRequest.StudentName);

            //query para sa faculty
            var faculty = _context.Faculty.FirstOrDefault(f => f.FacultyName
            == ConsultationRequest.FacultyName);

            if (ConsultationRequest == null)
                return BadRequest("Request body is empty.");

            if (student == null)
                return NotFound("Student not found");

            if (faculty == null)
                return NotFound("Faculty not found");


            var consultation = new ConsultationRequest
            {
                Student = student,
                Faculty = faculty,
                SubjectCode = ConsultationRequest.CourseCode,
                DateSchedule = ConsultationRequest.DateOfConsultation,
                DisapprovedReason = ConsultationRequest.DisapprovedReason,
                Concern = ConsultationRequest.Concern,
                DateRequested = DateTime.Now,
            };


            _context.ConsultationRequest.Add(consultation);

            string message = $"{student.StudentName} has Request Consultation";
            var actionlogs = ActionLogController.ActionLogger(message, student.StudentName, 0, student.Users);

            _context.ActionLog.Add(actionlogs);
            _context.SaveChanges();

            return Ok(new { message = "Action Successful" });
        }

        ////Screen 4 
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ConsultationRequest>>> ShowConsultation(int studentId)
        //{
        //    var result = await _context.ConsultationRequest
        //    .Include(s => s.Student)
        //     .Include(s => s.Faculty)
        //     .Where(s => s.Student.StudentID == studentId)
        //       .ToListAsync();
        //    return Ok(result);
        //}

        ////Consultation Request
        //[HttpGet]
        //public IActionResult ConsultationRequest(int studentId)
        //{

        //    var student = _context.Students
        //       // .Include(s => s.SchoolYears)
        //        .Include(s => s.EnrolledCourses)
        //        .ThenInclude(c => c.Course)
        //        .Include(s => s.EnrolledCourses)
        //        .ThenInclude(c => c.Faculty)
        //        .FirstOrDefault(s => s.StudentID == studentId);
        //    if (student == null)
        //    {
        //        return NotFound("Student not found.");
        //    }

        //    var currentSchoolYear = student.SchoolYears
        //        .FirstOrDefault(sy => sy.SchoolYearStatus == SchoolYearStatus.Current);

        //    if (currentSchoolYear == null)
        //    {
        //        return NotFound("Current school year not found.");
        //    }

        //    // Convert tung sem nga enum into string
        //    string semesterString = currentSchoolYear.Semester switch
        //    {
        //        Semester.Semester1 => "First Semester",
        //        Semester.Semester2 => "Second Semester",
        //        Semester.Summer => "Summer",
        //        _ => "Unknown Semester"
        //    };

        //    string schoolYearString = $"{semesterString} {currentSchoolYear.Year1}-{currentSchoolYear.Year2}";

        //    var courses = student.EnrolledCourses.Select(ec => new CourseInfoViewModel
        //    {
        //        Code = ec.CourseCode,
        //        Course = ec.Course.CourseName,
        //        Instructor = ec.Faculty.FacultyName
        //    }).ToList();

        //    var result = new RequestViewModel
        //    {
        //        SchoolYear = schoolYearString,
        //        Courses = courses
        //    };

        //    string message = $"{student.StudentName} has Request Consultation";
        //    var actionlogs = ActionLogController.ActionLogger(message, student.StudentName, 0, student.Users);

        //    _context.ActionLog.Add(actionlogs);
        //    _context.SaveChanges();

        //    return Ok(result);

        //}
    }
}
