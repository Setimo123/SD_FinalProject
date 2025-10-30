using Consultation.Domain;
using Consultation.Infrastructure.Data;
using FlutterAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlutterAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult ShowForStudents([FromBody] int studentId)
        //{
        //    var student = _context.Students
        //        .Include(c => c.SchoolYears)
        //        .Include(c => c.ConsultationRequests)
        //        .Include(c => c.Program)
        //        .Where(c => c.StudentID == studentId).FirstOrDefault();

        //    var schoolYear = student.SchoolYears.Where(c => c.SchoolYearStatus == SchoolYearStatus.Current).FirstOrDefault();
        //    var schoolYearString = $"{schoolYear.Semester} Semester {schoolYear.Year1}-{schoolYear.Year2}";

        //    List<string> notifications = new List<string>();
        //    foreach (var request in student.ConsultationRequests
        //        .Where(c => c.Status != Consultation.Domain.Enum.Status.Pending))
        //    {
        //        var requestString = $"{request.Faculty.FacultyName} has {request.Status.ToString()} your consultation request.";
        //        notifications.Add(requestString);
        //    }

        //    var dashboardVM = new DashboardViewModel
        //    {
        //        Student = student,
        //        SchoolYear = schoolYearString,
        //        PendingConsultation = student.ConsultationRequests.Where(c => c.Status == Consultation.Domain.Enum.Status.Pending).Count(),
        //        Notifications = notifications
        //    };
        //    string message = $"{student.StudentName} has accessed the dashboard";
        //    var actionLog = ActionLogController.ActionLogger(message, student.StudentName,0, student.Users);

        //    _context.ActionLog.Add(actionLog);
        //    _context.SaveChanges();

        //    return Ok(dashboardVM);
        //}
    }
}
