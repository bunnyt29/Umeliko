namespace Umeliko.Domain.Learning.Factories.Materials;

using Common;
using Models.Materials;

public interface IArticleFactory : IFactory<Article>
{
    IArticleFactory WithContent(string content);

    IArticleFactory WithMaterialId(string materialId);
}
