namespace Umeliko.Application.Learning.Courses.Commands.Create;

using Common;
using Domain.Learning.Factories.Materials;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using MediatR;

public class CreateCourseCommand : CourseCommand<CreateCourseCommand>, IRequest<CreateCourseOutputModel>
{
    public class CreateCourseCommandHandler(
            IMaterialDomainRepository materialRepository,
            ICourseDomainRepository courseRepository,
            ICourseFactory courseFactory)
        : IRequestHandler<CreateCourseCommand, CreateCourseOutputModel>
    {
        public async Task<CreateCourseOutputModel> Handle(
            CreateCourseCommand request,
            CancellationToken cancellationToken)
        {
            var material = await materialRepository.Find(
                request.MaterialId,
                cancellationToken);

            if (material == null)
            {
                return null;
            }

            if (!material.ContentType.Equals(ContentType.Course))
            {
                return null;
            }

            var course = courseFactory
                .WithContent(request.Content)
                .WithMaterialId(material.Id)
                .Build();

            await courseRepository.Save(course, cancellationToken);

            return new CreateCourseOutputModel(course.Id);
        }
    }
}
