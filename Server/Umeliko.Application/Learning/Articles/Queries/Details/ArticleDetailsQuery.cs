namespace Umeliko.Application.Learning.Articles.Queries.Details;

using Application.Common;
using MediatR;

public class ArticleDetailsQuery : EntityCommand<string>, IRequest<ArticleDetailsOutputModel>
{
    public string MaterialId { get; set; } = default!;

    public class ArticleDetailsQueryHandler(IArticleQueryRepository articleRepository)
        : IRequestHandler<ArticleDetailsQuery, ArticleDetailsOutputModel>
    {
        public async Task<ArticleDetailsOutputModel> Handle(
            ArticleDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var articleDetails = await articleRepository.GetDetailsByMaterialId(
                request.MaterialId,
                cancellationToken);

            if (articleDetails == null)
            {
                return null;
            }

            articleDetails.Resources = await articleRepository.GetResources(articleDetails.Id, cancellationToken);

            return articleDetails;
        }
    }
}
