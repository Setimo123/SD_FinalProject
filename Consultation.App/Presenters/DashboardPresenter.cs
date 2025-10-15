using Consultation.App.Repository;
using Consultation.App.Repository.IRepository;
using Consultation.App.ViewModels.DashboardModels;
using Consultation.App.Views.IViews;
using Consultation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.App.Presenters
{
    public class DashboardPresenter
    {
        private readonly IDashboardView _view;
        private readonly IConsultationRequestRepository _consultationRepository;
        private readonly IBulletinRepository _bulletinRepository;
        private readonly AppDbContext _dbContext;
        
        public DashboardPresenter(IDashboardView view, AppDbContext dbContext, Consultation.Domain.Users currentUser = null)
        {
            _view = view;
            _dbContext = dbContext;
            _consultationRepository = new ConsultationRequestRepository(dbContext);
            _bulletinRepository = new BulletinRepository(dbContext);
            
            // Display user name if user is logged in
            if (currentUser != null)
            {
                LoadUserName(currentUser);
            }
        }
        
        private void LoadUserName(Consultation.Domain.Users user)
        {
            try
            {
                // Display the full user name from the UserName field
                string displayName = !string.IsNullOrEmpty(user.UserName) ? user.UserName : "User";
                _view.DisplayUserName(displayName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadUserName Error: {ex.Message}");
                _view.DisplayUserName("User");
            }
        }

        public async Task LoadConsultationStatsByProgram()
        {
            try
            {
                var counts = await _consultationRepository.GetActiveConsultationCountsByProgram();

                int countCPE = counts.ContainsKey("CpE") ? counts["CpE"] : 0;
                int countME = counts.ContainsKey("ME") ? counts["ME"] : 0;
                int countCE = counts.ContainsKey("CE") ? counts["CE"] : 0;
                int countEE = counts.ContainsKey("EE") ? counts["EE"] : 0;
                int countECE = counts.ContainsKey("ECE") ? counts["ECE"] : 0;
                int countCHE = counts.ContainsKey("ChE") ? counts["ChE"] : 0;

                _view.UpdateConsultationStats(countCPE, countEE, countECE, countCE, countME, countCHE);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadConsultationStatsByProgram Error: {ex.Message}");
                // Set all counts to 0 if there's an error
                _view.UpdateConsultationStats(0, 0, 0, 0, 0, 0);
            }
        }

        public async Task LoadConsultationCounts()
        {
            try
            {
                // Get active consultations count (Pending/Approved) - for UpcomingSessionsCount
                int activeCount = await _consultationRepository.GetActiveConsultationsCount();
                
                // Get completed/archived consultations count (Done status) - for ConsultationsCompletedCount
                int archivedCount = await _consultationRepository.GetCompletedConsultationsCount();

                // Pass: activeCount for UpcomingSessions, archivedCount for ConsultationsCompleted
                _view.UpdateConsultationCounts(activeCount, archivedCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadConsultationCounts Error: {ex.Message}");
                _view.UpdateConsultationCounts(0, 0);
            }
        }

        public async Task LoadBulletinCount()
        {
            try
            {
                int activeBulletinCount = await _bulletinRepository.GetActiveBulletinCount();
                _view.UpdateBulletinCount(activeBulletinCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadBulletinCount Error: {ex.Message}");
                _view.UpdateBulletinCount(0);
            }
        }
        
        /*
        public void LoadDashboardData()
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == _view.LoggedInUsername);
    _view.DisplayUserName(user?.FirstName ?? "User");

    var bulletins = _dbContext.Bulletins
        .OrderByDescending(b => b.DatePosted)
        .Take(10)
        .Select(b => new BulletinModel
        {
            Title = b.Title,
            Status = b.Status,
            Body = b.Body,
            DatePosted = b.DatePosted
        })
        .ToList();

    _view.LoadRecentBulletins(bulletins);

    var consultations = _dbContext.Consultations
        .OrderByDescending(c => c.DateScheduled)
        .Take(10)
        .Select(c => new ConsultationModel
        {
            Title = c.Title,
            Status = c.Status,
            Body = c.Body,
            DateScheduled = c.DateScheduled,
            Course = c.Course
        })
        .ToList();

    _view.LoadRecentConsultations(consultations);

    // Count statistics

    int publishedCount = _dbContext.Bulletins.Count(b => b.Status == "Approved");
    int pendingCount = _dbContext.Bulletins.Count(b => b.Status == "Pending");
    int completedConsultations = _dbContext.Consultations.Count(c => c.Status == "Completed");
    int upcomingSessions = _dbContext.Consultations.Count(c => c.DateScheduled > DateTime.Now);

    _view.UpdateDashboardStats(publishedCount, pendingCount, completedConsultations, upcomingSessions);


    // ConsultationByDepartmentStats

    // Count consultations per department
    int countCPE = _dbContext.Consultations.Count(c => c.Course == "CPE");
    int countEE = _dbContext.Consultations.Count(c => c.Course == "EE");
    int countECE = _dbContext.Consultations.Count(c => c.Course == "ECE");
    int countCE = _dbContext.Consultations.Count(c => c.Course == "CE");
    int countME = _dbContext.Consultations.Count(c => c.Course == "ME");
    int countCHE = _dbContext.Consultations.Count(c => c.Course == "CHE");

    _view.UpdateConsultationStats(countCPE, countEE, countECE, countCE, countME, countCHE);
  }
  */
    }
}
