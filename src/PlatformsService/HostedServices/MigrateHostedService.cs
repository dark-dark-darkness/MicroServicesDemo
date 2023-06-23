using MicroServicesDemo.PlatformsService.Data;

namespace MicroServicesDemo.PlatformsService.HostedServices;

sealed class MigrateHostedService : IHostedService
{
    private readonly IServiceProvider _sp;

    public MigrateHostedService(IServiceProvider sp)
    {
        _sp = sp;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = _sp.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.EnsureDeletedAsync(cancellationToken);
        await db.Database.EnsureCreatedAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
