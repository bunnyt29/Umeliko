namespace Umeliko.Application.Rating.Votes.Commands.Common;

using Application.Common;
using Application.Common.Contracts;
using Domain.Learning.Repositories;

internal static class ChangeVoteCommandExtensions
{
    public static async Task<Result> CreatorHasVote(
        this ICurrentUser currentUser,
        ICreatorDomainRepository creatorRepository,
        int voteId,
        CancellationToken cancellationToken)
    {
        var creatorId = await creatorRepository.GetCreatorId(
            currentUser.UserId,
            cancellationToken);

        var creatorHasVote = await creatorRepository.HasVote(
            creatorId,
            voteId,
            cancellationToken);

        return creatorHasVote
            ? Result.Success
            : "You cannot change this vote.";
    }

    public static async Task<Result> MaterialHasVote(
        string materialId,
        IMaterialDomainRepository materialRepository,
        int voteId,
        CancellationToken cancellationToken)
    {
        var materialHasVote = await materialRepository.HasVote(
            materialId,
            voteId,
            cancellationToken);

        return materialHasVote
            ? Result.Success
            : "You cannot change this vote.";
    }
}
