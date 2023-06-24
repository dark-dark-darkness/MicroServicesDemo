using Grpc.Core;

using MicroServicesDemo.PlatformsService.Data.Repositories;
using MicroServicesDemo.PlatformsService.Mappers;
using MicroServicesDemo.PlatformsService.Models;
using MicroServicesDemo.PlatformsService.Shared.Protos;

using static MicroServicesDemo.PlatformsService.Shared.Protos.PlatformGrpcService;

namespace MicroServicesDemo.PlatformsService.Grpc;

public sealed class GrpcPlatformService : PlatformGrpcServiceBase
{
    private readonly IBaseRepository<Platform, Guid> _repository;
    private readonly ILogger<GrpcPlatformService> _logger;

    public GrpcPlatformService(IBaseRepository<Platform, Guid> repository, ILogger<GrpcPlatformService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public override async Task GetAll(GetAllRequest request, IServerStreamWriter<GetAllReply> responseStream, ServerCallContext context)
    {
        _logger.LogInformation("Call GrpcPlatformService GetAll");

        await foreach (var platform in _repository.GetAllAsync())
        {
            await responseStream.WriteAsync(new GetAllReply { Platform = platform.MapToProto() });
        }
    }



}
