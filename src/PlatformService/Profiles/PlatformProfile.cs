using Mapster;

using MicroServicesDemo.PlatformService.Dtos.Platforms;
using MicroServicesDemo.PlatformService.Models;

namespace MicroServicesDemo.PlatformService.Profiles;

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
