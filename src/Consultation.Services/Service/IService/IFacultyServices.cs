using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Services.Service.IService
{
    public interface IFacultyServices
    {
        Task<List<ConsultationRequest?>> GetFacultyConsultation(int id);

        Task<Faculty?> GetFacultyInformation(string faucltyUMID);

        Task ChagngConsultationByID(int id, Consultation.Domain.Enum.Status status, string reason);
    }
}
