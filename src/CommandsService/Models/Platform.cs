namespace MicroServicesDemo.CommandsService.Models;

public sealed class Platform
{
    public Guid Id { get; init; }

    public Guid ExternalId { get; set; }

    public string Name { get; init; } = string.Empty;

    public ICollection<Command>? Commands { get; init; }
}
