namespace MicroServicesDemo.CommandsService.Data.Repositories;

public interface IBaseRepository<TEntity, in TId>
        where TEntity : class
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

    IAsyncEnumerable<TEntity> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);

    IQueryable<TEntity> AsQueryable();

    Task AddAsync(TEntity platform, CancellationToken cancellationToken = default);

    Task RemoveAsync(TEntity platform, CancellationToken cancellationToken = default);
}
