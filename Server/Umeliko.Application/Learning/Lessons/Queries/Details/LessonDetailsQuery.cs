namespace Umeliko.Application.Learning.Lessons.Queries.Details;

using Application.Common;
using MediatR;

public class LessonDetailsQuery : EntityCommand<string>, IRequest<LessonDetailsOutputModel>
{
    public string MaterialId { get; set; } = default!;

    public class LessonDetailsQueryHandler(ILessonQueryRepository lessonRepository)
        : IRequestHandler<LessonDetailsQuery, LessonDetailsOutputModel>
    {
        public async Task<LessonDetailsOutputModel> Handle(
            LessonDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var lessonDetails = await lessonRepository.GetDetailsByMaterialId(
                    request.MaterialId,
                    cancellationToken);

            if (lessonDetails == null)
            {
                return null;
            }

            lessonDetails.Resources = await lessonRepository.GetResources(lessonDetails.Id, cancellationToken);

            return lessonDetails;
        }
    }
}
