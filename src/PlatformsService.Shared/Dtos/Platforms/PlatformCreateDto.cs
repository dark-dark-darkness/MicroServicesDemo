namespace MicroServicesDemo.PlatformsService.Shared.Dtos.Platforms;

public record PlatformCreateDto(
    string Name,
    string Publisher,
    string Cost
);
