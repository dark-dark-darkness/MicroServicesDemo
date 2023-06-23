using Carter;

using MicroServicesDemo.PlatformService.Shared.Dtos.Platforms;

using Microsoft.AspNetCore.Mvc;

namespace MicroServicesDemo.CommandsService.Modules;

public class PlatformsModule : ICarterModule
{

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/commands/platforms");

        group.MapGet("/",
            ([FromServices] ILogger<PlatformsModule> logger) =>
                    logger.LogInformation(" => Request!!!"));


        group.MapPost("/",
            ([FromBody] PlatformReadDto dto,
             [FromServices] ILogger<PlatformsModule> logger) =>
                    logger.LogInformation(" => Request!!!{@Body}", dto));
    }
}
