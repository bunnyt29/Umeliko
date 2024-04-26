namespace Umeliko.Infrastructure.Common.Persistence;

using Domain.Common;

internal abstract class DataRepository<TDbContext, TEntity>(TDbContext db)
    : IDomainRepository<TEntity>
    where TDbContext : IDbContext
    where TEntity : class, IAggregateRoot
{
    protected TDbContext Data { get; } = db;

    protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

    public async Task Save(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        await this.Data.Set<TEntity>().AddAsync(entity, cancellationToken);

        await this.Data.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        this.Data.Set<TEntity>().Update(entity);

        await this.Data.SaveChangesAsync(cancellationToken);
    }
}
