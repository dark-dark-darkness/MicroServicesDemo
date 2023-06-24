namespace MicroServicesDemo.CommandsService.Models;

public sealed class Command
{

    public Guid Id { get; init; }

    public string HowTo { get; set; } = string.Empty;

    public string CommandLine { get; set; } = string.Empty;

    public Guid PlatformId { get; set; }

    public Platform? Platform { get; init; }
}
