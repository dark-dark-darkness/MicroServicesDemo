using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MicroServicesDemo.PlatformsService.Data.Repositories;

public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : class
{
    protected readonly AppDbContext db;

    public BaseRepository(AppDbContext db)
    {
        this.db = db;
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await db.SaveChangesAsync(cancellationToken) != 0;
    }

    public IAsyncEnumerable<TEntity> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return db.Set<TEntity>().AsAsyncEnumerable();
    }

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await db.Set<TEntity>().FindAsync(new[] { id }, cancellationToken);
    }

    public IQueryable<TEntity> AsQueryable()
    {
        return db.Set<TEntity>();
    }

    public IDbContextTransaction BeginTransaction()
    {
        return db.Database.BeginTransaction();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await db.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        db.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
}
