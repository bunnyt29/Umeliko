namespace Umeliko.Application.Learning.Banners.Queries.Details;

using MediatR;
using Umeliko.Application.Common;

public class BannerDetailsQuery : EntityCommand<string>, IRequest<BannerDetailsOutputModel>
{
    public string MaterialId { get; set; } = default;

    public class BannerDetailsQueryHandler(IBannerQueryRepository bannerRepository)
        : IRequestHandler<BannerDetailsQuery, BannerDetailsOutputModel>
    {
        public async Task<BannerDetailsOutputModel> Handle(
            BannerDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var bannerDetails = await bannerRepository.GetDetailsByMaterialId(
                request.MaterialId,
                cancellationToken);

            if (bannerDetails == null)
            {
                return null;
            }

            bannerDetails.Keywords = await bannerRepository.GetKeywords(bannerDetails.Id, cancellationToken);

            return bannerDetails;
        }
    }
}
