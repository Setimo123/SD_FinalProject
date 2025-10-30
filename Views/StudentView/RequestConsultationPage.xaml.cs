using UM_Consultation_App_MAUI.ViewModels;
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm;


namespace UM_Consultation_App_MAUI.Views.StudentView;

public partial class RequestConsultationPage : ContentPage
{
    public RequestConsultationPage(RequestConsultationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	
    }

    protected override void OnAppearing()
	{
		base.OnAppearing();
		if (BindingContext is RequestConsultationViewModel rcvm)
		{
			rcvm.DisplayUserInformationOptionCommand.Execute(null);
        }
	}

}