using Consultation.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.BackEndCRUD.ViewModel.ConsultationViewModel
{
    public class EditConsultationViewModel
    {
        public string studentName { get; set; }

        public string facultyName { get; set; }

        public string courseCode { get; set; }

        public string studentUMID { get; set; }

        public string concernDescription { get; set; }

        public DateTime dateSchedule { get; set; }

        public TimeOnly startedTime { get; set; }

        public Status Status { get; set; }


    }
}
