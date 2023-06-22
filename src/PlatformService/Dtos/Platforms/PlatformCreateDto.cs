namespace MicroServicesDemo.PlatformService.Dtos.Platforms;

public record PlatformCreateDto(
    string Name,
    string Publisher,
    string Cost
);
