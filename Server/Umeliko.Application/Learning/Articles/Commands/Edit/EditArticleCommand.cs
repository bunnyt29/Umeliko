namespace Umeliko.Application.Learning.Articles.Commands.Edit;

using Application.Common;
using Application.Common.Contracts;
using Courses.Commands.Common;
using Domain.Learning.Repositories;
using Materials.Commands.Common;
using MediatR;

public class EditArticleCommand : CourseCommand<EditArticleCommand>, IRequest<Result>
{
    public class EditArticleCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IArticleDomainRepository articleRepository,
            IMaterialDomainRepository materialRepository)
        : IRequestHandler<EditArticleCommand, Result>
    {
        public async Task<Result> Handle(
            EditArticleCommand request,
            CancellationToken cancellationToken)
        {
            var creatorHasMaterial = await currentUser.CreatorHasMaterial(
                creatorRepository,
                request.MaterialId,
                cancellationToken);

            if (!creatorHasMaterial)
            {
                return creatorHasMaterial;
            }

            var materialHasArticle = await materialRepository.HasArticle(
                request.MaterialId,
                request.Id,
                cancellationToken);

            if (!materialHasArticle)
            {
                return materialHasArticle;
            }

            var article = await articleRepository
                .Find(request.Id, cancellationToken);

            article
                .UpdateContent(request.Content);

            await articleRepository.Update(article, cancellationToken);

            return Result.Success;
        }
    }
}
