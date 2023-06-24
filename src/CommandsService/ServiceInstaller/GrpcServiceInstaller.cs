using static MicroServicesDemo.PlatformsService.Shared.Protos.PlatformGrpcService;

namespace MicroServicesDemo.CommandsService.ServiceInstaller;

public static class GrpcServiceInstaller
{
    public static IServiceCollection AddGrpcService(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddGrpcClients(this IServiceCollection services)
    {
        services.AddGrpcClient<PlatformGrpcServiceClient>((sp, options) =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            options.Address = new Uri(configuration["PlatformsService:gRPC"]!);
        });

        return services;
    }

    public static WebApplication MapGrpcServices(this WebApplication app)
    {
        // app.MapGrpcService<>();
        return app;
    }

}
