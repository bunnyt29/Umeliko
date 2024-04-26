namespace Umeliko.Application.Rating.Votes.Commands.Delete;

using Application.Common;
using Application.Common.Contracts;
using Common;
using Domain.Common.Models;
using Domain.Learning.Repositories;
using Domain.Rating.Repositories;
using MediatR;

public class DeleteVoteCommand : Entity<int>, IRequest<Result>
{
    public string MaterialId { get; set; } = default!;

    public class DeleteVoteCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IVoteDomainRepository voteRepository,
            IMaterialDomainRepository materialRepository)
        : IRequestHandler<DeleteVoteCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteVoteCommand request,
            CancellationToken cancellationToken)
        {
            var creatorHasVote = await currentUser.CreatorHasVote(
                creatorRepository,
                request.Id,
                cancellationToken);

            if (!creatorHasVote)
            {
                return creatorHasVote;
            }

            var materialHasVote = await materialRepository.HasVote(
                request.MaterialId,
                request.Id,
                cancellationToken);

            if (!materialHasVote)
            {
                return materialHasVote;
            }

            return await voteRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
