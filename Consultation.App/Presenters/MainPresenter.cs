using Consultation.App.ConsultationManagement;
using Consultation.App.Dashboard;
using Consultation.App.Presenters; // <-- If your presenters are here
using Consultation.App.Views;
using Consultation.App.Views.IViews;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Consultation.App.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _mainView;

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

        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;

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
            var presenter = new DashboardPresenter(view);
            return view;
        }

        private IChildView CreateConsultationView()
        {
            var view = new ConsultationView();
            var presenter = new ConsultationPresenter(view);
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
