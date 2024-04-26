namespace Umeliko.Application.Learning.Follows.Commands.Delete;

using MediatR;
using System.Threading.Tasks;
using Umeliko.Application.Common;
using Umeliko.Application.Common.Contracts;
using Umeliko.Domain.Learning.Repositories;

public class DeleteFollowCommand : EntityCommand<int>, IRequest<Result>
{
    public string CreatorId { get; set; } = default!;

    public class DeleteFollowCommandHandler(ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IFollowDomainRepository followRepository)
        : IRequestHandler<DeleteFollowCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteFollowCommand request,
            CancellationToken cancellationToken)
        {
            var follower = await creatorRepository.FindByUser(
                currentUser.UserId,
                cancellationToken);

            var follow = await followRepository.Find(
                request.CreatorId,
                follower.Id,
                cancellationToken);

            if (follow == null)
            {
                return "You cannot unfollow this creator.";
            }

            return await followRepository.Delete(
                follow.CreatorId,
                follow.FollowerId,
                cancellationToken);
        }
    }
}
