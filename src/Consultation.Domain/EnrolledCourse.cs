using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Domain
{
    public class EnrolledCourse
    {
        [Key]
        public int EnrolledCourseID { get; set; }

        [Required]
        public string CourseName { get; set; }
        public string CourseCode { get; set; }


        [ForeignKey(nameof(SchoolYearID))]
        public int SchoolYearID { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
         
        [ForeignKey(nameof(StudentID))]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        
        [ForeignKey(nameof(FacultyID))]
        public int FacultyID { get; set; }
        public virtual Faculty Faculty { get; set; }

        public string ProgramCourse { get; set; }
    }
}
