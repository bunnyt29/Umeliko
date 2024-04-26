namespace Umeliko.Domain.Rating.Repositories;

using Common;
using Models.Comments;

public interface ICommentDomainRepository : IDomainRepository<Comment>
{
    Task<Comment> Find(int id, CancellationToken cancellationToken = default);

    Task<bool> Delete(int id, CancellationToken cancellationToken = default);
}
