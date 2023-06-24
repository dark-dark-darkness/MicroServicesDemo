using MicroServicesDemo.CommandsService.Data;
using MicroServicesDemo.CommandsService.Services;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.CommandsService.ServiceInstaller;

public static class DatabaseServiceInstaller
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        var connectionString = configuration.GetConnectionString("Default")!;

        AddSqlite(services, connectionString);

        services.AddHostedService<SyncPlatformsService>();

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
