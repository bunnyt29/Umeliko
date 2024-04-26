namespace Umeliko.Application.Learning.Lessons.Commands.Create;

using Common;
using Domain.Learning.Factories.Materials;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using MediatR;

public class CreateLessonCommand : LessonCommand<CreateLessonCommand>, IRequest<CreateLessonOutputModel>
{
    public class CreateLessonCommandHandler(
            IMaterialDomainRepository materialRepository,
            ILessonDomainRepository lessonRepository,
            ILessonFactory lessonFactory)
        : IRequestHandler<CreateLessonCommand, CreateLessonOutputModel>
    {
        public async Task<CreateLessonOutputModel> Handle(
            CreateLessonCommand request,
            CancellationToken cancellationToken)
        {
            var material = await materialRepository.Find(
                request.MaterialId,
                cancellationToken);

            if (material == null)
            {
                return null;
            }

            if (!material.ContentType.Equals(ContentType.Lesson))
            {
                return null;
            }

            var lesson = lessonFactory
                .WithContent(request.Content)
                .WithFileUrl(request.FileUrl)
                .WithMaterialId(material.Id)
                .Build();

            await lessonRepository.Save(lesson, cancellationToken);

            return new CreateLessonOutputModel(lesson.Id);
        }
    }
}
