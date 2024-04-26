namespace Umeliko.Application.Learning.Articles.Commands.Delete;

using Application.Common;
using Application.Common.Contracts;
using Domain.Learning.Repositories;
using Materials.Commands.Common;
using MediatR;

public class DeleteArticleCommand : EntityCommand<string>, IRequest<Result>
{
    public string MaterialId { get; set; }

    public class DeleteArticleCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IArticleDomainRepository articleRepository,
            IMaterialDomainRepository materialRepository)
        : IRequestHandler<DeleteArticleCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteArticleCommand request,
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

            return await articleRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
