using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Domain.Enum
{
    public enum Semester
    {
        [Display(Name="First Semester")]
        Semester1 =1,

        [Display(Name = "Second Semester")]
        Semester2 = 2,

        [Display(Name = "Summer Semester")]
        Summer = 3,

    }
}
