namespace Umeliko.Application.Learning.Materials.Queries.Mine;

using Common;

public class MineMaterialsOutputModel : MaterialsOutputModel<MineMaterialOutputModel>
{
    public MineMaterialsOutputModel(
        IEnumerable<MineMaterialOutputModel> materials,
        int page,
        int totalPages)
        : base(materials, page, totalPages)
    {
    }
}
