namespace Umeliko.Application.Learning.Lessons.Commands.Delete;

using Application.Common;
using Application.Common.Contracts;
using Domain.Learning.Repositories;
using Materials.Commands.Common;
using MediatR;

public class DeleteLessonCommand : EntityCommand<string>, IRequest<Result>
{
    public string MaterialId { get; set; }

    public class DeleteLessonCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            ILessonDomainRepository lessonRepository,
            IMaterialDomainRepository materialRepository)
        : IRequestHandler<DeleteLessonCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteLessonCommand request,
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

            var materialHasLesson = await materialRepository.HasLesson(
                request.MaterialId,
                request.Id,
                cancellationToken);

            if (!materialHasLesson)
            {
                return materialHasLesson;
            }

            return await lessonRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
