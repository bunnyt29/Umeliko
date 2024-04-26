namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Materials;

public interface IMaterialDomainRepository : IDomainRepository<Material>
{
    Task<Material> Find(string id, CancellationToken cancellationToken = default);

    Task<bool> Delete(string id, CancellationToken cancellationToken = default);

    Task<bool> HasBanner(string materialId, string bannerId, CancellationToken cancellationToken = default);

    Task<bool> HasArticle(string materialId, string articleId, CancellationToken cancellationToken = default);

    Task<bool> HasLesson(string materialId, string lessonId, CancellationToken cancellationToken = default);

    Task<bool> HasVote(string materialId, int voteId, CancellationToken cancellationToken = default);

    Task<bool> HasComment(string materialId, int commentId, CancellationToken cancellationToken = default);
}
