namespace Umeliko.Application.Learning.Articles.Commands.Create;

using Common;
using Domain.Learning.Factories.Materials;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using MediatR;

public class CreateArticleCommand : ArticleCommand<CreateArticleCommand>, IRequest<CreateArticleOutputModel>
{
    public class CreateArticleCommandHandler(
            IMaterialDomainRepository materialRepository,
            IArticleDomainRepository articleRepository,
            IArticleFactory articleFactory)
        : IRequestHandler<CreateArticleCommand, CreateArticleOutputModel>
    {
        public async Task<CreateArticleOutputModel> Handle(
            CreateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var material = await materialRepository.Find(
                request.MaterialId,
                cancellationToken);

            if (material == null)
            {
                return null;
            }

            if (!material.ContentType.Equals(ContentType.Article))
            {
                return null;
            }

            var article = articleFactory
                .WithContent(request.Content)
                .WithMaterialId(material.Id)
                .Build();

            await articleRepository.Save(article, cancellationToken);

            return new CreateArticleOutputModel(article.Id);
        }
    }
}
