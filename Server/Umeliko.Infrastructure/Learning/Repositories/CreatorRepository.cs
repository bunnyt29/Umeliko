namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Creators;
using Application.Learning.Creators.Queries.Common;
using Application.Learning.Creators.Queries.Details;
using AutoMapper;
using Common.Persistence;
using Domain.Learning.Exceptions;
using Domain.Learning.Models.Creators;
using Domain.Learning.Repositories;
using Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

internal class CreatorRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Creator>(db),
    ICreatorDomainRepository,
    ICreatorQueryRepository
{
    public async Task<bool> HasCategory(
        string creatorId,
        string categoryId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(c => c.Id == creatorId)
            .AnyAsync(c => c.Categories
                .Any(ca => ca.Id == categoryId), cancellationToken);

    public async Task<bool> HasMaterial(
        string creatorId,
        string materialId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(c => c.Id == creatorId)
            .AnyAsync(c => c.Materials
                .Any(m => m.Id == materialId), cancellationToken);

    public async Task<bool> HasVote(
        string creatorId,
        int voteId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(c => c.Id == creatorId)
            .AnyAsync(c => c.Votes
                .Any(v => v.Id == voteId), cancellationToken);

    public async Task<bool> HasComment(
        string creatorId,
        int commentId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(c => c.Id == creatorId)
            .AnyAsync(c => c.Comments
                .Any(co => co.Id == commentId), cancellationToken);

    public async Task<bool> HasFollow(
        string creatorId,
        string followId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(c => c.Id == creatorId)
            .AnyAsync(c => c.Following
                .Any(f => f.Id == followId), cancellationToken);

    public async Task<CreatorOutputModel> Get(string id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<CreatorOutputModel>(this
                .All()
                .Where(c => c.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<CreatorDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<CreatorDetailsOutputModel>(this
                .All()
                .Where(c => c.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<CreatorOutputModel> GetDetailsByCategoryId(string categoryId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<CreatorOutputModel>(this
                .All()
                .Where(l => l.Categories.Any(c => c.Id == categoryId)))
            .SingleOrDefaultAsync(cancellationToken);

    public async Task<CreatorDetailsOutputModel> GetDetailsByMaterialId(string materialId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<CreatorDetailsOutputModel>(this
                .All()
                .Where(c => c.Materials.Any(m => m.Id == materialId)))
            .SingleOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<TOutputModel>> GetCreatorListings<TOutputModel>(
        string currentCreatorId,
        CancellationToken cancellationToken = default)
        => (await mapper
            .ProjectTo<TOutputModel>(
                this
                    .All()
                    .Where(c => c.Id != currentCreatorId)
                    .Take(5))
            .ToListAsync(cancellationToken));

    public async Task<string> GetEmail(string id, CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Creator!.Id == id)
            .Select(u => u.Email)
            .FirstOrDefaultAsync();

    public async Task<string> GetUserName(string id, CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Creator!.Id == id)
            .Select(u => u.UserName)
            .FirstOrDefaultAsync();

    public Task<string> GetCreatorId(
        string userId,
        CancellationToken cancellationToken = default)
        => this.FindByUser(userId, user => user.Creator!.Id, cancellationToken);

    public async Task<Creator> FindById(string id, CancellationToken cancellationToken = default)
        => await this
            .Data
            .Creators
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<Creator> FindByUser(
        string userId,
        CancellationToken cancellationToken = default)
        => this.FindByUser(userId, user => user.Creator!, cancellationToken);

    private async Task<T> FindByUser<T>(
        string userId,
        Expression<Func<User, T>> selector,
        CancellationToken cancellationToken = default)
    {
        var creatorData = await this
            .Data
            .Users
            .Where(u => u.Id == userId)
            .Select(selector)
            .FirstOrDefaultAsync(cancellationToken);

        if (creatorData == null)
        {
            throw new InvalidCreatorException("This user is not a creator.");
        }

        return creatorData;
    }
}
