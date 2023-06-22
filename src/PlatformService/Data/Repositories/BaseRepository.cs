namespace MicroServicesDemo.PlatformService.Data.Repositories;

public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : class
{
    protected readonly AppDbContext _db;

    protected BaseRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _db.SaveChangesAsync(cancellationToken) != 0;
    }

    public IAsyncEnumerable<TEntity> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _db.Set<TEntity>().AsAsyncEnumerable();
    }

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await _db.Set<TEntity>().FindAsync(new[] { id }, cancellationToken);
    }

    public IQueryable<TEntity> AsQueryable()
    {
        return _db.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _db.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _db.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
}
