using Consultation.Domain.Enum;
using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Infrastructure.Data
{
    public class DatabaseSeederInfo
    {
        public static List<Users> UserDataList()
        {
            var users = new List<Users>
            {
                DatabaseSeeder.UserSeeder("0542B05F-A99D-43E3-AC02-D1724FD88E27", "550200", "Rene Cedric Setimo", "r.setimo.550200@umindanao.edu.ph", "MyStudent123!", Domain.Enum.UserType.Student),
                DatabaseSeeder.UserSeeder("1CE43429-A555-45F8-8D14-F93C147247B5", "544358", "Cheley Balsomo", "c.balsomo.544358@umindanao.edu.ph", "MyStudent123!", Domain.Enum.UserType.Student),
                DatabaseSeeder.UserSeeder("305AE16B-FBDB-435D-B97E-5A5EF3DC236D", "550409", "Harwyne Ace Basarte", "h.basarte.550409@umindanao.edu.ph", "MyStudent123!", Domain.Enum.UserType.Student),
                DatabaseSeeder.UserSeeder("3A42AB5E-DC55-4BA4-9264-57C460539DDD", "545208", "Ellaine Musni", "e.musni.545208@umindanao.edu.ph", "MyStudent123!", Domain.Enum.UserType.Student),
                DatabaseSeeder.UserSeeder("3FFC159F-6EF0-4D4E-8C95-3A75FA1600CE", "535132", "Nassim Ehab Orabi", "n.orabi.535132@umindanao.edu.ph", "MyStudent123!", Domain.Enum.UserType.Student),
                DatabaseSeeder.UserSeeder("9ECC5D8A-A6A9-46ED-89FC-BCD694F06CD7", "547357", "Reygian Mateo", "r.mateo.547357@umindanao.edu.ph", "MyStudent123!", Domain.Enum.UserType.Student),
                DatabaseSeeder.UserSeeder("B1FBEBAB-BDF2-473A-8AE4-E8CB036F32CE", "526044", "Reggie Soylon", "r.soylon.526044@umindanao.edu.ph", "MyStudent123!", Domain.Enum.UserType.Student),
                DatabaseSeeder.UserSeeder("C67B48B9-C09D-4A03-BB9F-A3E70D98EAFF", "545154", "Riane Kaiser Isid", "r.isid.545154@umindanao.edu.ph", "MyStudent123!", Domain.Enum.UserType.Student),
                DatabaseSeeder.UserSeeder("DA470776-6AD4-42A3-9266-6DC67444D7B7", "548631", "Jeanelle Labsan", "j.labsan.548631@umindanao.edu.ph", "MyStudent123!", Domain.Enum.UserType.Student),
                DatabaseSeeder.UserSeeder("EAD9B361-DF40-48F6-AC0F-4A89AFFA72D2", "546094", "Christopher John Destajo", "c.destajo.546094@umindanao.edu.ph", "MyStudent123!", Domain.Enum.UserType.Student),

                DatabaseSeeder.UserSeeder("175A7233-93D9-4C74-870B-7C354E3035CC", "330006", "Kimberly Nepa-Muaña", "knepa@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("19D57012-9A44-4B2B-BBAF-F9361EBF62F7", "330002", "Stephen Paul Alagao", "salagao@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("2B036F02-AC85-4511-A036-DA5B9238F157", "330010", "Marianne Wata", "mwata@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("4018C0AF-6764-446E-99E0-B81FE80961E0", "330007", "Jethro Joshua Ordas", "jordas@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("4D919EA9-ADBA-420A-9B19-BF1878E178C6", "330004", "Randy Angelia", "rangelia@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("53E836AA-802B-4432-B682-CD9F86691317", "330008", "Lester Tubo", "ltubo@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("6EC682D8-03CC-4EBB-B48D-3D8DCBDD443D", "330001", "Jetron Adtoon", "jadtoon@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("A4A8293F-AC1D-44AA-836F-D4C0A79FCFD9", "330005", "Jay Al Gallenero", "jgallenero@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("A71A3F07-BDB7-44A9-8128-62848CF38181", "330009", "Julie Uy", "juy@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("CA0C4ABD-802D-4B0F-85CF-778E7EA4EF01", "330003", "Hannah Leah Angelia", "hangelia@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),

                DatabaseSeeder.UserSeeder("1DE3802A-E9C2-4B04-80DB-B32A3A5F1624", "310001", "Charlito Cañesares", "ccañesares@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("423965D1-0EF0-4CD9-931D-605CA7B38A3E", "320001", "Carl Justine Calunsag", "ccalunsag@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("18DA9DD0-CA87-4389-B12D-2B1A793F7A59", "340001", "Dan David Aaron Oro", "doro@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("AF1CA1A3-B937-45F0-9AE9-CBF355FE3F82", "350001", "Egi Joe Fran Morales", "emorales@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),
                DatabaseSeeder.UserSeeder("55D0D298-ED9B-4B4D-9270-2019C0A5802B", "360001", "Ramiro Emerson Amon", "ramon@umindanao.edu.ph", "MyFaculty123!", Domain.Enum.UserType.Faculty),

                DatabaseSeeder.UserSeeder("28DC4EA5-8AA7-43AA-813B-3E85D547893A", "330005", "Jay Gallenero", "jgallenero@umindanao.edu.ph", "MyAdmin123!", Domain.Enum.UserType.Admin),
            };

            return users;
        }
        //<Guid("D81B4D15-B3CD-47D5-96B0-44EF8E39E538")>

        public static List<Department> DeparrmentDataList()
        {
            var departments = new List<Department>
            {
                DatabaseSeeder.DepartmentSeeder(1, "CASE", "College of Arts and Sciences Education"),
                DatabaseSeeder.DepartmentSeeder(2, "CBAE", "College of Business Administration Education"),
                DatabaseSeeder.DepartmentSeeder(3, "CEE", "College of Engineering Education"),
                DatabaseSeeder.DepartmentSeeder(4, "CAE", "College of Accounting Education"),
                DatabaseSeeder.DepartmentSeeder(5, "CAFAE", "College of Architecture and Fine Arts Education"),
                DatabaseSeeder.DepartmentSeeder(6, "CCE", "College of Computing Education"),
                DatabaseSeeder.DepartmentSeeder(7, "CTE", "College of Teacher Education"),
                DatabaseSeeder.DepartmentSeeder(8, "CCJE", "College of Criminal Justice Education"),
                DatabaseSeeder.DepartmentSeeder(9, "CHE", "College of Hospitality Education"),
                DatabaseSeeder.DepartmentSeeder(10, "CHSE", "College of Health Sciences Education"),
            };
            return departments;
        }

        public static List<Program> ProgramDataList()
        {

            var program = new List<Program>
            {
                DatabaseSeeder.ProgramSeeder(1, "ME", "Mechanical Engineering",3),
                DatabaseSeeder.ProgramSeeder(2, "CE", "Civil Engineering",3),
                DatabaseSeeder.ProgramSeeder(3, "CpE", "Computer Engineering",3),
                DatabaseSeeder.ProgramSeeder(4, "EE", "Electrical Engineering",3),
                DatabaseSeeder.ProgramSeeder(5, "ECE", "Electronics and Communication Engineering",3),
                DatabaseSeeder.ProgramSeeder(6, "ChE", "Chemical Engineering",3),
                DatabaseSeeder.ProgramSeeder(7, "MaE", "Materials Engineering",3)
            };
            return program;
        }

        public static List<SchoolYear> SchoolYearDataList()
        {

            var schoolYears = new List<SchoolYear>
            {
                DatabaseSeeder.schoolYearSeeder(1,"2024","2025",Domain.Enum.Semester.Semester1,Domain.Enum.SchoolYearStatus.Current),
                DatabaseSeeder.schoolYearSeeder(2,"2024","2025",Domain.Enum.Semester.Semester2,Domain.Enum.SchoolYearStatus.Current),
                DatabaseSeeder.schoolYearSeeder(3,"2024","2025",Domain.Enum.Semester.Summer,Domain.Enum.SchoolYearStatus.Current),
            };
            return schoolYears;
        }

        public static List<EnrolledCourse> EnrolledCourseDataList()
        {

            var enrolledCourses = new List<EnrolledCourse>
            {
                //Enrolled courses in first semester
                DatabaseSeeder.EnrollCourseSeeder(1,"Engineering Calculus 2", "CEE103", 1, 9, 14,"ECE"),
                DatabaseSeeder.EnrollCourseSeeder(2,"Physics 1 for Engineers", "CEE102L", 1, 8, 12,"CE"),
                DatabaseSeeder.EnrollCourseSeeder(3,"Data Structures and Algorithms", "CPE211L", 1, 2, 10, "CpE"),
                DatabaseSeeder.EnrollCourseSeeder(4,"Computer Aided Drafting", "DRAW102L", 1, 4, 13, "EE"),
                DatabaseSeeder.EnrollCourseSeeder(5,"Engineering Data Analysis", "CEE105", 1, 10, 11, "ME"),
             
                //Enrolled courses in second semester
                DatabaseSeeder.EnrollCourseSeeder(6,"Differential Equations", "CEE104", 2, 7, 15, "ChE"),
                DatabaseSeeder.EnrollCourseSeeder(7,"Engineering Economics", "CEE109", 2, 1, 12, "CE"),
                DatabaseSeeder.EnrollCourseSeeder(8,"Software Design", "CPE223L", 2, 5, 5, "CpE"),
                DatabaseSeeder.EnrollCourseSeeder(9,"Fundamentals of Electric Circuits", "BEE212L", 1, 6, 13, "CpE"), 

                //Enrolled courses in summer
                DatabaseSeeder.EnrollCourseSeeder(10,"Technopreneurship", "CEE115", 3, 3, 2, "CpE")
            };
            return enrolledCourses;
        }


        public static List<Student> StudentDataList()
        {

            var students = new List<Student>
            {
                DatabaseSeeder.StudentSeeder(1, "544358", "Cheley Balsomo", "c.balsomo.544358@umindanao.edu.ph", 1, 1,
                "1CE43429-A555-45F8-8D14-F93C147247B5", YearLevel.ThirdYear),
                DatabaseSeeder.StudentSeeder(2, "550409", "Harwyne Ace Basarte", "h.basarte.550409@umindanao.edu.ph", 1, 1,
                "305AE16B-FBDB-435D-B97E-5A5EF3DC236D", YearLevel.ThirdYear),
                DatabaseSeeder.StudentSeeder(3, "546094", "Christopher John Destajo", "c.destajo.546094@umindanao.edu.ph", 2, 1,
                "EAD9B361-DF40-48F6-AC0F-4A89AFFA72D2", YearLevel.ThirdYear),
                DatabaseSeeder.StudentSeeder(4, "545154", "Riane Kaiser Isid", "r.isid.545154@umindanao.edu.ph", 2, 1,
                "C67B48B9-C09D-4A03-BB9F-A3E70D98EAFF", YearLevel.ThirdYear),
                DatabaseSeeder.StudentSeeder(5, "548631", "Jeanelle Labsan", "j.labsan.548631@umindanao.edu.ph", 3, 1,
                "DA470776-6AD4-42A3-9266-6DC67444D7B7", YearLevel.ThirdYear),
                DatabaseSeeder.StudentSeeder(6, "547357", "Reygian Mateo", "r.mateo.547357@umindanao.edu.ph", 3, 1,
                "9ECC5D8A-A6A9-46ED-89FC-BCD694F06CD7", YearLevel.ThirdYear),
                DatabaseSeeder.StudentSeeder(7, "545208", "Ellaine Musni", "e.musni.545208@umindanao.edu.ph", 4, 1,
                "3A42AB5E-DC55-4BA4-9264-57C460539DDD", YearLevel.ThirdYear),
                DatabaseSeeder.StudentSeeder(8, "535132", "Nassim Ehab Orabi", "n.orabi.535132@umindanao.edu.ph", 4, 1,
                "3FFC159F-6EF0-4D4E-8C95-3A75FA1600CE", YearLevel.ThirdYear),
                DatabaseSeeder.StudentSeeder(9, "550200", "Rene Cedric Setimo", "r.setimo.550200@umindanao.edu.ph", 5, 1,
                "0542B05F-A99D-43E3-AC02-D1724FD88E27", YearLevel.ThirdYear),
                DatabaseSeeder.StudentSeeder(10, "526044", "Reggie Soylon", "r.soylon.526044@umindanao.edu.ph", 6, 1,
                "B1FBEBAB-BDF2-473A-8AE4-E8CB036F32CE", YearLevel.ThirdYear),
            };
            return students;
        }

        public static List<Faculty> FacultyDataList()
        {

            var faculty = new List<Faculty>()
            {
                DatabaseSeeder.FacultySeeder(1, "330001", "Jetron Adtoon", 1, "6EC682D8-03CC-4EBB-B48D-3D8DCBDD443D", "jadtoon@umindanao.edu.ph", 3),
                DatabaseSeeder.FacultySeeder(2, "330002", "Stephen Paul Alagao", 1, "19D57012-9A44-4B2B-BBAF-F9361EBF62F7", "salagao@umindanao.edu.ph", 3),
                DatabaseSeeder.FacultySeeder(3, "330003", "Hannah Leah Angelia", 1, "CA0C4ABD-802D-4B0F-85CF-778E7EA4EF01", "hangelia@umindanao.edu.ph", 3),
                DatabaseSeeder.FacultySeeder(4, "330004", "Randy Angelia", 1, "4D919EA9-ADBA-420A-9B19-BF1878E178C6", "rangelia@umindanao.edu.ph", 3),
                DatabaseSeeder.FacultySeeder(5, "330005", "Jay Al Gallenero", 1, "A4A8293F-AC1D-44AA-836F-D4C0A79FCFD9", "jgallenero@umindanao.edu.ph", 3),
                DatabaseSeeder.FacultySeeder(6, "330006", "Kimberly Nepa-Muaña", 1, "175A7233-93D9-4C74-870B-7C354E3035CC", "knepa@umindanao.edu.ph", 3),
                DatabaseSeeder.FacultySeeder(7, "330007", "Jethro Joshua Ordas", 1, "4018C0AF-6764-446E-99E0-B81FE80961E0", "jordas@umindanao.edu.ph", 3),
                DatabaseSeeder.FacultySeeder(8, "330008", "Lester Tubo", 1, "53E836AA-802B-4432-B682-CD9F86691317", "ltubo@umindanao.edu.ph", 3),
                DatabaseSeeder.FacultySeeder(9, "330009", "Julie Uy", 1, "A71A3F07-BDB7-44A9-8128-62848CF38181", "juy@umindanao.edu.ph", 3),
                DatabaseSeeder.FacultySeeder(10, "330010", "Marianne Wata", 1, "2B036F02-AC85-4511-A036-DA5B9238F157", "mwata@umindanao.edu.ph", 3),
                DatabaseSeeder.FacultySeeder(11, "310001", "Charlito Cañesares", 1, "1DE3802A-E9C2-4B04-80DB-B32A3A5F1624", "ccañesares@umindanao.edu.ph", 1),
                DatabaseSeeder.FacultySeeder(12, "320001", "Carl Justine Calunsag", 1, "423965D1-0EF0-4CD9-931D-605CA7B38A3E", "ccalunsag@umindanao.edu.ph", 2),
                DatabaseSeeder.FacultySeeder(13, "340001", "Dan David Aaron Oro", 1, "18DA9DD0-CA87-4389-B12D-2B1A793F7A59", "doro@umindanao.edu.ph", 4),
                DatabaseSeeder.FacultySeeder(14, "350001", "Egi Joe Fran Morales", 1, "AF1CA1A3-B937-45F0-9AE9-CBF355FE3F82", "emorales@umindanao.edu.ph", 5),
                DatabaseSeeder.FacultySeeder(15, "360001", "Ramiro Emerson Amon", 1, "55D0D298-ED9B-4B4D-9270-2019C0A5802B", "ramon@umindanao.edu.ph", 6),

            };
            return faculty;
        }


        public static List<Admin> AdminDataList()
        {


            var admin = new List<Admin>()
            {
                DatabaseSeeder.AdminSeeder(1, "Jay Al Gallenero", "28DC4EA5-8AA7-43AA-813B-3E85D547893A"),
            };
            return admin;
        }

        public static List<ConsultationRequest> ConsultationRequestDataList()
        {
            var consultationRequest = new List<ConsultationRequest>()
            {
                DatabaseSeeder.ConsultationRequestSeeder(
                    1,
                    new DateTime(2025, 08, 14),
                    new DateTime(2025, 08, 18),
                    new TimeOnly(15, 0),
                    new TimeOnly(16, 0),
                    "Having trouble following discussions",
                    null,
                    "CEE103",
                    Status.Done,
                    "ECE",
                    9,
                    14
                ),

                DatabaseSeeder.ConsultationRequestSeeder(
                    2,
                    new DateTime(2025, 09, 19),
                    new DateTime(2025, 09, 24),
                    new TimeOnly(10, 0),
                    new TimeOnly(11, 0),
                    "Follow-up on previous consultation",
                    "Faculty unavailable",
                    "CPE221L",
                    Status.Disapproved,
                    "CpE",
                    2,
                    10
                ),
                DatabaseSeeder.ConsultationRequestSeeder(
                    3,
                    new DateTime(2025, 10, 10),
                    new DateTime(2025, 10, 17),
                    new TimeOnly(11, 30),
                    new TimeOnly(12, 30),
                    "Concerns regarding my grades",
                    null,
                    "CEE105",
                    Status.Pending,
                    "ME",
                    10,
                    11
                ),
            };
            return consultationRequest;
        }

        public static List<FacultySchedule> FacultyScheduleSeeder()
        {
            var faucltySchedule = new List<FacultySchedule>()
            {
                DatabaseSeeder.FacultyScheduleSeeder(1, new TimeOnly(15, 0), new TimeOnly(16, 0),DaysOfWeek.Monday,14),
                DatabaseSeeder.FacultyScheduleSeeder(2, new TimeOnly(10, 0), new TimeOnly(11, 0),DaysOfWeek.Wednesday,10),
                DatabaseSeeder.FacultyScheduleSeeder(3, new TimeOnly(11, 30), new TimeOnly(12, 30), DaysOfWeek.Friday, 11)
            };
            return faucltySchedule;
        }

        public static List<Notification> NotificationSeeder()
        {
            var notification = new List<Notification>()
            {
                DatabaseSeeder.NotificationSeeder(1, "Your consultation request has been successfully submitted.", NotificationType.StudentNotification),
                DatabaseSeeder.NotificationSeeder(2, "Your consultation schedule has been disapproved by the faculty.", NotificationType.StudentNotification),
                DatabaseSeeder.NotificationSeeder(3, "A new faculty account has been registered in the system.", NotificationType.AdminNotification)
            };
            return notification;
        }

        public static List<Bulletin> BulletinSeeder()
        {
            var bulletins = new List<Bulletin>()
            {
                DatabaseSeeder.BulletinSeeder(1, "Welcome Week Schedule", "Student Affairs",
                     "Join us for Welcome Week! Activities include orientation sessions, campus tours, and social events to help new students get acquainted with university life.",
                     BulletinStatus.Published, new DateTime(2025, 8, 1), 2, false),

                DatabaseSeeder.BulletinSeeder(2, "Maintenance Downtime", "IT",
                    "The university website and online services will be temporarily unavailable on August 5, 2025 from 10:00 PM to 2:00 AM for scheduled maintenance.",
                    BulletinStatus.Published, new DateTime(2025, 8, 5), 1, false),

                DatabaseSeeder.BulletinSeeder(3, "New Library Hours", "Library",
                    "Starting next semester, the library will extend its operating hours. New schedule: Monday-Friday 7:00 AM to 10:00 PM, Weekends 9:00 AM to 6:00 PM.",
                    BulletinStatus.Draft, new DateTime(2025, 8, 7), 0, false),

                DatabaseSeeder.BulletinSeeder(4, "Policy Archive", "Admin",
                    "Old university policies have been archived and are now available in the document repository for reference purposes.",
                    BulletinStatus.Draft, new DateTime(2024, 12, 1), 3, true),

            };
            return bulletins;
        }
    }
}
