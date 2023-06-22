namespace MicroServicesDemo.PlatformService.Models;

public sealed class Platform
{
    public Guid Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Publisher { get; init; } = string.Empty;

    public string Cost { get; init; } = string.Empty;
}
