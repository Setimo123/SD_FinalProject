using Consultation.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultation.App.Repository.IRepository
{
    public interface IConsultationRequestRepository
    {
        Task<List<ConsultationRequest>> GetAllConsultations();
        Task<int> GetActiveConsultationsCount();
        Task<int> GetCompletedConsultationsCount();
        Task<Dictionary<string, int>> GetActiveConsultationCountsByProgram();
        Task<bool> UpdateConsultationStatus(int consultationId, Domain.Enum.Status status);
        Task<bool> DeleteConsultation(int consultationId);
    }
}
