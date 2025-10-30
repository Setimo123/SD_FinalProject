using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    public enum YearLevel
    {
        [Display(Name = "1st Year")]
        First_Year = 1,
        [Display(Name = "2nd Year")]
        Second_Year = 2,
        [Display(Name = "3rd Year")]
        Third_Year = 3,
        [Display(Name = "4th Year")]
        Fourth_Year = 4,
    }
}
