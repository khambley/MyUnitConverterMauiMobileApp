﻿using Microsoft.Extensions.Logging;

namespace MyUnitConverter;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("FontAwesome.otf", "FontAwesome");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .RegisterAppTypes();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
	public static MauiAppBuilder RegisterAppTypes(this MauiAppBuilder mauiAppBuilder)
	{
		// Services
		mauiAppBuilder.Services.AddSingleton<Services.IRateService>((serviceProvider) => new Services.RateService());

		// ViewModels
		mauiAppBuilder.Services.AddTransient<ViewModels.MainViewModel>();

		// Views
		mauiAppBuilder.Services.AddTransient<MainPage>();

		return mauiAppBuilder;
	}
}

