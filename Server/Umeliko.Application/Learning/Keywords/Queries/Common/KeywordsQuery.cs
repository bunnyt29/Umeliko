namespace Umeliko.Application.Learning.Keywords.Queries.Common;

using Domain.Common;
using Domain.Learning.Models.Materials;
using Domain.Learning.Specifications.Materials;

public abstract class KeywordsQuery
{
    public abstract class KeywordsQueryHandler(IKeywordQueryRepository keywordRepository)
    {
        protected async Task<IEnumerable<TOutputModel>> GetKeywordListings<TOutputModel>(
            KeywordsQuery request,
            string? bannerId = default,
            CancellationToken cancellationToken = default)
        {
            var bannerSpecification = GetBannerSpecification(request, bannerId);

            return await keywordRepository.GetKeywordListings<TOutputModel>(
                bannerSpecification,
                cancellationToken);
        }

        private Specification<Banner> GetBannerSpecification(KeywordsQuery request, string? bannerId)
            => new BannerByIdSpecification(bannerId);
    }
}
