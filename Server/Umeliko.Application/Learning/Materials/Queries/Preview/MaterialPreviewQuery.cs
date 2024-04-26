namespace Umeliko.Application.Learning.Materials.Queries.Preview;

using Application.Common;
using Articles;
using Banners;
using Details;
using Lessons;
using MediatR;

public class MaterialPreviewQuery : EntityCommand<string>, IRequest<MaterialDetailsOutputModel>
{
    public class MaterialPreviewQueryHandler(
            IMaterialQueryRepository materialRepository,
            IBannerQueryRepository bannerRepository,
            IArticleQueryRepository articleRepository,
            ILessonQueryRepository lessonRepository)
        : IRequestHandler<MaterialPreviewQuery, MaterialDetailsOutputModel>
    {
        public async Task<MaterialDetailsOutputModel> Handle(
            MaterialPreviewQuery request,
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

            return materialDetails;
        }
    }
}
