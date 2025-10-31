using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultation.Domain.Enum;

namespace Consultation.Domain
{
    public class FacultySchedule
    {
        [Key]
        public int FacultyScheduleID { get; set; }
        
        public TimeOnly TimeStart { get; set; }
        
        public TimeOnly TimeEnd { get; set; }

        public DaysOfWeek Day { get; set; }

        // Relationship between FacultySchedule and Faculty is one-to-many
        [ForeignKey(nameof(Faculty))]
        public int FacultyID { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
