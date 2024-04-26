namespace Umeliko.Domain.Common;

public interface IDomainRepository<in TEntity>
    where TEntity : IAggregateRoot
{
    Task Save(TEntity entity, CancellationToken cancellationToken = default);

    Task Update(TEntity entity, CancellationToken cancellationToken = default);
}