using MicroServicesDemo.CommandsService.Data;
using MicroServicesDemo.CommandsService.HostedServices;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.CommandsService.ServiceInstaller;

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
