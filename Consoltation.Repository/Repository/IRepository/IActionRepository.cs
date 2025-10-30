using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository.Repository.IRepository
{
    public interface IActionRepository
    {
        Task ActionLog(string description, string username, TimeOnly time);
    }
}
