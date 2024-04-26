namespace Umeliko.Application.Learning.Lessons.Commands.Edit;

using Application.Common;
using Application.Common.Contracts;
using Common;
using Domain.Learning.Repositories;
using Materials.Commands.Common;
using MediatR;

public class EditLessonCommand : LessonCommand<EditLessonCommand>, IRequest<Result>
{
    public class EditLessonCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            ILessonDomainRepository lessonRepository,
            IMaterialDomainRepository materialRepository)
        : IRequestHandler<EditLessonCommand, Result>
    {
        public async Task<Result> Handle(
            EditLessonCommand request,
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

            var lesson = await lessonRepository
                .Find(request.Id, cancellationToken);

            lesson
                .UpdateContent(request.Content)
                .UpdateFileUrl(request.FileUrl);

            await lessonRepository.Update(lesson, cancellationToken);

            return Result.Success;
        }
    }
}
