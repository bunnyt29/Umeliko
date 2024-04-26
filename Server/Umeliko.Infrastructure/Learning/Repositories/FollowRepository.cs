namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Follows;
using Application.Learning.Follows.Queries;
using AutoMapper;
using Common.Persistence;
using Domain.Learning.Models.Creators;
using Domain.Learning.Repositories;
using Microsoft.EntityFrameworkCore;

internal class FollowRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Follow>(db),
        IFollowDomainRepository, IFollowQueryRepository
{
    public Task<bool> IsAlreadyFollowed(
        string creatorId,
        string followerId,
        CancellationToken cancellationToken = default)
        => this
            .Data.Follows
            .AnyAsync(f => f.CreatorId == creatorId && f.FollowerId == followerId, cancellationToken);

    public async Task<Follow> Find(string creatorId, string followerId, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(f => f.CreatorId == creatorId && f.FollowerId == followerId, cancellationToken);

    public async Task<IList<FollowOutputModel>> GetFollowing(string id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<FollowOutputModel>(this
                .Data
                .Follows
                .Where(f => f.FollowerId == id))
            .ToListAsync(cancellationToken);

    public async Task<IList<FollowOutputModel>> GetFollowers(string id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<FollowOutputModel>(this
                .Data
                .Follows
                .Where(f => f.CreatorId == id))
            .ToListAsync(cancellationToken);

    public async Task<bool> Delete(string creatorId, string followerId, CancellationToken cancellationToken = default)
    {
        var follow = await this.Find(creatorId, followerId);

        if (follow == null)
        {
            return false;
        }

        this.Data.Follows.Remove(follow);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }
}
