using Consultation.App.Views.IViews;

namespace Consultation.App
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
        }
        public UserControl AsUserControl => this;
    }
}
