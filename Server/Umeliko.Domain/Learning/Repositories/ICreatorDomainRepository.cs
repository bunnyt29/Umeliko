namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Creators;

public interface ICreatorDomainRepository : IDomainRepository<Creator>
{
    Task<Creator> FindByUser(string userId, CancellationToken cancellationToken = default);

    Task<Creator> FindById(string id, CancellationToken cancellationToken = default);

    Task<string> GetCreatorId(string userId, CancellationToken cancellationToken = default);

    Task<bool> HasCategory(string creatorId, string categoryId, CancellationToken cancellationToken = default);

    Task<bool> HasMaterial(string creatorId, string materialId, CancellationToken cancellationToken = default);

    Task<bool> HasVote(string creatorId, int voteId, CancellationToken cancellationToken = default);

    Task<bool> HasFollow(string creatorId, string followId, CancellationToken cancellationToken = default);

}
