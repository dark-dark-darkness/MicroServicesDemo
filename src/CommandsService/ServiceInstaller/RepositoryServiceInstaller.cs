using MicroServicesDemo.CommandsService.Data.Repositories;

namespace MicroServicesDemo.CommandsService.ServiceInstaller;

public static class RepositoryServiceInstaller
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
        return services;
    }
}
