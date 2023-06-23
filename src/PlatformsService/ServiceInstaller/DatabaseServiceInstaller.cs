using MicroServicesDemo.PlatformsService.Data;
using MicroServicesDemo.PlatformsService.Services;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.PlatformsService.ServiceInstaller;

public static class DatabaseServiceInstaller
{

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        if (environment.IsProduction())
        {
            AddPgsql(services, configuration);
        }
        else
        {
            AddSqlite(services, configuration);
        }

        return services;
    }

    private static void AddPgsql(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
                options
                       .UseNpgsql(configuration.GetConnectionString("default"))
                       .UseSnakeCaseNamingConvention());

        services.AddHostedService<PgMigrateService>();
    }

    private static void AddSqlite(IServiceCollection services, IConfiguration configuration)
    {
        var connection = new SqliteConnection(configuration["default"]);
        connection.Open();
        services.AddDbContext<AppDbContext>(options =>
                options
                       .UseSqlite(connection)
                       .UseSnakeCaseNamingConvention());

        services.AddHostedService<SqliteMigrateService>();
    }
}
