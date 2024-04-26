namespace Umeliko.Application.Learning.Creators.Queries.Popular;

using Common;

public class PopularCreatorsOutputModel : CreatorsOutputModel<CreatorOutputModel>
{
    public PopularCreatorsOutputModel(
        IEnumerable<CreatorOutputModel> materials)
        : base(materials)
    {
    }
}
