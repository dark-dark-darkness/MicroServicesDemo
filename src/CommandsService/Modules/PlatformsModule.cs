using Carter;

namespace MicroServicesDemo.CommandsService.Modules;

public class PlatformsModule : ICarterModule
{

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/commands/platforms");
    }
}
