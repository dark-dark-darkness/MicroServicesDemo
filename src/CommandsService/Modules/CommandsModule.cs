using Carter;

using MicroServicesDemo.CommandsService.Data.Repositories;
using MicroServicesDemo.CommandsService.Mappers;
using MicroServicesDemo.CommandsService.Models;
using MicroServicesDemo.CommandsService.Shared.Dtos.Commands;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.CommandsService.Modules;

public class CommandsModule : ICarterModule
{
    private readonly ILogger<CommandsModule> _logger;

    public CommandsModule(ILogger<CommandsModule> logger)
    {
        _logger = logger;
    }

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/c/platforms/{platformId:guid}/commands");
        group.MapGet("/{commandId:guid}", GetCommandForPlatform);
        group.MapGet("", GetCommandsForPlatform);
        group.MapPost("", CreateCommandForPlatform);
    }

    private static async Task<Results<Ok<CommandReadDto>, NotFound>>
            GetCommandForPlatform(
                Guid platformId, Guid commandId,
                [FromServices] IBaseRepository<Command, Guid> repository)
    {
        return await repository
                    .AsQueryable()
                    .Where(c => c.PlatformId == platformId && c.Id == commandId)
                    .ProjectToReadDto()
                    .FirstOrDefaultAsync() is {} res
                ? TypedResults.Ok(res)
                : TypedResults.NotFound();
    }

    private static async Task<Results<Ok<IAsyncEnumerable<CommandReadDto>>, NotFound>>
            GetCommandsForPlatform(
                Guid platformId,
                [FromServices] IBaseRepository<Command, Guid> repository)
    {

        if (!await repository.AsQueryable().Where(p => p.PlatformId == platformId).AnyAsync())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(
            repository
                   .AsQueryable()
                   .Where(c => c.PlatformId == platformId)
                   .ProjectToReadDto()
                   .AsAsyncEnumerable());
    }

    private static async Task<Results<Created<CommandReadDto>, NotFound>>
            CreateCommandForPlatform(
                [FromRoute] Guid platformId,
                [FromBody] CommandCreateDto createDto,
                [FromServices] IBaseRepository<Command, Guid> repository)
    {
        if (!await repository.AsQueryable().Where(p => p.PlatformId == platformId).AnyAsync())
        {
            return TypedResults.NotFound();
        }

        var command = createDto.MapToEntity();
        command.PlatformId = platformId;

        await repository.AddAsync(command);
        await repository.SaveChangesAsync();

        var result = command.MapToReadDto();
        return TypedResults.Created($"/api/c/platforms/{platformId}/commands/{command.Id}", result);

    }
}
