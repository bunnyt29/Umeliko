namespace Umeliko.Application.Learning.Materials.Commands.Common;

using Application.Common;
using Application.Common.Contracts;
using Domain.Learning.Repositories;

internal static class ChangeMaterialCommandExtensions
{
    public static async Task<Result> CreatorHasMaterial(
        this ICurrentUser currentUser,
        ICreatorDomainRepository creatorRepository,
        string materialId,
        CancellationToken cancellationToken)
    {
        var creatorId = await creatorRepository.GetCreatorId(
            currentUser.UserId,
            cancellationToken);

        var creatorHasMaterial = await creatorRepository.HasMaterial(
            creatorId,
            materialId,
            cancellationToken);

        return creatorHasMaterial
            ? Result.Success
            : "You cannot edit this material.";
    }
}
