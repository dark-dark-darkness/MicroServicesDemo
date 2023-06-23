using MicroServicesDemo.PlatformsService.Data;

using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.PlatformsService.Services;

sealed class PgMigrateService : BackgroundService
{
    private readonly ILogger<PgMigrateService> _logger;
    private readonly IServiceProvider _sp;

    public PgMigrateService(IServiceProvider sp, ILogger<PgMigrateService> logger)
    {
        _sp = sp;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var scope = _sp.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (( await db.Database.GetPendingMigrationsAsync(stoppingToken) ).Any())
        {
            try
            {
                await db.Database.MigrateAsync(stoppingToken);
            } catch (Exception e)
            {
                _logger.LogError(e, "can not migration");
                throw;
            }
        }
    }
}
