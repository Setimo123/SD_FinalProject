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
    public class ConsultationRequest
    {
        [Key]
        public int ConsultationID { get; set; }

        public DateTime DateRequested { get; set; }
        
        public DateTime DateSchedule { get; set; }

        public TimeOnly StartedTime { get; set; }

        public TimeOnly EndedTime { get; set; }

        public string Concern { get; set; }

        public string? DisapprovedReason { get; set; }

        public string SubjectCode { get; set; }

        public Status Status { get; set; }

        public string ProgramName { get; set; }

        [ForeignKey(nameof(StudentID))]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey(nameof(FacultyID))]
        public int FacultyID { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}