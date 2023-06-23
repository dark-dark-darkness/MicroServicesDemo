using Mapster;

using MassTransit;

using MicroServicesDemo.CommandsService.Data.Repositories;
using MicroServicesDemo.CommandsService.Models;
using MicroServicesDemo.PlatformsService.Shared.Messages;

namespace MicroServicesDemo.CommandsService.Handler;

public class PlatformPublishedMessageConsumer : IConsumer<PlatformPublishedMessage>
{
    private readonly IBaseRepository<Platform, Guid> _repository;

    public PlatformPublishedMessageConsumer(IBaseRepository<Platform, Guid> repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<PlatformPublishedMessage> context)
    {

        var entity =
                context.Message
                       .Adapt<Platform>(new TypeAdapterConfig());

        await _repository.AddAsync(entity, context.CancellationToken);
        await _repository.SaveChangesAsync(context.CancellationToken);
    }
}
