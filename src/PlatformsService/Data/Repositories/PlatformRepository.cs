using MicroServicesDemo.PlatformsService.Models;

namespace MicroServicesDemo.PlatformsService.Data.Repositories;

public sealed class PlatformRepository : BaseRepository<Platform, Guid>, IPlatformRepository
{

    public PlatformRepository(AppDbContext db) : base(db)
    {
    }
}
