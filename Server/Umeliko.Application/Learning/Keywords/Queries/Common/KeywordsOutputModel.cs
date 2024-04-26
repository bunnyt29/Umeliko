namespace Umeliko.Application.Learning.Keywords.Queries.Common;

public abstract class KeywordsOutputModel<TKeywordOutputModel>
{
    internal KeywordsOutputModel(IEnumerable<TKeywordOutputModel> keywords)
    {
        Keywords = keywords;
    }

    public IEnumerable<TKeywordOutputModel> Keywords { get; set; }
}
