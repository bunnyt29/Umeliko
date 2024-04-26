namespace Umeliko.Application.Learning.Materials.Queries.Mine;

using Application.Common.Contracts;
using Common;
using Domain.Learning.Repositories;
using MediatR;

public class MineMaterialsQuery : MaterialsQuery, IRequest<MineMaterialsOutputModel>
{
    public class MineMaterialsQueryHandler(
            IMaterialQueryRepository materialRepository,
            ICreatorDomainRepository creatorRepository,
            ICurrentUser currentUser)
        : MaterialsQueryHandler(materialRepository), IRequestHandler<
            MineMaterialsQuery,
            MineMaterialsOutputModel>
    {
        public async Task<MineMaterialsOutputModel> Handle(
            MineMaterialsQuery request,
            CancellationToken cancellationToken)
        {
            var creatorId = await creatorRepository.GetCreatorId(
                currentUser.UserId,
                cancellationToken);

            var mineMaterialListings = await GetMaterialListings<MineMaterialOutputModel>(
                request,
                onlyPublic: false,
                creatorId,
                cancellationToken);

            var totalPages = await GetTotalPages(
                request,
                onlyPublic: false,
                creatorId,
                cancellationToken);

            return new MineMaterialsOutputModel(
                mineMaterialListings,
                request.Page,
                totalPages);
        }
    }
}
