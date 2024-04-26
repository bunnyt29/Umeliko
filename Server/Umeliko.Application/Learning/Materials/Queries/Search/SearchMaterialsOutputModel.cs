namespace Umeliko.Application.Learning.Materials.Queries.Search;

using Common;

public class SearchMaterialsOutputModel : MaterialsOutputModel<MaterialOutputModel>
{
    public SearchMaterialsOutputModel(
        IEnumerable<MaterialOutputModel> materials,
        int page,
        int totalPages)
        : base(materials, page, totalPages)
    {
    }
}
