using Mapster;

using MicroServicesDemo.CommandsService.Models;
using MicroServicesDemo.CommandsService.Shared.Dtos.Commands;

namespace MicroServicesDemo.CommandsService.Profiles;

public class CommandProfile : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CommandCreateDto, Command>();

        config.ForType<Command, CommandReadDto>();
    }
}
