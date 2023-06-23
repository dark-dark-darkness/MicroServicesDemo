using Mapster;

namespace MicroServicesDemo.PlatformsService.ServiceInstaller;

public static class MapperServiceInstaller
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddMapster();
        TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly);
        TypeAdapterConfig.GlobalSettings.Compile();
        return services;
    }
}
