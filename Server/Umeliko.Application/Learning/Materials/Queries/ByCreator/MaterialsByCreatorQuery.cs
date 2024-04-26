namespace Umeliko.Application.Learning.Materials.Queries.ByCreator;

using Common;
using MediatR;

public class MaterialsByCreatorQuery : MaterialsQuery, IRequest<MaterialsByCreatorOutputModel>
{
    public string Id { get; set; } = default!;

    public class MaterialsByCreatorQueryHandler(IMaterialQueryRepository materialRepository)
        : MaterialsQueryHandler(materialRepository), IRequestHandler<
        MaterialsByCreatorQuery,
        MaterialsByCreatorOutputModel>
    {
        public async Task<MaterialsByCreatorOutputModel> Handle(
            MaterialsByCreatorQuery request,
            CancellationToken cancellationToken)
        {
            var materialListings = await GetMaterialListings<MaterialByCreatorOutputModel>(
                request,
                onlyPublic: true,
                request.Id,
                cancellationToken);

            var totalPages = await GetTotalPages(
                request,
                onlyPublic: true,
                request.Id,
                cancellationToken);

            return new MaterialsByCreatorOutputModel(materialListings, request.Page, totalPages);
        }
    }
}
