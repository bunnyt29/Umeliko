namespace Umeliko.Application.Rating.Votes.Queries.Details;

using Application.Common.Contracts;
using Common;
using Domain.Common.Models;
using Domain.Learning.Repositories;
using MediatR;

public class VoteDetailsQuery : Entity<int>, IRequest<VoteOutputModel>
{
    public string MaterialId { get; set; } = default!;

    public class VoteDetailsQueryHandler(
            IVoteQueryRepository voteRepository,
            ICreatorDomainRepository creatorRepository,
            ICurrentUser currentUser)
        : IRequestHandler<VoteDetailsQuery, VoteOutputModel>
    {
        public async Task<VoteOutputModel> Handle(
            VoteDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var userId = currentUser.UserId;

            var creatorId = await creatorRepository.GetCreatorId(userId, cancellationToken);

            var voteDetails = await voteRepository.GetDetails(
                creatorId,
                request.MaterialId,
                cancellationToken);

            return voteDetails;
        }
    }
}
