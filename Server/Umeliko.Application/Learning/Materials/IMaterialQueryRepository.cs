namespace Umeliko.Application.Learning.Materials;

using Application.Learning.Materials.Queries.Common;
using Common.Contracts;
using Domain.Common;
using Domain.Learning.Models.Creators;
using Domain.Learning.Models.Materials;
using Queries.Details;

public interface IMaterialQueryRepository : IQueryRepository<Material>
{
    Task<IEnumerable<TOutputModel>> GetMaterialListings<TOutputModel>(
        Specification<Material> materialSpecification,
        Specification<Material> materialByBannerSpecification,
        Specification<Creator> creatorSpecification,
        MaterialsSortOrder materialsSortOrder,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);

    Task<MaterialDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<Material> materialSpecification,
        Specification<Material> materialByBannerSpecification,
        Specification<Creator> creatorSpecification,
        CancellationToken cancellationToken = default);
}
