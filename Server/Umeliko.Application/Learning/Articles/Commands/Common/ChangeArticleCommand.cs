namespace Umeliko.Application.Learning.Articles.Commands.Common;

using Application.Common;
using Domain.Learning.Repositories;

internal static class ChangeArticleCommandExtensions
{
    public static async Task<Result> MaterialHasArticle(
        string materialId,
        IMaterialDomainRepository materialRepository,
        string articleId,
        CancellationToken cancellationToken)
    {
        var materialHasArticle = await materialRepository.HasArticle(
            materialId,
            articleId,
            cancellationToken);

        return materialHasArticle
            ? Result.Success
            : "You cannot edit this article.";
    }
}
