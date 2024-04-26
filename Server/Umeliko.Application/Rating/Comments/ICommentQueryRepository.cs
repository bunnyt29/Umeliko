namespace Umeliko.Application.Rating.Comments;

using Domain.Rating.Models.Comments;
using Queries.Common;
using Umeliko.Application.Common.Contracts;

public interface ICommentQueryRepository : IQueryRepository<Comment>
{
    Task<IEnumerable<CommentOutputModel>> GetAll(string materialId, CancellationToken cancellationToken = default);
}
