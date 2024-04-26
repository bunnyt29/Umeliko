namespace Umeliko.Application.Learning.Keywords.Queries.ByBanner;

using Common;

public class KeywordsByBannerOutputModel : KeywordsOutputModel<KeywordOutputModel>
{
    public KeywordsByBannerOutputModel(IEnumerable<KeywordOutputModel> keywords)
        : base(keywords)
    {
    }
}
