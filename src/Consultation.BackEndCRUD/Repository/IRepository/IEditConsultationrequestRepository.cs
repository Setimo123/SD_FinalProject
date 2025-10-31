using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.BackEndCRUD.Repository.IRepository
{
    public interface IEditConsultationrequestRepository
    {
        Task<ConsultationRequest?> GetConsultationRequests(int studentId);

        Task<IEnumerable<ConsultationRequest>> GetConsultationRequestsAsync();

    }
}
