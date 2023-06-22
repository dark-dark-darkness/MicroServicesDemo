using System.Globalization;

using Microsoft.AspNetCore.Localization;

namespace MicroServicesDemo.CommandsService.ServiceInstaller;

// ReSharper disable once InconsistentNaming
public static class I18nServiceInstaller
{
    // ReSharper disable once InconsistentNaming
    public static IServiceCollection AddI18n(this IServiceCollection services)
    {
        services.AddJsonLocalization(options => options.ResourcesPath = "Resources");
        return services;
    }

    // ReSharper disable once InconsistentNaming
    public static WebApplication UseI18n(this WebApplication app)
    {
        var supportedCultures = new CultureInfo[]
        {
            new ("en"),
            new ("zh")
        };

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("zh"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });

        return app;
    }
}
