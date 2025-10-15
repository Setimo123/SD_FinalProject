using Consultation.App.Views.Controls.BulletinManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Consultation.App.Services
{
    /// <summary>
    /// Singleton service to manage bulletin data across the application
    /// </summary>
    public class BulletinService
    {
        private static BulletinService _instance;
        private static readonly object _lock = new object();
        
        private readonly List<BulletinData> _activeBulletins;
        private readonly List<BulletinData> _archivedBulletins;
        private int _nextBulletinId = 1;
        
        // Event to notify when bulletins change
        public event EventHandler<BulletinPublishedEventArgs> BulletinPublished;
        public event EventHandler BulletinsChanged;

        private BulletinService()
        {
            _activeBulletins = new List<BulletinData>();
            _archivedBulletins = new List<BulletinData>();
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

        public void PublishBulletin(BulletinPublishedEventArgs bulletinData)
        {
            var bulletin = new BulletinData
            {
                Id = GenerateBulletinId(),
                Title = bulletinData.Title,
                Author = bulletinData.Author,
                Content = bulletinData.Content,
                Status = bulletinData.Status,
                DatePosted = bulletinData.DatePosted
            };

            _activeBulletins.Insert(0, bulletin); // Add to beginning
            
            // Notify subscribers
            BulletinPublished?.Invoke(this, bulletinData);
            BulletinsChanged?.Invoke(this, EventArgs.Empty);
        }
        
        private string GenerateBulletinId()
        {
            string id = $"BUL-{DateTime.Now.Year}-{_nextBulletinId:D3}";
            _nextBulletinId++;
            return id;
        }

        public List<BulletinData> GetActiveBulletins()
        {
            return new List<BulletinData>(_activeBulletins);
        }
        
        public List<BulletinData> GetArchivedBulletins()
        {
            return new List<BulletinData>(_archivedBulletins);
        }

        public int GetActiveBulletinCount()
        {
            return _activeBulletins.Count;
        }
        
        public int GetArchivedBulletinCount()
        {
            return _archivedBulletins.Count;
        }
        
        public void ArchiveBulletin(string bulletinId)
        {
            var bulletin = _activeBulletins.FirstOrDefault(b => b.Id == bulletinId);
            if (bulletin != null)
            {
                _activeBulletins.Remove(bulletin);
                bulletin.Status = "Archived";
                _archivedBulletins.Insert(0, bulletin);
                BulletinsChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        
        public void RestoreBulletin(string bulletinId)
        {
            var bulletin = _archivedBulletins.FirstOrDefault(b => b.Id == bulletinId);
            if (bulletin != null)
            {
                _archivedBulletins.Remove(bulletin);
                bulletin.Status = "Pending";
                _activeBulletins.Insert(0, bulletin);
                BulletinsChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        
        public void DeleteBulletin(string bulletinId)
        {
            var activeBulletin = _activeBulletins.FirstOrDefault(b => b.Id == bulletinId);
            if (activeBulletin != null)
            {
                _activeBulletins.Remove(activeBulletin);
                BulletinsChanged?.Invoke(this, EventArgs.Empty);
                return;
            }
            
            var archivedBulletin = _archivedBulletins.FirstOrDefault(b => b.Id == bulletinId);
            if (archivedBulletin != null)
            {
                _archivedBulletins.Remove(archivedBulletin);
                BulletinsChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void ClearBulletins()
        {
            _activeBulletins.Clear();
            _archivedBulletins.Clear();
            BulletinsChanged?.Invoke(this, EventArgs.Empty);
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
