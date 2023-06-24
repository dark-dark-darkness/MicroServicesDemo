using MicroServicesDemo.CommandsService.Models;
using MicroServicesDemo.CommandsService.Shared.Dtos.Commands;

using Riok.Mapperly.Abstractions;

namespace MicroServicesDemo.CommandsService.Mappers;

[Mapper]
public static partial class CommandMapper
{
    public static partial Command MapToEntity(this CommandCreateDto dto);

    public static partial CommandReadDto MapToReadDto(this Command command);

    public static partial IQueryable<CommandReadDto> ProjectToReadDto(this IQueryable<Command> dtos);

}
