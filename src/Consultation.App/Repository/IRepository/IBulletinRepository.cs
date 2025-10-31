using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultation.App.Repository.IRepository
{
    public interface IBulletinRepository
    {
        Task<List<Bulletin>> GetAllBulletins();
        Task<List<Bulletin>> GetActiveBulletins();
        Task<List<Bulletin>> GetArchivedBulletins();
        Task<int> GetActiveBulletinCount();
        Task<int> GetArchivedBulletinCount();
        Task<Bulletin> GetBulletinById(int id);
        Task<bool> AddBulletin(Bulletin bulletin);
        Task<bool> UpdateBulletin(Bulletin bulletin);
        Task<bool> DeleteBulletin(int id);
        Task<bool> ArchiveBulletin(int id);
        Task<bool> RestoreBulletin(int id);
    }
}
