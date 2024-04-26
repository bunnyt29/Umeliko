namespace Umeliko.Application.Learning.Materials.Queries.ByCreator;

using Common;

public class MaterialsByCreatorOutputModel : MaterialsOutputModel<MaterialOutputModel>
{
    public MaterialsByCreatorOutputModel(
        IEnumerable<MaterialOutputModel> materials,
        int page,
        int totalPages)
        : base(materials, page, totalPages)
    {
    }
}
