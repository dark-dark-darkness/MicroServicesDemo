namespace MicroServicesDemo.CommandsService.Shared.Dtos.Commands;

public record CommandCreateDto(
    string HowTo,
    string CommandLine
);
