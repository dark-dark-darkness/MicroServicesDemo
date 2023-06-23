using MicroServicesDemo.PlatformsService.Data;
using MicroServicesDemo.PlatformsService.Services;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.PlatformsService.ServiceInstaller;

public static class DatabaseServiceInstaller
{

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        var connectionString = configuration.GetConnectionString("Default")!;

        if (environment.IsProduction())
        {
            AddPgsql(services, connectionString);
        }
        else
        {
            AddSqlite(services, connectionString);
        }

        return services;
    }

    private static void AddPgsql(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
                options
                       .UseNpgsql(connectionString)
                       .UseSnakeCaseNamingConvention());

        services.AddHostedService<PgMigrateService>();
    }

    private static void AddSqlite(IServiceCollection services, string connectionString)
    {
        var connection = new SqliteConnection(connectionString);
        connection.Open();
        services.AddDbContext<AppDbContext>(options =>
                options
                       .UseSqlite(connection)
                       .UseSnakeCaseNamingConvention());

        services.AddHostedService<SqliteMigrateService>();
    }
}
