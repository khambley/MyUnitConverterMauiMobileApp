namespace MyUnitConverter;

public partial class App : Application
{
	public App(MainPage view)
	{
		InitializeComponent();

		MainPage = new NavigationPage(view);
	}
}

