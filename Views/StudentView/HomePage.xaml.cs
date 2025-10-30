using UM_Consultation_App_MAUI.ViewModels;

namespace UM_Consultation_App_MAUI.Views.StudentView;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel shpvm)
	{
		InitializeComponent();
        BindingContext = shpvm;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (BindingContext is HomeViewModel vm)
            vm.RefreshCommand.Execute(null);
    }
}