using Microsoft.Extensions.Configuration;
using NewsApp.Services;
using System.Reflection;

namespace NewsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
		builder.Services.AddScoped<IApiService, ApiService>();
		return builder.Build();
	}
}
