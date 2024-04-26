namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Materials;

public interface IBannerDomainRepository : IDomainRepository<Banner>
{
    Task<Banner> Find(string id, CancellationToken cancellationToken = default);

    Task<Banner> FindByMaterialId(string materialId, CancellationToken cancellationToken = default);

    Task<bool> Delete(string id, CancellationToken cancellationToken = default);

    Task<bool> BannerHasKeyword(string bannerId, int keywordId, CancellationToken cancellationToken = default);
}
