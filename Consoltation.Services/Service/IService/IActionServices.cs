using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Services.Service.IService
{
    public interface IActionServices
    {
        Task ActionLog(string description, string username, TimeOnly time);
    }
}
