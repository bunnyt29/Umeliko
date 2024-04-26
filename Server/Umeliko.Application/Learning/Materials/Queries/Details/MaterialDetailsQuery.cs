namespace Umeliko.Application.Learning.Materials.Queries.Details;

using Application.Common;
using Application.Common.Contracts;
using Articles;
using Banners;
using Creators;
using Domain.Learning.Repositories;
using Lessons;
using MediatR;
using Rating.Comments;
using Rating.Votes;

public class MaterialDetailsQuery : EntityCommand<string>, IRequest<MaterialDetailsOutputModel>
{
    public class MaterialDetailsQueryHandler(
            IMaterialQueryRepository materialRepository,
            ICreatorDomainRepository creatorDomainRepository,
            ICreatorQueryRepository creatorRepository,
            IBannerQueryRepository bannerRepository,
            IArticleQueryRepository articleRepository,
            ILessonQueryRepository lessonRepository,
            IVoteQueryRepository voteRepository,
            ICommentQueryRepository commentRepository,
            ICurrentUser currentUser)
        : IRequestHandler<MaterialDetailsQuery, MaterialDetailsOutputModel>
    {
        public async Task<MaterialDetailsOutputModel> Handle(
            MaterialDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var materialDetails = await materialRepository.GetDetails(
                request.Id,
                cancellationToken);

            if (materialDetails == null)
            {
                return null;
            }

            materialDetails.Banner = await bannerRepository.GetDetailsByMaterialId(
                request.Id,
                cancellationToken);

            switch (materialDetails.ContentType)
            {
                case "Article":
                    materialDetails.Article = await articleRepository.GetDetailsByMaterialId(
                        request.Id,
                        cancellationToken);
                    break;
                case "Lesson":
                    materialDetails.Lesson = await lessonRepository.GetDetailsByMaterialId(
                        request.Id,
                        cancellationToken);
                    break;
            };

            materialDetails.Creator = await creatorRepository.GetDetailsByMaterialId(
                request.Id,
                cancellationToken);

            materialDetails.Votes = await voteRepository.GetAll(request.Id, cancellationToken);
            materialDetails.Comments = await commentRepository.GetAll(request.Id, cancellationToken);

            return materialDetails;
        }
    }
}
