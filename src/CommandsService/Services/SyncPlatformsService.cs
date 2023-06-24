using Grpc.Core;

using MicroServicesDemo.CommandsService.Data.Repositories;
using MicroServicesDemo.CommandsService.Mappers;
using MicroServicesDemo.CommandsService.Models;
using MicroServicesDemo.PlatformsService.Shared.Protos;

using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.CommandsService.Services;

public sealed class SyncPlatformsService : BackgroundService
{
    private readonly PlatformGrpcService.PlatformGrpcServiceClient _client;
    private readonly ILogger<SyncPlatformsService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public SyncPlatformsService(PlatformGrpcService.PlatformGrpcServiceClient client, ILogger<SyncPlatformsService> logger, IServiceProvider serviceProvider)
    {
        _client = client;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBaseRepository<Platform, Guid>>();

        var call = _client.GetAll(GetAllRequest.Default, cancellationToken: stoppingToken);

        var responseStream = call.ResponseStream;

        await foreach (var reply in responseStream.ReadAllAsync(stoppingToken))
        {
            if (await repository.AsQueryable().Where(p => p.ExternalId == Guid.Parse(reply.Platform.PlatformId)).AnyAsync(stoppingToken))
                continue;

            var platform = reply.Platform.MapToEntity();

            await repository.AddAsync(platform, stoppingToken);
        }

        await repository.SaveChangesAsync(stoppingToken);
    }
}
