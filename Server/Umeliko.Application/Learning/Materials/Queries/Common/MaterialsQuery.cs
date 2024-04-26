namespace Umeliko.Application.Learning.Materials.Queries.Common;

using Domain.Common;
using Domain.Learning.Models.Creators;
using Domain.Learning.Models.Materials;
using Domain.Learning.Specifications.Creators;
using Domain.Learning.Specifications.Materials;

public abstract class MaterialsQuery
{
    private const int MaterialsPerPage = 10;

    public int? StateType { get; set; }

    public string? Title { get; set; }

    public string? Category { get; set; }

    public string? KeywordName { get; set; }

    public string? CreatorFullName { get; set; }

    public string? SortBy { get; set; }

    public string? Order { get; set; }

    public int Page { get; set; } = 1;

    public abstract class MaterialsQueryHandler(IMaterialQueryRepository materialRepository)
    {
        protected async Task<IEnumerable<TOutputModel>> GetMaterialListings<TOutputModel>(
            MaterialsQuery request,
            bool onlyPublic = true,
            string? creatorId = default,
            CancellationToken cancellationToken = default)
        {
            var materialSpecification = request.StateType == 2
                ? GetMaterialSpecification(request, onlyPublic: false)
                : GetMaterialSpecification(request, onlyPublic);

            var materialByBannerSpecification = GetMaterialByBannerSpecification(request);

            var creatorSpecification = GetCreatorSpecification(request, creatorId);

            var searchOrder = new MaterialsSortOrder(request.SortBy, request.Order);

            var skip = (request.Page - 1) * MaterialsPerPage;

            return await materialRepository.GetMaterialListings<TOutputModel>(
                materialSpecification,
                materialByBannerSpecification,
                creatorSpecification,
                searchOrder,
                skip,
                take: MaterialsPerPage,
                cancellationToken);
        }

        protected async Task<int> GetTotalPages(
            MaterialsQuery request,
            bool onlyPublic = true,
            string? creatorId = default,
            CancellationToken cancellationToken = default)
        {
            var materialSpecification = request.StateType == 2
                ? GetMaterialSpecification(request, onlyPublic: false)
                : GetMaterialSpecification(request, onlyPublic);

            var materialByBannerSpecification = GetMaterialByBannerSpecification(request);

            var creatorSpecification = GetCreatorSpecification(request, creatorId);

            var totalMaterials = await materialRepository.Total(
                materialSpecification,
                materialByBannerSpecification,
                creatorSpecification,
                cancellationToken);

            return (int)Math.Ceiling((double)totalMaterials / MaterialsPerPage);
        }

        private Specification<Material> GetMaterialSpecification(MaterialsQuery request, bool onlyPublic)
            => new MaterialByBannerTitleSpecification(request.Title)
                .And(new MaterialByBannerCategorySpecification(request.Category))
                .And(new MaterialByStateTypeSpecification(request.StateType))
                .And(new MaterialOnlyPublicSpecification(onlyPublic));

        private Specification<Material> GetMaterialByBannerSpecification(MaterialsQuery request)
            => new MaterialByBannerKeywordSpecification(request.KeywordName);

        private Specification<Creator> GetCreatorSpecification(MaterialsQuery request, string? creatorId)
            => new CreatorByIdSpecification(creatorId)
                .And(new CreatorByFullNameSpecification(request.CreatorFullName));
    }
}
