using Mapster;

namespace MicroServicesDemo.CommandsService.ServiceInstaller;

public static class MapperServiceInstaller
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly);
        TypeAdapterConfig.GlobalSettings.Compile();
        return services;
    }
}
