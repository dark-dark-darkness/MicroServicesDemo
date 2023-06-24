using MicroServicesDemo.PlatformsService.Grpc;

namespace MicroServicesDemo.PlatformsService.ServiceInstaller;

public static class GrpcServiceInstaller
{

    public static IServiceCollection AddGrpcService(this IServiceCollection services)
    {
        services.AddGrpc();
        return services;
    }

    public static IServiceCollection AddGrpcClients(this IServiceCollection services)
    {
        return services;
    }


    public static WebApplication MapGrpcServices(this WebApplication app)
    {
        app.MapGrpcService<GrpcPlatformService>();
        return app;
    }

}
