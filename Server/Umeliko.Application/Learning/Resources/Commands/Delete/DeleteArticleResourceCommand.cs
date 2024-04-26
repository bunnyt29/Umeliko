namespace Umeliko.Application.Learning.Resources.Commands.Delete;

using Common;
using Domain.Learning.Repositories;
using MediatR;

public class DeleteArticleResourceCommand : EntityCommand<int>, IRequest<Result>
{
    public string ArticleId { get; set; } = default!;

    public class DeleteArticleResourceCommandHandler(
            IResourceDomainRepository resourceRepository,
            IArticleDomainRepository articleRepository)
        : IRequestHandler<DeleteArticleResourceCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteArticleResourceCommand request,
            CancellationToken cancellationToken)
        {
            var articleHasResource = await articleRepository.ArticleHasResource(
                request.ArticleId,
                request.Id,
                cancellationToken);

            if (!articleHasResource)
            {
                return articleHasResource;
            }

            return await resourceRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
