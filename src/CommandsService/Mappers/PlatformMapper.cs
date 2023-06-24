using MicroServicesDemo.CommandsService.Models;
using MicroServicesDemo.CommandsService.Shared.Dtos.Platforms;
using MicroServicesDemo.PlatformsService.Shared.Messages;

using Riok.Mapperly.Abstractions;

namespace MicroServicesDemo.CommandsService.Mappers;

[Mapper]
public static partial class PlatformMapper
{

    public static partial PlatformReadDto MapToReadDto(this Platform platform);

    public static partial IQueryable<PlatformReadDto> ProjectToReadDto(this IQueryable<Platform> platforms);

    public static partial Platform MapToEntity(this PlatformPublishedMessage message);

    private static string GuidToString(Guid guid) => guid.ToString("N");
}
