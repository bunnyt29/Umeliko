namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Materials;

public interface IArticleDomainRepository : IDomainRepository<Article>
{
    Task<Article> Find(string id, CancellationToken cancellationToken = default);

    Task<bool> Delete(string id, CancellationToken cancellationToken = default);

    Task<bool> ArticleHasResource(string articleId, int resourceId, CancellationToken cancellationToken = default);
}
