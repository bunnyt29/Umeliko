namespace Umeliko.Application.Learning.Articles.Commands.Create;

public class CreateArticleOutputModel(string articleId)
{
    public string ArticleId { get; } = articleId;
}
