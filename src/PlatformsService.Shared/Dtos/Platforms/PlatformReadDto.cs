namespace MicroServicesDemo.PlatformService.Shared.Dtos.Platforms;

public record PlatformReadDto(
    string Id,
    string Name,
    string Publisher,
    string Cost
);
