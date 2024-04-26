namespace Umeliko.Application.Learning.Materials.Queries.Search;

using Common;
using MediatR;

public class SearchMaterialsQuery : MaterialsQuery, IRequest<SearchMaterialsOutputModel>
{
    public class SearchMaterialsQueryHandler(IMaterialQueryRepository materialRepository)
        : MaterialsQueryHandler(materialRepository), IRequestHandler<
            SearchMaterialsQuery,
            SearchMaterialsOutputModel>
    {
        public async Task<SearchMaterialsOutputModel> Handle(
            SearchMaterialsQuery request,
            CancellationToken cancellationToken)
        {
            var materialListings = await GetMaterialListings<MaterialOutputModel>(
                request,
                cancellationToken: cancellationToken);

            var totalPages = await GetTotalPages(
                request,
                cancellationToken: cancellationToken);

            return new SearchMaterialsOutputModel(materialListings, request.Page, totalPages);
        }
    }
}
