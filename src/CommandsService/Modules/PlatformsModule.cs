using Carter;

using Mapster;

using MicroServicesDemo.CommandsService.Data.Repositories;
using MicroServicesDemo.CommandsService.Models;
using MicroServicesDemo.CommandsService.Shared.Dtos.Platforms;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.CommandsService.Modules;

public class PlatformsModule : ICarterModule
{
    private readonly ILogger<PlatformsModule> _logger;

    public PlatformsModule(ILogger<PlatformsModule> logger)
    {
        _logger = logger;
    }

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/c/platforms");

        group.MapGet("/", GetAll);
    }

    private static Ok<IAsyncEnumerable<PlatformReadDto>>
            GetAll([FromServices] IBaseRepository<Platform, Guid> repository)
    {
        return TypedResults.Ok(
            repository
                   .AsQueryable()
                   .ProjectToType<PlatformReadDto>()
                   .AsAsyncEnumerable());
    }
}
