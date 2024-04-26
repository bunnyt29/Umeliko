namespace Umeliko.Application.Learning.Creators;

using Common.Contracts;
using Domain.Learning.Models.Creators;
using Queries.Common;
using Queries.Details;

public interface ICreatorQueryRepository : IQueryRepository<Creator>
{
    Task<CreatorOutputModel> Get(string id, CancellationToken cancellationToken = default);

    Task<CreatorDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default);

    Task<string> GetUserName(string id, CancellationToken cancellationToken = default);

    Task<string> GetEmail(string id, CancellationToken cancellationToken = default);

    Task<CreatorDetailsOutputModel> GetDetailsByMaterialId(string materialId, CancellationToken cancellationToken = default);

    Task<IEnumerable<TOutputModel>> GetCreatorListings<TOutputModel>(string currentCreatorId, CancellationToken cancellationToken = default);
}
