namespace Umeliko.Application.Learning.Articles;

using Common.Contracts;
using Domain.Learning.Models.Materials;
using Queries.Details;
using Umeliko.Application.Learning.Resources.Queries.Common;

public interface IArticleQueryRepository : IQueryRepository<Article>
{
    Task<ArticleDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default);

    Task<ArticleDetailsOutputModel> GetDetailsByMaterialId(string materialId, CancellationToken cancellationToken = default);

    Task<IEnumerable<ResourceOutputModel>> GetResources(string articleId, CancellationToken cancellationToken = default);
}
