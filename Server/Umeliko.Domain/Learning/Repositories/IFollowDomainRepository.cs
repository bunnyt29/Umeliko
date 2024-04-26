namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Creators;

public interface IFollowDomainRepository : IDomainRepository<Follow>
{
    Task<Follow> Find(
        string creatorId,
        string followerId,
        CancellationToken cancellationToken = default);

    Task<bool> IsAlreadyFollowed(
        string creatorId,
        string followerId,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        string creatorId,
        string followerId,
        CancellationToken cancellationToken = default);
}
