using Consultation.App.Views.Controls.BulletinManagement;
using Consultation.App.Dashboard.Activity_Feed_Panel;
using Consultation.App.Presenters;
using Consultation.App.ViewModels.DashboardModels;
using Consultation.App.Views.Controls.Dashboard.Quick_Actions_Panel;
using Consultation.App.Views.IViews;
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
        
        // Track the published bulletin count
        private int _publishedBulletinCount = 0;
        
        // Store reference to the current Bulletin control to persist bulletin cards
        private Bulletin _currentBulletinControl;
        
        // List to store all published bulletins
        private List<BulletinCardData> _publishedBulletins = new List<BulletinCardData>();

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
                addUser1.Cursor = Cursors.Hand;
                BulletinButton.Cursor = Cursors.Hand;
                ConsultationButton.Cursor = Cursors.Hand;

                bulletinDefaultColor = createNewBulletin1.BackColor;
                consultationDefaultColor = manageConsultation1.BackColor;

                //hover events for buttons
                AttachHoverEvents(createNewBulletin1, createNewBulletin1_MouseEnter, createNewBulletin1_MouseLeave);
                AttachHoverEvents(manageConsultation1, manageConsultation1_MouseEnter, manageConsultation1_MouseLeave);
                AttachHoverEvents(addUser1, addUser1_MouseEnter, addUser1_MouseLeave);

                // Subscribe to the BulletinPublished event from createNewBulletin1 control
                createNewBulletin1.BulletinPublished += OnBulletinPublished;

                this.Load += MainDashboardUserControl_Load;
            }
        }

        private void MainDashboardUserControl_Load(object sender, EventArgs e)
        {
            // Create and store the initial Bulletin control
            _currentBulletinControl = new Bulletin();
            ActivityFeedPanel.Controls.Add(_currentBulletinControl);
            BulletinButton.CustomBorderThickness = new Padding(0, 0, 0, 3);

            // Initialize the count display
            BulletinPublishedCount.Text = _publishedBulletinCount.ToString();

            // _presenter = new DashboardPresenter(this);
            //  _presenter.LoadDashboardData();
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
            _publishedBulletinCount = published;
            BulletinPublishedCount.Text = published.ToString();
            PendingApprovalsCount.Text = pending.ToString();
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

        private void BulletinButton_Click_1(object sender, EventArgs e)
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
                
                // Reload all published bulletins
                foreach (var bulletinData in _publishedBulletins)
                {
                    var card = new BulletinCards(
                        bulletinData.Title,
                        bulletinData.Status,
                        bulletinData.Content,
                        bulletinData.DatePosted
                    );
                    _currentBulletinControl.flowLayoutPanel1.Controls.Add(card);
                }
            }
            
            ActivityFeedPanel.Controls.Add(_currentBulletinControl);
        }

        private void ConsultationButton_Click_1(object sender, EventArgs e)
        {
            ResetButtonBorders();
            ConsultationButton.CustomBorderThickness = new Padding(0, 0, 0, 3);
            ConsultationButton.CustomBorderColor = Color.Red;
            ConsultationButton.ForeColor = Color.Red;

            ActivityFeedPanel.Controls.Clear();
            ActivityFeedPanel.Controls.Add(new Consultation2());
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

        private void addUser1_MouseEnter(object sender, EventArgs e)
        {
            addUser1.BackColor = hoverColor;
        }

        private void addUser1_MouseLeave(object sender, EventArgs e)
        {
            addUser1.BackColor = consultationDefaultColor;
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
        private void OnBulletinPublished(object sender, BulletinPublishedEventArgs e)
        {
            // Increment the published count
            _publishedBulletinCount++;
            BulletinPublishedCount.Text = _publishedBulletinCount.ToString();

            // Store the bulletin data for persistence
            var bulletinData = new BulletinCardData
            {
                Title = e.Title,
                Status = e.Status,
                Content = e.Content,
                DatePosted = e.DatePosted
            };
            _publishedBulletins.Insert(0, bulletinData); // Add to the beginning of the list

            // Create a new BulletinCards control with the published bulletin data
            var bulletinCard = new BulletinCards(
                e.Title,
                e.Status,
                e.Content,
                e.DatePosted
            );

            // Ensure we're on the Bulletin tab and have the Bulletin control
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

            // Add the new bulletin card to the top of the flowLayoutPanel
            _currentBulletinControl.flowLayoutPanel1.Controls.Add(bulletinCard);
            _currentBulletinControl.flowLayoutPanel1.Controls.SetChildIndex(bulletinCard, 0);
        }
    }
}
