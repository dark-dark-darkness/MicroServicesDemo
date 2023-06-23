namespace MicroServicesDemo.CommandsService.Models;

public sealed class Command
{

    public Guid Id { get; init; }

    public string HowTo { get; init; } = string.Empty;

    public string CommandLine { get; init; } = string.Empty;

    public Guid PlatformId { get; init; }

    public Platform? Platform { get; init; }
}
