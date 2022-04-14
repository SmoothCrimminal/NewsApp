using NewsApp.Services;

namespace NewsApp;

public partial class App : Application
{
	public App(IApiService apiService)
	{
		InitializeComponent();

		MainPage = new NavigationPage(new NewsPage(apiService));
	}
}
