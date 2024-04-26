namespace Umeliko.Application.Learning.Lessons.Commands.Create;

using Domain.Learning.Models.Materials;
using MediatR;
using System.Threading.Tasks;
using Umeliko.Application.Learning.Lessons.Commands.Common;
using Umeliko.Domain.Learning.Factories.Materials;
using Umeliko.Domain.Learning.Repositories;

public class CreateCourseLessonCommand : LessonCommand<CreateLessonCommand>, IRequest<CreateLessonOutputModel>
{
    public class CreateCourseLessonCommandHandler(
            IItemDomainRepository itemRepository,
            ILessonDomainRepository lessonRepository,
            ILessonFactory lessonFactory)
        : IRequestHandler<CreateCourseLessonCommand, CreateLessonOutputModel>
    {
        public async Task<CreateLessonOutputModel> Handle(
            CreateCourseLessonCommand request,
            CancellationToken cancellationToken)
        {
            var item = await itemRepository.Find(
                request.ItemId,
                cancellationToken);

            if (item == null)
            {
                return null;
            }

            if (!item.CourseContentType.Equals(CourseContentType.Lesson))
            {
                return null;
            }

            var lesson = lessonFactory
                .WithContent(request.Content)
                .WithFileUrl(request.FileUrl)
                .WithItemId(request.ItemId)
                .Build();

            await lessonRepository.Save(lesson, cancellationToken);

            return new CreateLessonOutputModel(lesson.Id);
        }
    }
}
