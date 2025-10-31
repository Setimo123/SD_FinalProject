using Consultation.App.Dashboard.Activity_Feed_Panel;
using Consultation.App.ViewModels.DashboardModels;

namespace Consultation.App.Views.IViews
{
    public interface IDashboardView : IChildView
    {
        string LoggedInUsername { get; }

        void DisplayUserName(string name);
        void LoadRecentBulletins(List<BulletinModel> bulletins);
        void LoadRecentConsultations(List<ConsultationModel> consultations);

        void UpdateDashboardStats(int published, int pending, int completed, int upcoming);

        void UpdateConsultationStats(int CPE, int EE, int ECE, int CE, int ME, int CHE);
        
        void UpdateConsultationCounts(int activeCount, int completedCount);
        
        void UpdateBulletinCount(int count);
    }
}
