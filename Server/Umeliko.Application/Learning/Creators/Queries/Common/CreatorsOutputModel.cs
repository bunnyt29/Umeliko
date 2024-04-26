namespace Umeliko.Application.Learning.Creators.Queries.Common;

public abstract class CreatorsOutputModel<TCreatorOutputModel>
{
    internal CreatorsOutputModel(IEnumerable<TCreatorOutputModel> creators)
    {
        Creators = creators;
    }

    public IEnumerable<TCreatorOutputModel> Creators { get; set; }
}
