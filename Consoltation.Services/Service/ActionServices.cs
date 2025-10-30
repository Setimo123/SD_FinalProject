using Consultation.Repository.Repository.IRepository;
using Consultation.Services.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Services.Service
{
    public class ActionServices : IActionServices
    {
        private readonly IActionRepository _actionRepo;

        public ActionServices(IActionRepository actionRepo)
        {
            _actionRepo = actionRepo;
        }
        public async Task ActionLog(string description, string username, TimeOnly time)
        {
            await _actionRepo.ActionLog(description, username, time);
        }
    }
}
