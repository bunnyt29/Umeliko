namespace Umeliko.Application.Learning.Courses.Queries.Details;

using MediatR;
using System.Threading.Tasks;
using Umeliko.Application.Common;

public class CourseDetailsQuery : EntityCommand<string>, IRequest<CourseDetailsOutputModel>
{
    public string MaterialId { get; set; } = default!;

    public class CourseDetailsQueryHandler(ICourseQueryRepository courseRepository)
        : IRequestHandler<CourseDetailsQuery, CourseDetailsOutputModel>
    {
        public async Task<CourseDetailsOutputModel> Handle(
            CourseDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var courseDetails = await courseRepository.GetDetailsByMaterialId(
                request.MaterialId,
                cancellationToken);

            if (courseDetails == null)
            {
                return null;
            }

            courseDetails.Resources = await courseRepository.GetResources(courseDetails.Id, cancellationToken);

            return courseDetails;
        }
    }
}
