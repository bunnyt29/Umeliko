namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Creators;

public interface ICategoryDomainRepository : IDomainRepository<Category>
{
    Task<Category> Find(string id, CancellationToken cancellationToken = default);

    Task<bool> Delete(string id, CancellationToken cancellationToken = default);
}
