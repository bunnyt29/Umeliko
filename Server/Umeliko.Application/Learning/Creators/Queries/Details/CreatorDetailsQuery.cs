namespace Umeliko.Application.Learning.Creators.Queries.Details;

using Application.Common.Contracts;
using Domain.Learning.Repositories;
using Follows;
using MediatR;

public class CreatorDetailsQuery : IRequest<CreatorDetailsOutputModel>
{
    public string Id { get; set; }

    public class CreatorDetailsQueryHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorDomainRepository,
            ICreatorQueryRepository creatorQueryRepository,
            IFollowQueryRepository followQueryRepository)
        : IRequestHandler<CreatorDetailsQuery, CreatorDetailsOutputModel>
    {
        public async Task<CreatorDetailsOutputModel> Handle(
            CreatorDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var creatorId = request.Id;

            if (creatorId == null)
            {
                var creator = await creatorDomainRepository.FindByUser(
                    currentUser.UserId,
                    cancellationToken);

                creatorId = creator.Id;
            }

            var creatorData = await creatorQueryRepository.GetDetails(
                creatorId,
                cancellationToken);

            if (creatorData == null)
            {
                return null;
            }

            creatorData.UserName = await creatorQueryRepository.GetUserName(creatorData.Id, cancellationToken);
            creatorData.Email = await creatorQueryRepository.GetEmail(creatorData.Id, cancellationToken);

            var followers = await followQueryRepository.GetFollowers(creatorData.Id, cancellationToken);

            foreach (var follower in followers)
            {
                var currentFollower = await creatorQueryRepository.Get(follower.FollowerId, cancellationToken);
                currentFollower.UserName = await creatorQueryRepository.GetUserName(currentFollower.Id, cancellationToken);

                creatorData.Followers.Add(currentFollower);
            }

            var following = await followQueryRepository.GetFollowing(creatorData.Id, cancellationToken);

            foreach (var creator in following)
            {
                var currentCreator = await creatorQueryRepository.Get(creator.CreatorId, cancellationToken);
                currentCreator.UserName = await creatorQueryRepository.GetUserName(currentCreator.Id, cancellationToken);

                creatorData.Following.Add(currentCreator);
            }

            return creatorData;
        }
    }
}
