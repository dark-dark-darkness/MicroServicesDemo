using Mapster;

using MicroServicesDemo.CommandsService.Models;
using MicroServicesDemo.CommandsService.Shared.Dtos.Platforms;
using MicroServicesDemo.PlatformsService.Shared.Messages;

namespace MicroServicesDemo.CommandsService.Profiles;

public class PlatformProfile : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Platform, PlatformReadDto>();

        config.ForType<PlatformPublishedMessage, Platform>();
    }
}
