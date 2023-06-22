using Serilog;

namespace MicroServicesDemo.PlatformService.ServiceInstaller;

public static class LogServiceInstaller
{
    public static IServiceCollection AddLog(this IServiceCollection services)
    {
        services.AddSerilog((sp, cfg) =>
                cfg.ReadFrom.Configuration(sp.GetRequiredService<IConfiguration>()));

        return services;
    }
}
