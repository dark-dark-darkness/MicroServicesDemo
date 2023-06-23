namespace MicroServicesDemo.CommandsService.Shared.Dtos.Commands;

public sealed record CommandReadDto(
    string Id,
    string HowTo,
    string CommandLine,
    string PlatformId
);
