namespace Umeliko.Domain.Learning.Repositories;

using Models.Materials;
using Umeliko.Domain.Common;

public interface IItemDomainRepository : IDomainRepository<Item>
{
    Task<Item> Find(int id, CancellationToken cancellationToken = default);

    Task<bool> Delete(int id, CancellationToken cancellationToken = default);

    Task<bool> HasArticle(int itemId, string articleId, CancellationToken cancellationToken = default);

    Task<bool> HasLesson(int itemId, string lessonId, CancellationToken cancellationToken = default);
}
