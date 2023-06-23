using Mapster;

using MicroServicesDemo.PlatformService.Shared.Dtos.Platforms;
using MicroServicesDemo.PlatformsService.Models;
using MicroServicesDemo.PlatformsService.Shared.Dtos.Platforms;

namespace MicroServicesDemo.PlatformsService.Profiles;

public class PlatformProfile : IRegister
{

    public void Register(TypeAdapterConfig config)
    {

        config.ForType<Platform, PlatformCreateDto>();

        config.ForType<PlatformCreateDto, Platform>();

        config.ForType<Platform, PlatformReadDto>();

        config.ForType<PlatformReadDto, Platform>();

    }
}
