using System;

namespace Consultation.App.ViewModels.DashboardModels
{
    /// <summary>
    /// Helper class to store bulletin card data for persistence
    /// </summary>
    public class BulletinCardData
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
