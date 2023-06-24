using MicroServicesDemo.CommandsService.Models;
using MicroServicesDemo.CommandsService.Shared.Dtos.Platforms;
using MicroServicesDemo.PlatformsService.Shared.Messages;
using MicroServicesDemo.PlatformsService.Shared.Protos;

using Riok.Mapperly.Abstractions;

namespace MicroServicesDemo.CommandsService.Mappers;

[Mapper]
public static partial class PlatformMapper
{

    public static partial PlatformReadDto MapToReadDto(this Platform platform);

    public static partial IQueryable<PlatformReadDto> ProjectToReadDto(this IQueryable<Platform> platforms);

    public static partial Platform MapToEntity(this PlatformPublishedMessage message);

    [MapProperty(nameof(PlatformProto.PlatformId), nameof(Platform.ExternalId))]
    [MapProperty(nameof(PlatformProto.Name), nameof(Platform.Name))]
    public static partial Platform MapToEntity(this PlatformProto proto);

    private static string GuidToString(Guid guid) => guid.ToString("N");
}
