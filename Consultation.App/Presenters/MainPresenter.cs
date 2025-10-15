using Consultation.App.ConsultationManagement;
using Consultation.App.Dashboard;
using Consultation.App.Presenters; // <-- If your presenters are here
using Consultation.App.Views;
using Consultation.App.Views.IViews;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Consultation.App.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _mainView;
        private readonly Users _currentUser;
        private readonly AppDbContext _dbContext; // Add a field for AppDbContext

        private enum ChildViews
        {
            Dashboard,
            Bulletin,
            Consultation,
            UserManagement,
            Settings
        }

        private ChildViews _currentView;
        private readonly Dictionary<ChildViews, IChildView> _childViews = new();

        // Update constructor to accept AppDbContext
        public MainPresenter(IMainView mainView, Users currentUser = null, AppDbContext dbContext = null)
        {
            _mainView = mainView;
            _currentUser = currentUser;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            // Set user information if available
            if (_currentUser != null)
            {
                SetUserInformation();
            }

            // Hook up nav events
            _mainView.DashboardEvent += DashboardEvent;
            _mainView.BulletinEvent += BulletinEvent;
            _mainView.ConsultationEvent += ConsultationEvent;
            _mainView.SFManagementEvent += SFManagementEvent;
            _mainView.PreferenceEvent += PreferenceEvent;
            _mainView.NotificationEvent += NotificationEvent;

            // Load default view
            LoadChildView(ChildViews.Dashboard);
            _mainView.Header("Dashboard");
            _currentView = ChildViews.Dashboard;

            if (_mainView is MainView view)
            {
                SetActiveButton(view.Controls.Find("buttonDashboard", true)[0] as Button);
            }
        }

        private void SetUserInformation()
        {
            string userName = GetUserDisplayName();
            string userRole = GetUserRoleDisplayName();
            
            _mainView.SetUserInfo(userName, userRole);
        }

        private string GetUserDisplayName()
        {
            if (_currentUser == null) return "Guest User";
            
            // The Users table stores the UserName which appears to be the person's name
            // You can also use UMID or Email if preferred
            return !string.IsNullOrEmpty(_currentUser.UserName) ? _currentUser.UserName : "Unknown User";
        }

        private string GetUserRoleDisplayName()
        {
            if (_currentUser == null) return "Guest";
            
            return _currentUser.UserType switch
            {
                Domain.Enum.UserType.Student => "Student",
                Domain.Enum.UserType.Faculty => "Faculty",
                Domain.Enum.UserType.Admin => "Administrator",
                _ => "Unknown Role"
            };
        }

        private void DashboardEvent(object? sender, EventArgs e)
        {
            SetActiveButton(sender as Button);
            if (_currentView != ChildViews.Dashboard)
            {
                LoadChildView(ChildViews.Dashboard);
                _mainView.Header("Dashboard");
                _currentView = ChildViews.Dashboard;
            }
        }

        private void BulletinEvent(object? sender, EventArgs e)
        {
            SetActiveButton(sender as Button);
            if (_currentView != ChildViews.Bulletin)
            {
                LoadChildView(ChildViews.Bulletin);
                _mainView.Header("Bulletin");
                _currentView = ChildViews.Bulletin;
            }
        }

        private void ConsultationEvent(object? sender, EventArgs e)
        {
            SetActiveButton(sender as Button);
            if (_currentView != ChildViews.Consultation)
            {
                LoadChildView(ChildViews.Consultation);
                _mainView.Header("Consultation");
                _currentView = ChildViews.Consultation;
            }
        }

        private void SFManagementEvent(object? sender, EventArgs e)
        {
            SetActiveButton(sender as Button);
            if (_currentView != ChildViews.UserManagement)
            {
                LoadChildView(ChildViews.UserManagement);
                _mainView.Header("User Management");
                _currentView = ChildViews.UserManagement;
            }
        }

        private void PreferenceEvent(object? sender, EventArgs e)
        {
            SetActiveButton(sender as Button);
            _mainView.SetMessage("Settings clicked");
        }

        private void NotificationEvent(object? sender, EventArgs e)
        {
            var notificationView = new NotificationView();
            notificationView.ShowDialog();
        }

        private void LoadChildView(ChildViews viewType)
        {
            if (!_childViews.TryGetValue(viewType, out var view))
            {
                view = CreateViewByType(viewType);
                _childViews[viewType] = view;
            }

            _mainView.MainPanel.Controls.Clear();
            view.AsUserControl.Dock = DockStyle.Fill;
            _mainView.MainPanel.Controls.Add(view.AsUserControl);
            view.AsUserControl.BringToFront();
        }

        private IChildView CreateViewByType(ChildViews viewType)
        {
            return viewType switch
            {
                ChildViews.Dashboard => CreateDashboardView(),
                ChildViews.Consultation => CreateConsultationView(),
                ChildViews.Bulletin => CreateBulletinView(),
                ChildViews.UserManagement => CreateUserManagementView(),
                _ => throw new NotImplementedException()
            };
        }

        private IChildView CreateDashboardView()
        {
            var view = new MainDashboardUserControl();
            var presenter = new DashboardPresenter(view, _dbContext, _currentUser); // Pass the current user
            return view;
        }

        private IChildView CreateConsultationView()
        {
            var view = new ConsultationView();
            var presenter = new ConsultationPresenter(view, _dbContext);
            return view;
        }

        private IChildView CreateBulletinView()
        {
            var view = new BulletinView();
            var presenter = new BulletinPresenter(view);
            return view;
        }

        private IChildView CreateUserManagementView()
        {
            var view = new UserManagementView();
            var presenter = new UserManagementPresenter(view);
            view.SetPresenter(presenter); // Pass presenter reference back to view
            return view;
        }

        private void SetActiveButton(Button button)
        {
            if (button == null) return;

            if (_mainView.CurrentActiveButton != null)
            {
                _mainView.ResetButton(_mainView.CurrentActiveButton);
            }

            _mainView.HighlightButton(button);
            _mainView.CurrentActiveButton = button;
        }
    }
}
