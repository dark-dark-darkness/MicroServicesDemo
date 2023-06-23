using Mapster;

using MicroServicesDemo.PlatformsService.Models;
using MicroServicesDemo.PlatformsService.Shared.Dtos.Platforms;
using MicroServicesDemo.PlatformsService.Shared.Messages;

namespace MicroServicesDemo.PlatformsService.Profiles;

public class PlatformProfile : IRegister
{

    public void Register(TypeAdapterConfig config)
    {

        config.ForType<PlatformCreateDto, Platform>();

        config.ForType<Platform, PlatformReadDto>();

        config.ForType<Platform, PlatformPublishedMessage>();

    }
}
