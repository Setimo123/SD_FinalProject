using UM_Consultation_App_MAUI.ViewModels;

namespace UM_Consultation_App_MAUI.Views.FacultyView;

public partial class ConsultationListPage : ContentPage
{
	public ConsultationListPage(FacultyCLPViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (BindingContext is FacultyCLPViewModel vm)
            vm.DisplayConsultationCommand.Execute(null);
    }
}