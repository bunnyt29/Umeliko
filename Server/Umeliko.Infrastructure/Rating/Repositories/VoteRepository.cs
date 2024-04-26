namespace Umeliko.Infrastructure.Rating.Repositories;

using Application.Rating.Votes;
using AutoMapper;
using Common.Persistence;
using Domain.Rating.Models.Votes;
using Domain.Rating.Repositories;
using Microsoft.EntityFrameworkCore;
using Umeliko.Application.Rating.Votes.Queries.Common;

internal class VoteRepository(IRatingDbContext db, IMapper mapper)
    : DataRepository<IRatingDbContext, Vote>(db),
        IVoteDomainRepository,
        IVoteQueryRepository
{
    public async Task<Vote> Find(int id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var vote = await this.Find(id);

        if (vote == null)
        {
            return false;
        }

        this.Data.Votes.Remove(vote);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<VoteOutputModel> GetDetails(string creatorId, string materialId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<VoteOutputModel>(this
                .All()
                .Where(v => v.CreatorId == creatorId && v.MaterialId == materialId))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<VoteOutputModel>> GetAll(string materialId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<VoteOutputModel>(this
                .Data
                .Votes
                .Where(k => k.MaterialId == materialId))
            .ToListAsync(cancellationToken);
}
