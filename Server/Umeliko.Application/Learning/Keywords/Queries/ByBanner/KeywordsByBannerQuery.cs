namespace Umeliko.Application.Learning.Keywords.Queries.ByBanner;

using Common;
using Domain.Learning.Repositories;
using MediatR;

public class KeywordsByBannerQuery : KeywordsQuery, IRequest<KeywordsByBannerOutputModel>
{
    public string MaterialId { get; set; } = default!;

    public class KeywordsByBannerQueryHandler(
            IKeywordQueryRepository keywordRepository,
            IBannerDomainRepository bannerRepository)
        : KeywordsQueryHandler(keywordRepository), IRequestHandler<
            KeywordsByBannerQuery,
            KeywordsByBannerOutputModel>
    {
        public async Task<KeywordsByBannerOutputModel> Handle(
            KeywordsByBannerQuery request,
            CancellationToken cancellationToken)
        {
            var banner = bannerRepository.FindByMaterialId(request.MaterialId);

            if (banner.Result == null)
            {
                return null;
            }

            var keywordListings = await GetKeywordListings<KeywordOutputModel>(
                request,
                banner.Result.Id,
                cancellationToken);

            return new KeywordsByBannerOutputModel(keywordListings);
        }
    }
}
