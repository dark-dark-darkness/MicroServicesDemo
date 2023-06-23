using MicroServicesDemo.PlatformsService.Shared.Dtos.Platforms;

using Refit;

namespace MicroServicesDemo.PlatformsService.Services;

public interface ICommandDataClient
{


    [Post("/api/commands/platforms")]
    public Task SendPlatformToCommand([Body] PlatformReadDto dto, CancellationToken cancellationToken = default);
}
