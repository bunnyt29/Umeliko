namespace Umeliko.Application.Learning.Banners.Commands.Common;

using Application.Common;
using Domain.Learning.Repositories;

internal static class ChangeBannerCommandExtensions
{
    public static async Task<Result> MaterialHasBanner(
        string materialId,
        IMaterialDomainRepository materialRepository,
        string bannerId,
        CancellationToken cancellationToken)
    {
        var materialHasBanner = await materialRepository.HasBanner(
            materialId,
            bannerId,
            cancellationToken);

        return materialHasBanner
            ? Result.Success
            : "You cannot edit this banner.";
    }
}
