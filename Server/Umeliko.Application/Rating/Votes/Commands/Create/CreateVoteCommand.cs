namespace Umeliko.Application.Rating.Votes.Commands.Create;

using Common;
using Domain.Rating.Models.Votes;
using MediatR;
using Umeliko.Application.Common.Contracts;
using Umeliko.Domain.Common.Models;
using Umeliko.Domain.Learning.Repositories;
using Umeliko.Domain.Rating.Repositories;

public class CreateVoteCommand : VoteCommand<CreateVoteCommand>, IRequest<CreateVoteOutputModel>
{
    public class CreateVoteCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IVoteDomainRepository voteRepository,
            IMaterialDomainRepository materialRepository)
        : IRequestHandler<CreateVoteCommand, CreateVoteOutputModel>
    {
        public async Task<CreateVoteOutputModel> Handle(
            CreateVoteCommand request,
            CancellationToken cancellationToken)
        {
            var creator = await creatorRepository.FindByUser(
                currentUser.UserId,
                cancellationToken);

            var material = await materialRepository.Find(
                request.MaterialId,
                cancellationToken);

            if (material == null)
            {
                return null;
            }

            var vote = new Vote(Enumeration.FromValue<VoteType>(request.VoteType), creator.Id, request.MaterialId);

            creator.AddVote(vote);
            material.AddVote(vote);

            await voteRepository.Save(vote, cancellationToken);

            return new CreateVoteOutputModel(vote.Id);
        }
    }
}
