using UM_Consultation_App_MAUI.ViewModels;

namespace UM_Consultation_App_MAUI.Views.StudentView;

public partial class RequestPage : ContentPage
{
	public RequestPage(RequestViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}


}