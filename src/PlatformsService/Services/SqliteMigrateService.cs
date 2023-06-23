using MicroServicesDemo.PlatformsService.Data;

namespace MicroServicesDemo.PlatformsService.Services;

sealed class SqliteMigrateService : BackgroundService
{

    private readonly IServiceProvider _sp;

    public SqliteMigrateService(IServiceProvider sp)
    {
        _sp = sp;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var scope = _sp.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.EnsureDeletedAsync(stoppingToken);
        await db.Database.EnsureCreatedAsync(stoppingToken);
    }
}
