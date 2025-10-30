using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository.Repository.IRepository
{
    public interface IFacultyRepository
    {
        Task<List<ConsultationRequest?>> FacultyConsultation(int id);
        Task<Faculty> GetFacultyInformation(string studentUMNumber);
        Task ChangeConsultationByID(int id, Consultation.Domain.Enum.Status status,string reason);

        Task<Faculty> GetFacultyByEmail(string facultyName);


    }
}
