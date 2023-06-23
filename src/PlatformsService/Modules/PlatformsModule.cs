using Carter;

using Mapster;

using MassTransit;

using MicroServicesDemo.PlatformsService.Data.Repositories;
using MicroServicesDemo.PlatformsService.Models;
using MicroServicesDemo.PlatformsService.Services;
using MicroServicesDemo.PlatformsService.Shared.Dtos.Platforms;
using MicroServicesDemo.PlatformsService.Shared.Messages;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace MicroServicesDemo.PlatformsService.Modules;

public class PlatformsModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/platforms");

        group.MapGet("/{id:guid}", GetById);

        group.MapGet("/", GetAll);

        group.MapPost("/", Create);

        group.MapDelete("/{id:guid}", Delete);

    }

    private static async Task<Results<Ok<PlatformReadDto>, NotFound<string>>>
            GetById(Guid id, [FromServices] IPlatformRepository repository, [FromServices] IStringLocalizer localizer)
    {
        return await repository
                    .AsQueryable()
                    .Where(p => p.Id == id)
                    .ProjectToType<PlatformReadDto>()
                    .FirstOrDefaultAsync() is {} result
                ? TypedResults.Ok(result)
                : TypedResults.NotFound(localizer["NotFount"].Value);
    }

    private static IAsyncEnumerable<PlatformReadDto>
            GetAll([FromServices] IPlatformRepository repository)
    {
        return repository
              .AsQueryable()
              .ProjectToType<PlatformReadDto>()
              .AsAsyncEnumerable();
    }

    private static async Task<Results<Created<PlatformReadDto>, BadRequest>>
            Create([FromBody] PlatformCreateDto dto,
                   [FromServices] IPlatformRepository repository, [FromServices] ICommandDataClient client,
                   [FromServices] IBus bus, [FromServices] ILogger<PlatformsModule> logger)
    {
        var e = dto.Adapt<Platform>();
        await repository.AddAsync(e);
        await repository.SaveChangesAsync();

        var readDto = e.Adapt<PlatformReadDto>();

        try
        {
            // Send Sync Message
            await client.SendPlatformToCommand(readDto);
        } catch (Exception exception)
        {
            logger.LogError(exception, "Send Sync Message Error");
        }

        try
        {
            //Send Async Message
            var message = e.Adapt<PlatformPublishedMessage>(
                new TypeAdapterConfig()
                       .ForType<Platform, PlatformPublishedMessage>()
                       .Map(m => m.Event, _ => "Platform_Published")
                       .Config);

            await bus.Publish(message);
        } catch (Exception exception)
        {
            logger.LogError(exception, "Send Async Message Error");
        }

        return TypedResults.Created($"/api/platforms/{e.Id}", readDto);
    }

    private static async Task<Results<Ok<PlatformReadDto>, BadRequest, NotFound<string>>>
            Delete(Guid id,
                   [FromServices] IPlatformRepository repository, [FromServices] IStringLocalizer localizer)
    {

        if (await repository.GetByIdAsync(id) is not {} entity)
        {
            return TypedResults.NotFound(localizer["NotFount"].Value);
        }

        await repository.RemoveAsync(entity);

        return await repository.SaveChangesAsync()
                ? TypedResults.Ok(entity.Adapt<PlatformReadDto>())
                : TypedResults.BadRequest();

    }
}
