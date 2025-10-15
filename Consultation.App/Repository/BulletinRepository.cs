using Consultation.App.Repository.IRepository;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enum;

namespace Consultation.App.Repository
{
    public class BulletinRepository : IBulletinRepository
    {
        private readonly AppDbContext _context;

        public BulletinRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Bulletin>> GetAllBulletins()
        {
            try
            {
                return await _context.Bulletin
                    .OrderByDescending(b => b.DatePublished)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllBulletins Error: {ex.Message}");
                return new List<Bulletin>();
            }
        }

        public async Task<List<Bulletin>> GetActiveBulletins()
        {
            try
            {
                // Get all non-archived bulletins (both pending and published)
                return await _context.Bulletin
                    .Where(b => !b.IsArchived)
                    .OrderByDescending(b => b.DatePublished)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetActiveBulletins Error: {ex.Message}");
                return new List<Bulletin>();
            }
        }

        public async Task<List<Bulletin>> GetArchivedBulletins()
        {
            try
            {
                return await _context.Bulletin
                    .Where(b => b.IsArchived)
                    .OrderByDescending(b => b.DatePublished)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetArchivedBulletins Error: {ex.Message}");
                return new List<Bulletin>();
            }
        }

        public async Task<int> GetActiveBulletinCount()
        {
            try
            {
                // Count all non-archived bulletins (both pending and published)
                return await _context.Bulletin
                    .CountAsync(b => !b.IsArchived);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetActiveBulletinCount Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> GetArchivedBulletinCount()
        {
            try
            {
                return await _context.Bulletin
                    .CountAsync(b => b.IsArchived);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetArchivedBulletinCount Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<Bulletin> GetBulletinById(int id)
        {
            try
            {
                return await _context.Bulletin.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetBulletinById Error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddBulletin(Bulletin bulletin)
        {
            try
            {
                _context.Bulletin.Add(bulletin);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddBulletin Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateBulletin(Bulletin bulletin)
        {
            try
            {
                _context.Bulletin.Update(bulletin);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateBulletin Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteBulletin(int id)
        {
            try
            {
                var bulletin = await _context.Bulletin.FindAsync(id);
                if (bulletin != null)
                {
                    _context.Bulletin.Remove(bulletin);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteBulletin Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ArchiveBulletin(int id)
        {
            try
            {
                var bulletin = await _context.Bulletin.FindAsync(id);
                if (bulletin != null)
                {
                    bulletin.IsArchived = true;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ArchiveBulletin Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RestoreBulletin(int id)
        {
            try
            {
                var bulletin = await _context.Bulletin.FindAsync(id);
                if (bulletin != null)
                {
                    bulletin.IsArchived = false;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RestoreBulletin Error: {ex.Message}");
                return false;
            }
        }
    }
}

