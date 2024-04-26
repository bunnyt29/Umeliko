namespace Umeliko.Application.Learning.Follows.Commands.Common;

using Application.Common;
using Application.Common.Contracts;
using Domain.Learning.Repositories;

internal static class ChangeFollowCommandExtensions
{
    public static async Task<Result> CreatorHasFollow(
        this ICurrentUser currentUser,
        ICreatorDomainRepository creatorRepository,
        string followId,
        CancellationToken cancellationToken)
    {
        var creatorId = await creatorRepository.GetCreatorId(
            currentUser.UserId,
            cancellationToken);

        var creatorHasFollow = await creatorRepository.HasFollow(
            creatorId,
            followId,
            cancellationToken);

        return creatorHasFollow
            ? Result.Success
            : "You cannot unfollow this creator.";
    }
}
