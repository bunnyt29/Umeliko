namespace Umeliko.Application.Learning.Resources.Commands.Delete;

using Common;
using Domain.Learning.Repositories;
using MediatR;

public class DeleteLessonResourceCommand : EntityCommand<int>, IRequest<Result>
{
    public string LessonId { get; set; } = default!;

    public class DeleteResourceCommandHandler(
            IResourceDomainRepository resourceRepository,
            ILessonDomainRepository lessonRepository)
        : IRequestHandler<DeleteLessonResourceCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteLessonResourceCommand request,
            CancellationToken cancellationToken)
        {
            var lessonHasResource = await lessonRepository.LessonHasResource(
                request.LessonId,
                request.Id,
                cancellationToken);

            if (!lessonHasResource)
            {
                return lessonHasResource;
            }

            return await resourceRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
