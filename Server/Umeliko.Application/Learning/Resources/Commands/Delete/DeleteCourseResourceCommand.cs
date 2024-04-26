namespace Umeliko.Application.Learning.Resources.Commands.Delete;

using Common;
using Domain.Learning.Repositories;
using MediatR;

public class DeleteCourseResourceCommand : EntityCommand<int>, IRequest<Result>
{
    public string CourseId { get; set; } = default!;

    public class DeleteCourseResourceCommandHandler(
            IResourceDomainRepository resourceRepository,
            ICourseDomainRepository courseRepository)
        : IRequestHandler<DeleteCourseResourceCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteCourseResourceCommand request,
            CancellationToken cancellationToken)
        {
            var courseHasResource = await courseRepository.CourseHasResource(
                request.CourseId,
                request.Id,
                cancellationToken);

            if (!courseHasResource)
            {
                return courseHasResource;
            }

            return await resourceRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
