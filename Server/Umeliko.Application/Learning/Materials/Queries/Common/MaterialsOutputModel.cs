namespace Umeliko.Application.Learning.Materials.Queries.Common;

public abstract class MaterialsOutputModel<TMaterialOutputModel>
{
    internal MaterialsOutputModel(
        IEnumerable<TMaterialOutputModel> materials,
        int page,
        int totalPages)
    {
        Materials = materials;
        Page = page;
        TotalPages = totalPages;
    }

    public IEnumerable<TMaterialOutputModel> Materials { get; set; }

    public int Page { get; }

    public int TotalPages { get; }
}
