namespace Umeliko.Application.Learning.Keywords;

using Common.Contracts;
using Domain.Learning.Models.Materials;
using Umeliko.Domain.Common;

public interface IKeywordQueryRepository : IQueryRepository<Keyword>
{
    Task<IEnumerable<TOutputModel>> GetKeywordListings<TOutputModel>(
        Specification<Banner> bannerSpecification,
        CancellationToken cancellationToken = default);
}
