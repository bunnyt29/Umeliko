namespace Umeliko.Domain.Learning.Factories.Materials;

using Models.Materials;

internal class ArticleFactory : IArticleFactory
{
    private string articleContent = default!;
    private string articleMaterialId = default!;

    public IArticleFactory WithContent(string content)
    {
        this.articleContent = content;
        return this;
    }

    public IArticleFactory WithMaterialId(string materialId)
    {
        this.articleMaterialId = materialId;
        return this;
    }

    public Article Build()
        => new Article(this.articleContent, this.articleMaterialId);
}
