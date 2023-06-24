using MicroServicesDemo.PlatformsService.Models;
using MicroServicesDemo.PlatformsService.Shared.Dtos.Platforms;
using MicroServicesDemo.PlatformsService.Shared.Messages;

using Riok.Mapperly.Abstractions;

namespace MicroServicesDemo.PlatformsService.Mappers;

[Mapper]
public static partial class PlatformMapper
{
    [ObjectFactory]
    private static PlatformPublishedMessage CreateMessage(Platform platform)
        => new (platform.Id, platform.Name, "Platform_Published");

    public static partial Platform MapToEntity(this PlatformCreateDto dto);

    public static partial PlatformReadDto MapToReadDto(this Platform dto);

    public static partial PlatformPublishedMessage MapToMessage(this Platform dto);

    public static partial IQueryable<PlatformReadDto> ProjectToReadDto(this IQueryable<Platform> dto);
    
    private static string GuidToString(Guid guid) => guid.ToString("N");

}
