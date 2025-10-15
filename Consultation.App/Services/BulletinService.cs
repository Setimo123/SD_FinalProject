using Consultation.App.Repository;
using Consultation.App.Repository.IRepository;
using Consultation.App.Views.Controls.BulletinManagement;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultation.App.Services
{
    /// <summary>
    /// Singleton service to manage bulletin data across the application using database
    /// </summary>
    public class BulletinService
    {
        private static BulletinService _instance;
        private static readonly object _lock = new object();
        
        private readonly IBulletinRepository _repository;
        
        // Event to notify when bulletins change
        public event EventHandler<BulletinPublishedEventArgs> BulletinPublished;
        public event EventHandler BulletinsChanged;

        private BulletinService()
        {
            var dbContext = new AppDbContext();
            _repository = new BulletinRepository(dbContext);
        }

        public static BulletinService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new BulletinService();
                        }
                    }
                }
                return _instance;
            }
        }

        public async Task<bool> PublishBulletin(BulletinPublishedEventArgs bulletinData)
        {
            try
            {
                var bulletin = new Bulletin
                {
                    Title = bulletinData.Title,
                    Author = bulletinData.Author,
                    Content = bulletinData.Content,
                    Status = bulletinData.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase) 
                        ? BulletinStatus.pending 
                        : BulletinStatus.publish,
                    DatePublished = bulletinData.DatePosted,
                    FileCount = 0,
                    IsArchived = false
                };

                bool success = await _repository.AddBulletin(bulletin);
                
                if (success)
                {
                    // Important: Notify subscribers AFTER database save is confirmed
                    BulletinPublished?.Invoke(this, bulletinData);
                    BulletinsChanged?.Invoke(this, EventArgs.Empty);
                }
                
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PublishBulletin Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return false;
            }
        }

        public async Task<List<BulletinData>> GetActiveBulletins()
        {
            try
            {
                var bulletins = await _repository.GetActiveBulletins();
                return bulletins.Select(b => new BulletinData
                {
                    Id = b.BulletinID.ToString(),
                    Title = b.Title,
                    Author = b.Author,
                    Content = b.Content,
                    Status = b.Status.ToString(),
                    DatePosted = b.DatePublished
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetActiveBulletins Error: {ex.Message}");
                return new List<BulletinData>();
            }
        }
        
        public async Task<List<BulletinData>> GetArchivedBulletins()
        {
            try
            {
                var bulletins = await _repository.GetArchivedBulletins();
                return bulletins.Select(b => new BulletinData
                {
                    Id = b.BulletinID.ToString(),
                    Title = b.Title,
                    Author = b.Author,
                    Content = b.Content,
                    Status = b.Status.ToString(),
                    DatePosted = b.DatePublished
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetArchivedBulletins Error: {ex.Message}");
                return new List<BulletinData>();
            }
        }

        public async Task<int> GetActiveBulletinCount()
        {
            try
            {
                return await _repository.GetActiveBulletinCount();
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
                return await _repository.GetArchivedBulletinCount();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetArchivedBulletinCount Error: {ex.Message}");
                return 0;
            }
        }
        
        public async Task<bool> ArchiveBulletin(int bulletinId)
        {
            try
            {
                bool success = await _repository.ArchiveBulletin(bulletinId);
                if (success)
                {
                    BulletinsChanged?.Invoke(this, EventArgs.Empty);
                }
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ArchiveBulletin Error: {ex.Message}");
                return false;
            }
        }
        
        public async Task<bool> RestoreBulletin(int bulletinId)
        {
            try
            {
                bool success = await _repository.RestoreBulletin(bulletinId);
                if (success)
                {
                    BulletinsChanged?.Invoke(this, EventArgs.Empty);
                }
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RestoreBulletin Error: {ex.Message}");
                return false;
            }
        }
        
        public async Task<bool> DeleteBulletin(int bulletinId)
        {
            try
            {
                bool success = await _repository.DeleteBulletin(bulletinId);
                if (success)
                {
                    BulletinsChanged?.Invoke(this, EventArgs.Empty);
                }
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteBulletin Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateBulletin(int bulletinId, string title, string author, string content, string status)
        {
            try
            {
                var bulletin = await _repository.GetBulletinById(bulletinId);
                if (bulletin == null)
                {
                    return false;
                }

                bulletin.Title = title;
                bulletin.Author = author;
                bulletin.Content = content;
                bulletin.Status = status.Equals("Pending", StringComparison.OrdinalIgnoreCase) 
                    ? BulletinStatus.pending 
                    : BulletinStatus.publish;

                bool success = await _repository.UpdateBulletin(bulletin);
                if (success)
                {
                    BulletinsChanged?.Invoke(this, EventArgs.Empty);
                }
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateBulletin Error: {ex.Message}");
                return false;
            }
        }
    }

    /// <summary>
    /// Data class to store bulletin information
    /// </summary>
    public class BulletinData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
