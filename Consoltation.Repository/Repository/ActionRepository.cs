using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Consultation.Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Repository.Repository
{
    public class ActionRepository : IActionRepository
    {
        private readonly AppDbContext _context;
        public ActionRepository(AppDbContext context) => _context = context;

        public async Task ActionLog(string description,string username,TimeOnly time)
        {

            var userAction = new ActionLog
            {
                Description = description,
                Date = DateTime.Now,
                Username = username,
                Time = time,
            };
                
               
            _context.ActionLog.Add(userAction);
            await _context.SaveChangesAsync();
        }
    }
}
