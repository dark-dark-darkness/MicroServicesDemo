using MicroServicesDemo.PlatformsService.Services;

using Refit;

namespace MicroServicesDemo.PlatformsService.ServiceInstaller;

public static class ClientServiceInstaller
{

    public static IServiceCollection AddClients(this IServiceCollection services)
    {
        services.AddRefitClient<ICommandDataClient>()
                .ConfigureHttpClient((sp, c) =>
                         c.BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>()["CommandsService"]!));

        return services;
    }
}
