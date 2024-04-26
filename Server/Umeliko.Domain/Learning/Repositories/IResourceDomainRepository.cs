namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Materials;

public interface IResourceDomainRepository : IDomainRepository<Resource>
{
    Task<Resource> Find(int id, CancellationToken cancellationToken = default);

    Task<bool> Delete(int id, CancellationToken cancellationToken = default);
}
