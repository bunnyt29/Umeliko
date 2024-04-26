namespace Umeliko.Infrastructure.Rating.Repositories;

using Application.Rating.Comments;
using Application.Rating.Comments.Queries.Common;
using AutoMapper;
using Common.Persistence;
using Domain.Rating.Models.Comments;
using Domain.Rating.Repositories;
using Microsoft.EntityFrameworkCore;

internal class CommentRepository(IRatingDbContext db, IMapper mapper)
    : DataRepository<IRatingDbContext, Comment>(db),
        ICommentDomainRepository,
        ICommentQueryRepository
{
    public async Task<Comment> Find(int id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var comment = await this.Find(id);

        if (comment == null)
        {
            return false;
        }

        this.Data.Comments.Remove(comment);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IEnumerable<CommentOutputModel>> GetAll(string materialId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<CommentOutputModel>(this
                .Data
                .Comments
                .Where(c => c.MaterialId == materialId))
            .ToListAsync(cancellationToken);
}
