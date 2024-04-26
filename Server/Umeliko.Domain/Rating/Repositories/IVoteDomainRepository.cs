namespace Umeliko.Domain.Rating.Repositories;

using Common;
using Models.Votes;

public interface IVoteDomainRepository : IDomainRepository<Vote>
{
    Task<Vote> Find(int id, CancellationToken cancellationToken = default);

    Task<bool> Delete(int id, CancellationToken cancellationToken = default);
}
