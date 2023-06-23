using Carter;

using Microsoft.OpenApi.Models;

namespace MicroServicesDemo.PlatformsService.ServiceInstaller;

public static class EndpointServiceInstaller
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {

        // Add services to the container.
        services.AddCarter();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlatformsService", Version = "1.0" }));

        services.AddAuthorization();
        return services;
    }
}
