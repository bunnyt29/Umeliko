namespace Umeliko.Application.Learning.Follows.Commands.Create;

using MediatR;
using Umeliko.Application.Common;
using Umeliko.Application.Common.Contracts;
using Umeliko.Domain.Learning.Models.Creators;
using Umeliko.Domain.Learning.Repositories;

public class CreateFollowCommand : EntityCommand<int>, IRequest<Result>
{
    public string CreatorId { get; set; } = default!;

    public class CreateFollowCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IFollowDomainRepository followRepository)
        : IRequestHandler<CreateFollowCommand, Result>
    {
        public async Task<Result> Handle(
            CreateFollowCommand request,
            CancellationToken cancellationToken)
        {
            var follower = await creatorRepository.FindByUser(
                currentUser.UserId,
                cancellationToken);

            var creator = await creatorRepository.FindById(
                request.CreatorId,
                cancellationToken);

            var isCreatorAlreadyFollowed = await followRepository.IsAlreadyFollowed(
                creator.Id,
                follower.Id,
                cancellationToken);

            if (isCreatorAlreadyFollowed)
            {
                return "This user is already followed.";
            }

            var follow = new Follow(request.CreatorId, follower.Id);

            await followRepository.Save(follow, cancellationToken);

            return Result.Success;
        }
    }
}
