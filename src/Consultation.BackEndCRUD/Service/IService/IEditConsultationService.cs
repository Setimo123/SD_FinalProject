using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultation.BackEndCRUD.ViewModel;
using Consultation.BackEndCRUD.ViewModel.ConsultationViewModel;

namespace Consultation.BackEndCRUD.Service.IService
{
    public interface IEditConsultationService
    {
        Task<EditConsultationViewModel> getEditConsultation(int studentID);

        Task<IEnumerable<EditConsultationViewModel>> getAllConsultations();
    }
}
