using Consultation.Domain;
using Consultation.Repository.Repository.IRepository;
using Consultation.Services.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Services.Service
{
    public class FacultyServices : IFacultyServices
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyServices(IFacultyRepository studentRepository)
        {
            _facultyRepository = studentRepository;
        }
        public async Task<List<ConsultationRequest?>> GetFacultyConsultation(int id)
        {
            return await _facultyRepository.FacultyConsultation(id);
        }

        public Task<Faculty?> GetFacultyInformation(string faucltyUMID)
        {
            return _facultyRepository.GetFacultyInformation(faucltyUMID);   
        }

        public async Task ChagngConsultationByID(int id,Consultation.Domain.Enum.Status status, string reason)
        {
             await _facultyRepository.ChangeConsultationByID(id,status, reason);
        }
    }
}
