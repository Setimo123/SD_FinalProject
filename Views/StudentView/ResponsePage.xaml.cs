using UM_Consultation_App_MAUI.ViewModels;

namespace UM_Consultation_App_MAUI.Views.StudentView;

public partial class ResponsePage : ContentPage
{
    public ResponseViewModel VM => (ResponseViewModel)BindingContext;
    public ResponsePage(ResponseViewModel rvm)
	{
		InitializeComponent();
		BindingContext = rvm;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (BindingContext is ResponseViewModel vm)
            vm.LoadResponsesCommand.Execute(null);
    }
}