using Consultation.App.Services;
using Consultation.App.Views.Controls.BulletinManagement;
using Consultation.App.Dashboard.Activity_Feed_Panel;
using Consultation.App.Presenters;
using Consultation.App.ViewModels.DashboardModels;
using Consultation.App.Views.Controls.Dashboard.Quick_Actions_Panel;
using Consultation.App.Views.IViews;
using Consultation.App.Views;
using Consultation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Dashboard
{
    public partial class MainDashboardUserControl : UserControl, IDashboardView
    {

        public event EventHandler ButtonClick;

        private Color bulletinDefaultColor;
        private Color consultationDefaultColor;
        private Color hoverColor = Color.LightBlue;

        private DashboardPresenter _presenter;
        public string LoggedInUsername { get; private set; } = "admin";

        // Track the published bulletin count - now from service

        // Store reference to the current Bulletin control to persist bulletin cards
        private Bulletin _currentBulletinControl;
        
        // Store reference to the current Consultation2 control to persist consultation cards
        private Consultation2 _currentConsultation2Control;

        public void DisplayUserName(string name)
        {
            UserName.Text = $"{name}!";
        }

        public UserControl AsUserControl => this;

        public MainDashboardUserControl()
        {
            InitializeComponent();

            // Skip event subscriptions in design mode
            if (!DesignMode)
            {
                createNewBulletin1.Cursor = Cursors.Hand;
                manageConsultation1.Cursor = Cursors.Hand;
                BulletinButton.Cursor = Cursors.Hand;
                ConsultationButton.Cursor = Cursors.Hand;

                bulletinDefaultColor = createNewBulletin1.BackColor;
                consultationDefaultColor = manageConsultation1.BackColor;

                //hover events for buttons
                AttachHoverEvents(createNewBulletin1, createNewBulletin1_MouseEnter, createNewBulletin1_MouseLeave);
                AttachHoverEvents(manageConsultation1, manageConsultation1_MouseEnter, manageConsultation1_MouseLeave);

                // Subscribe to the BulletinPublished event from createNewBulletin1 control
                createNewBulletin1.BulletinPublished += OnBulletinPublished;

                // Subscribe to navigation event from manageConsultation1 control
                manageConsultation1.NavigateToConsultation += OnNavigateToConsultation;

                // Subscribe to bulletin service for updates
                BulletinService.Instance.BulletinsChanged += OnBulletinsChanged;

                // Subscribe to consultation service for updates
                ConsultationService.Instance.ConsultationsChanged += OnConsultationsChanged;

                this.Load += MainDashboardUserControl_Load;
            }
        }

        private async void MainDashboardUserControl_Load(object sender, EventArgs e)
        {
            // Create and store the initial Bulletin control
            _currentBulletinControl = new Bulletin();

            // Initialize presenter and load all counts from database
            var dbContext = new AppDbContext();
            _presenter = new DashboardPresenter(this, dbContext);

            // Load all dashboard data from database
            await _presenter.LoadBulletinCount();
            await _presenter.LoadConsultationStatsByProgram();
            await _presenter.LoadConsultationCounts();

            // Load bulletins from database into the control
            await RefreshBulletinDisplay();

            // Add the bulletin control to the panel and set default tab
            ActivityFeedPanel.Controls.Add(_currentBulletinControl);
            BulletinButton.CustomBorderThickness = new Padding(0, 0, 0, 3);
            BulletinButton.CustomBorderColor = Color.Red;
            BulletinButton.ForeColor = Color.Red;
        }

        private async void OnBulletinsChanged(object sender, EventArgs e)
        {
            // Reload bulletin count from database
            if (_presenter != null)
            {
                await _presenter.LoadBulletinCount();
            }

            // Refresh bulletin view if currently displayed
            if (_currentBulletinControl != null && ActivityFeedPanel.Controls.Contains(_currentBulletinControl))
            {
                await RefreshBulletinDisplay();
            }
        }

        private async void OnConsultationsChanged(object sender, EventArgs e)
        {
            // Reload consultation counts from database
            if (_presenter != null)
            {
                await _presenter.LoadConsultationCounts();
                await _presenter.LoadConsultationStatsByProgram();
            }

            // Refresh consultation view if currently displayed
            if (_currentConsultation2Control != null && !_currentConsultation2Control.IsDisposed && 
                ActivityFeedPanel.Controls.Contains(_currentConsultation2Control))
            {
                await RefreshConsultationDisplay(_currentConsultation2Control);
            }
        }

        public void UpdateBulletinCount(int count)
        {
            BulletinPublishedCount.Text = count.ToString();
        }

        private void UpdateBulletinCount()
        {
            // This method is deprecated - now using UpdateBulletinCount(int count) from database
            // Kept for backwards compatibility but calls the presenter
            if (_presenter != null)
            {
                _ = _presenter.LoadBulletinCount();
            }
        }

        private async Task RefreshBulletinDisplay()
        {
            if (_currentBulletinControl == null || _currentBulletinControl.IsDisposed)
                return;

            _currentBulletinControl.flowLayoutPanel1.Controls.Clear();

            var bulletins = await BulletinService.Instance.GetActiveBulletins();
            foreach (var bulletin in bulletins)
            {
                var card = new BulletinCards(
                    bulletin.Title,
                    bulletin.Status,
                    bulletin.Content,
                    bulletin.DatePosted
                );
                _currentBulletinControl.flowLayoutPanel1.Controls.Add(card);
            }
        }

        private async Task RefreshConsultationDisplay(Consultation2 consultationControl)
        {
            if (consultationControl == null || consultationControl.IsDisposed)
                return;

            consultationControl.flowLayoutPanel1.Controls.Clear();

            var consultations = await ConsultationService.Instance.GetActiveConsultations();
            
            foreach (var consultation in consultations)
            {
                try
                {
                    // Try to parse the date, default to current date if parsing fails
                    DateTime consultationDate;
                    if (!DateTime.TryParse(consultation.Date, out consultationDate))
                    {
                        consultationDate = DateTime.Now;
                    }

                    var card = new ConsultationCards(
                        consultation.Name,
                        consultation.Status,
                        consultation.Notes,
                        consultation.CourseCode,
                        consultationDate
                    );
                    consultationControl.flowLayoutPanel1.Controls.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating consultation card: {ex.Message}");
                    // Continue to next consultation if one fails
                }
            }
        }

        public void LoadRecentBulletins(List<BulletinModel> bulletins)
        {
            ActivityFeedPanel.Controls.Clear();

            foreach (var b in bulletins)
            {
                var card = new BulletinCards(b.Title, b.Status, b.Body, b.DatePosted);
                ActivityFeedPanel.Controls.Add(card);
            }
        }

        public void LoadRecentConsultations(List<ConsultationModel> consultations)
        {
            ActivityFeedPanel.Controls.Clear();

            foreach (var c in consultations)
            {
                var card = new ConsultationCards(c.Title, c.Status, c.Body, c.Course, c.DateScheduled);
                ActivityFeedPanel.Controls.Add(card);
            }
        }

        public void UpdateDashboardStats(int published, int pending, int completed, int upcoming)
        {
            // Update from service instead of parameter
            UpdateBulletinCount();
            ConsultationsCompletedCount.Text = completed.ToString();
            UpcomingSessionsCount.Text = upcoming.ToString();
        }

        public void UpdateConsultationStats(int CPE, int EE, int ECE, int CE, int ME, int CHE)
        {
            ConsultationCountCPE.Text = CPE.ToString();
            ConsultationCountEE.Text = EE.ToString();
            ConsultationCountECE.Text = ECE.ToString();
            ConsultationCountCE.Text = CE.ToString();
            ConsultationCountME.Text = ME.ToString();
            ConsultationCountCHE.Text = CHE.ToString();
        }

        public void UpdateConsultationCounts(int activeCount, int completedCount)
        {
            // Update ConsultationsCompletedCount with the count of archived consultations
            ConsultationsCompletedCount.Text = completedCount.ToString();

            // Update UpcomingSessionsCount with the count of active consultations
            UpcomingSessionsCount.Text = activeCount.ToString();
        }

        private async void BulletinButton_Click_1(object sender, EventArgs e)
        {
            ResetButtonBorders();
            BulletinButton.CustomBorderThickness = new Padding(0, 0, 0, 3);
            BulletinButton.CustomBorderColor = Color.Red;
            BulletinButton.ForeColor = Color.Red;

            ActivityFeedPanel.Controls.Clear();

            // Create new Bulletin control if it doesn't exist or reuse the existing one
            if (_currentBulletinControl == null || _currentBulletinControl.IsDisposed)
            {
                _currentBulletinControl = new Bulletin();
            }

            // Reload all bulletins from service (database)
            await RefreshBulletinDisplay();

            ActivityFeedPanel.Controls.Add(_currentBulletinControl);
        }

        private async void ConsultationButton_Click_1(object sender, EventArgs e)
        {
            ResetButtonBorders();
            ConsultationButton.CustomBorderThickness = new Padding(0, 0, 0, 3);
            ConsultationButton.CustomBorderColor = Color.Red;
            ConsultationButton.ForeColor = Color.Red;

            ActivityFeedPanel.Controls.Clear();
            
            // Create new Consultation2 control if it doesn't exist or reuse the existing one
            if (_currentConsultation2Control == null || _currentConsultation2Control.IsDisposed)
            {
                _currentConsultation2Control = new Consultation2();
            }
            
            // Load consultations from service (database)
            await RefreshConsultationDisplay(_currentConsultation2Control);
            
            ActivityFeedPanel.Controls.Add(_currentConsultation2Control);
        }

        private void ResetButtonBorders()
        {
            BulletinButton.CustomBorderThickness = new Padding(0, 0, 0, 0);
            ConsultationButton.CustomBorderThickness = new Padding(0, 0, 0, 0);

            BulletinButton.ForeColor = Color.Black;
            ConsultationButton.ForeColor = Color.Black;
        }

        private void AttachHoverEvents(Control parent, EventHandler onEnter, EventHandler onLeave)
        {
            parent.MouseEnter += onEnter;
            parent.MouseLeave += onLeave;

            foreach (Control child in parent.Controls)
            {
                AttachHoverEvents(child, onEnter, onLeave);
            }
        }

        private void createNewBulletin1_Load(object sender, EventArgs e)
        {
        }

        private void createNewBulletin1_MouseEnter(object sender, EventArgs e)
        {
            createNewBulletin1.BackColor = hoverColor;
        }

        private void createNewBulletin1_MouseLeave(object sender, EventArgs e)
        {
            createNewBulletin1.BackColor = bulletinDefaultColor;
        }

        private void manageConsultation1_MouseEnter(object sender, EventArgs e)
        {
            manageConsultation1.BackColor = hoverColor;
        }

        private void manageConsultation1_MouseLeave(object sender, EventArgs e)
        {
            manageConsultation1.BackColor = consultationDefaultColor;
        }

        private void createNewBulletin1_Click(object sender, EventArgs e)
        {
            // Create and show the CreateBulletin form
            var createBulletinForm = new CreateBulletin();

            // Subscribe to the BulletinPublished event
            createBulletinForm.BulletinPublished += OnBulletinPublished;

            createBulletinForm.ShowDialog();
        }

        // Event handler for when a bulletin is published
        private async void OnBulletinPublished(object sender, BulletinPublishedEventArgs e)
        {
            // The service already handles the bulletin publication and notification
            // Just ensure we're showing the bulletin tab
            ResetButtonBorders();
            BulletinButton.CustomBorderThickness = new Padding(0, 0, 0, 3);
            BulletinButton.CustomBorderColor = Color.Red;
            BulletinButton.ForeColor = Color.Red;

            // Make sure ActivityFeedPanel contains the Bulletin control
            if (_currentBulletinControl == null || _currentBulletinControl.IsDisposed)
            {
                _currentBulletinControl = new Bulletin();
                ActivityFeedPanel.Controls.Clear();
                ActivityFeedPanel.Controls.Add(_currentBulletinControl);
            }
            else if (!ActivityFeedPanel.Controls.Contains(_currentBulletinControl))
            {
                ActivityFeedPanel.Controls.Clear();
                ActivityFeedPanel.Controls.Add(_currentBulletinControl);
            }

            // Refresh the bulletin display immediately
            await RefreshBulletinDisplay();

            // Reload the bulletin count
            if (_presenter != null)
            {
                await _presenter.LoadBulletinCount();
            }
        }

        private void ConsultationCountCPE_Click(object sender, EventArgs e)
        {

        }

        private void ConsultationsCompletedCount_Click(object sender, EventArgs e)
        {

        }

        private void OnNavigateToConsultation(object sender, EventArgs e)
        {
            // Find the MainView form and trigger the Consultation button click
            var mainForm = this.FindForm();
            if (mainForm is MainView mainView)
            {
                // Find the Consultation button and trigger its click event
                var consultationButton = mainView.Controls.Find("buttonConsultation", true).FirstOrDefault() as Button;
                consultationButton?.PerformClick();
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void ConByDepLabel_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
