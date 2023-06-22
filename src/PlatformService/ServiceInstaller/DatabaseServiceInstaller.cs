using MicroServicesDemo.PlatformService.Data;
using MicroServicesDemo.PlatformService.HostedServices;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.PlatformService.ServiceInstaller;

public static class DatabaseServiceInstaller
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        services.AddDbContext<AppDbContext>(options =>
                options
                       .UseSqlite(connection)
                       .UseSnakeCaseNamingConvention());

        services.AddHostedService<MigrateHostedService>();
        return services;
    }
}
