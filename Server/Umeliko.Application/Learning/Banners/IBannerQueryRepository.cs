namespace Umeliko.Application.Learning.Banners;

using Common.Contracts;
using Domain.Learning.Models.Materials;
using Keywords.Queries.Common;
using Queries.Details;

public interface IBannerQueryRepository : IQueryRepository<Banner>
{
    Task<BannerDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default);

    Task<BannerDetailsOutputModel> GetDetailsByMaterialId(string materialId, CancellationToken cancellationToken = default);

    Task<IEnumerable<KeywordOutputModel>> GetKeywords(string bannerId, CancellationToken cancellationToken = default);
}
