namespace MicroServicesDemo.PlatformsService.Shared.Messages;

public sealed record PlatformPublishedMessage(
    Guid Id,
    string Name,
    string Event
);
