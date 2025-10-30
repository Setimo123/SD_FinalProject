using Consultation.Domain.Enum;
using Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Domain
{
    public class SchoolYear
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolYearID { get; set; }

        public string Year1 { get; set; }

        public string Year2 { get; set; }

        public SchoolYearStatus SchoolYearStatus { get; set; }
        
        public Semester Semester { get; set; }

        //This school year should have many students and many faculties
        public List<Student> Students { get; set; } 

        public List<Faculty> Faculties { get; set; }    

        public List<EnrolledCourse> EnrolledCourses { get; set; }


    }
}
