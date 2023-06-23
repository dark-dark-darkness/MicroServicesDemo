using MicroServicesDemo.CommandsService.Data;

namespace MicroServicesDemo.CommandsService.Services;

sealed class SqliteMigrateService : BackgroundService
{
    private readonly ILogger<SqliteMigrateService> _logger;

    private readonly IServiceProvider _sp;

    public SqliteMigrateService(IServiceProvider sp, ILogger<SqliteMigrateService> logger)
    {
        _sp = sp;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var scope = _sp.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            await db.Database.EnsureDeletedAsync(stoppingToken);
            await db.Database.EnsureCreatedAsync(stoppingToken);
        } catch (Exception e)
        {
            _logger.LogError(e, "can not migration");
            throw;
        }
    }
}
