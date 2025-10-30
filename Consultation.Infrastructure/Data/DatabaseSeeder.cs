using Consultation.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultation.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using Enum;

namespace Consultation.Infrastructure.Data
{
    public class DatabaseSeeder
    {
        public static Users UserSeeder(string id, string umid, string userName, string email, string password, Domain.Enum.UserType userType)
        {
            var Users = new Users
            {
                Id = id,
                UserName = userName,
                Email = email,
                NormalizedUserName = userName.ToUpper(),
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<Users>().HashPassword(null, password),
                SecurityStamp = "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4",
                ConcurrencyStamp = "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b",
                UserType = userType,
                UMID = umid
            };
            return Users;
        }

        public static Department DepartmentSeeder(int departmentId, string departmentName, string description)
        {

            var Department = new Department
            {
                DepartmentID = departmentId,
                DepartmentName = departmentName,
                Description = description
            };

            return Department;
        }

        public static Program ProgramSeeder(int programId, string programName, string description, int departmentId)
        {
            var Program = new Program
            {
                ProgramID = programId,
                ProgramName = programName,
                Description = description,
                DepartmentID = departmentId
            };
            return Program;
        }

       public static EnrolledCourse EnrollCourseSeeder(int enrolledCourseID, string courseName, string courseCode,
      int schoolYearID, int studentID, int facultyID,string programCourse)
        {
            var EnrolledCourse = new EnrolledCourse
            {
                EnrolledCourseID = enrolledCourseID,
                CourseCode = courseCode,
                CourseName = courseName,
                StudentID = studentID,
                FacultyID = facultyID,
                SchoolYearID = schoolYearID,
                ProgramCourse  = programCourse
            };
            return EnrolledCourse;
        }

        public static SchoolYear schoolYearSeeder(int schoolYearId, string Year1,string Year2, Domain.Enum.Semester semester, Domain.Enum.SchoolYearStatus schoolYearStatus)
        {
            var SchoolYear = new SchoolYear
            {
                SchoolYearID = schoolYearId,
                SchoolYearStatus = schoolYearStatus,
                Semester = semester,
                Year1 = Year1,
                Year2 = Year2

            };
            return SchoolYear;
        }

        public static Student StudentSeeder(int id,string studentUMID,string studentName,string email,
            int programID,int schoolYear,string userID,YearLevel yearlevel)
        {
            var students = new Student
            {
                Email = email,
                StudentName = studentName,
                StudentID = id,
                StudentUMID = studentUMID,
                ProgramID = programID,
                SchoolYearID = schoolYear,
                UsersID = userID,
                yearLevel = yearlevel
            };

            return students;
        }

        public static Faculty FacultySeeder(int facultyID,string facultyUMID,string facultyName
            ,int schoolYearID,string userID,string facultyEmail,int programID)
        {
            var faculty = new Faculty
            {
                UsersID = userID,
                FacultyID = facultyID,
                FacultyUMID = facultyUMID,
                FacultyName = facultyName,   
                SchoolYearID = schoolYearID,
                FacultyEmail = facultyEmail,
                ProgramID = programID

            };
            return faculty;
        }

        public static Admin AdminSeeder(int adminID, string adminName, string userId)
        {
            var admin = new Admin
            {
             AdminName = adminName,
             AdminID = adminID,
             UsersID = userId
            };
            return admin;
        }

        public static ConsultationRequest ConsultationRequestSeeder(int ConsultationID,DateTime DateRequested,DateTime DateSchedule, TimeOnly StartedTime,
            TimeOnly EndedTime, string Concern, string? DisapprovedReason, string SubjectCode, Status Status, 
            string programName,int StudentID, int FacultyID)
        {
            var ConsultationRequest = new ConsultationRequest
            {
                ConsultationID = ConsultationID,
                DateRequested = DateRequested,
                DateSchedule = DateSchedule,
                StartedTime = StartedTime,
                EndedTime = EndedTime,
                Concern = Concern,
                DisapprovedReason = DisapprovedReason,
                SubjectCode = SubjectCode,
                Status = Status,
                StudentID = StudentID,
                FacultyID = FacultyID,
                ProgramName = programName
            };          
        return ConsultationRequest;
        }

        public static FacultySchedule FacultyScheduleSeeder(int FacultyScheduleID, TimeOnly timeStart, TimeOnly timeEnd,
           DaysOfWeek days, int facultyID)
        {
            var facultySchedule = new FacultySchedule
            {
                FacultyScheduleID = FacultyScheduleID,
                TimeStart = timeStart,
                TimeEnd = timeEnd,
                Day = days,
                FacultyID = facultyID,
            };
            return facultySchedule;
        }

        public static Notification NotificationSeeder(int messageNumber,string message,NotificationType 
            notificationType)
        {
            var notification = new Notification
            {
                NotificationNumber = messageNumber,
                NotificationMessage = message,
                NotificationType = notificationType
            };
            return notification;
        }

        public static Bulletin BulletinSeeder(int BulletinID,string title,string author,BulletinStatus bulletinStatus,
            DateTime datePublished,int filecount,bool isArchived)
        {
            var bulletin = new Bulletin
            {
                BulletinID = BulletinID,
                Title = title,
                Author = author,
                Status = bulletinStatus,
                DatePublished = datePublished,
                FileCount = filecount,
                IsArchived = isArchived
            };
            return bulletin;
        }
    }
}








