using Carter;

using Microsoft.OpenApi.Models;

namespace MicroServicesDemo.PlatformService.ServiceInstaller;

public static class ApiServiceInstaller
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {

        // Add services to the container.
        services.AddCarter();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlatformService", Version = "1.0" }));

        services.AddAuthorization();
        return services;
    }
}
