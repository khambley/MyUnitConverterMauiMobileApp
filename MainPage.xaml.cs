using MyUnitConverter.ViewModels;

namespace MyUnitConverter;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		viewModel.Navigation = Navigation;
		BindingContext = viewModel;
	}

	
}


