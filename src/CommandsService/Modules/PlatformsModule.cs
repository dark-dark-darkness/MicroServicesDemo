using Carter;

using MicroServicesDemo.CommandsService.Data.Repositories;
using MicroServicesDemo.CommandsService.Mappers;
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

        group.MapGet("/{platformId:guid}", GetById);
        group.MapGet("/", GetAll);
    }

    private static async Task<Results<Ok<PlatformReadDto>, NotFound>>
            GetById(Guid platformId,
                    [FromServices] IBaseRepository<Platform, Guid> repository)
        => await repository.GetByIdAsync(platformId) is {} result
                ? TypedResults.Ok(result.MapToReadDto())
                : TypedResults.NotFound();

    private static Ok<IAsyncEnumerable<PlatformReadDto>>
            GetAll([FromServices] IBaseRepository<Platform, Guid> repository)
        => TypedResults.Ok(
            repository
                   .AsQueryable()
                   .ProjectToReadDto()
                   .AsAsyncEnumerable());
}
