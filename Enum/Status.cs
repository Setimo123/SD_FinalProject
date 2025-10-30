using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Domain.Enum
{
    public enum Status
    {
        Pending = 1,
        Approved = 2,
        Disapproved = 3,
        Cancelled = 4,
        Done = 5
    }
}
