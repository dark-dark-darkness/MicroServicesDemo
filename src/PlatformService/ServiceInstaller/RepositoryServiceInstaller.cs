using MicroServicesDemo.PlatformService.Data.Repositories;

namespace MicroServicesDemo.PlatformService.ServiceInstaller;

public static class RepositoryServiceInstaller
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IPlatformRepository, PlatformRepository>();
        services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
        return services;
    }
}
