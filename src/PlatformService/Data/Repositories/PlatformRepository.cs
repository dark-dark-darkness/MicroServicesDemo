using MicroServicesDemo.PlatformService.Models;

namespace MicroServicesDemo.PlatformService.Data.Repositories;

public sealed class PlatformRepository : BaseRepository<Platform, Guid>, IPlatformRepository
{

    public PlatformRepository(AppDbContext db) : base(db)
    {
    }
}
