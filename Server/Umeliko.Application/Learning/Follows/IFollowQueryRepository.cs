namespace Umeliko.Application.Learning.Follows;

using Common.Contracts;
using Domain.Learning.Models.Creators;
using Queries;

public interface IFollowQueryRepository : IQueryRepository<Follow>
{
    Task<IList<FollowOutputModel>> GetFollowing(string id, CancellationToken cancellationToken = default);

    Task<IList<FollowOutputModel>> GetFollowers(string id, CancellationToken cancellationToken = default);
}
