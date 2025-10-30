using UM_Consultation_App_MAUI.ViewModels;
using UM_Consultation_App_MAUI.Views.FacultyView;
using UM_Consultation_App_MAUI.Views.StudentView;

namespace UM_Consultation_App_MAUI.Views.Common;

public partial class MenuPage : ContentPage
{    
	public MenuPage(MenuViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
    // Migration from Benny
    // feel free to modify this backend team
    // dli ni final na pag backend kay para rani ma meet ang desired output sa UI
    private void OnAccountTapped(object sender, EventArgs e)
    {
        bool isExpanded = !AccountDetails.IsVisible;
        AccountDetails.IsVisible = isExpanded;


        ArrowIcon.RotateTo(isExpanded ? 180 : 0, 200, Easing.CubicInOut);
    }

}