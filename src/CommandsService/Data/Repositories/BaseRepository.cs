using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.CommandsService.Data.Repositories;

public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : class
{
    protected readonly AppDbContext db;

    private DbSet<TEntity>? _entitySet;


    public BaseRepository(AppDbContext db)
    {
        this.db = db;
    }

    private DbSet<TEntity> EntitySet => _entitySet ??= db.Set<TEntity>();

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await db.SaveChangesAsync(cancellationToken) != 0;
    }

    public IAsyncEnumerable<TEntity> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return EntitySet.AsAsyncEnumerable();
    }

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await EntitySet.FindAsync(new[] { id }, cancellationToken);
    }

    public IQueryable<TEntity> AsQueryable()
    {
        return EntitySet;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await EntitySet.AddAsync(entity, cancellationToken);
    }

    public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        EntitySet.Remove(entity);
        return Task.CompletedTask;
    }
}
