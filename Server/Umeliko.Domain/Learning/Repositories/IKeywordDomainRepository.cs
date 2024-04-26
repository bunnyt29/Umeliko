namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Materials;

public interface IKeywordDomainRepository : IDomainRepository<Keyword>
{
    Task<Keyword> Find(int id, CancellationToken cancellationToken = default);

    Task<bool> Delete(int id, CancellationToken cancellationToken = default);
}
