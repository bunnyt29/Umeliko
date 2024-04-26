namespace Umeliko.Application.Rating.Votes;

using Common.Contracts;
using Domain.Rating.Models.Votes;
using Umeliko.Application.Rating.Votes.Queries.Common;

public interface IVoteQueryRepository : IQueryRepository<Vote>
{
    Task<IEnumerable<VoteOutputModel>> GetAll(string materialId, CancellationToken cancellationToken = default);

    Task<VoteOutputModel> GetDetails(string creatorId, string materialId, CancellationToken cancellationToken = default);
}
