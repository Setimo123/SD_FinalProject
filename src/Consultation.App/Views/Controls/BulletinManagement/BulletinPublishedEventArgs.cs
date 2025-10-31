using System;

namespace Consultation.App.Views.Controls.BulletinManagement
{
    /// <summary>
    /// Event args to pass bulletin data when published
    /// </summary>
    public class BulletinPublishedEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
