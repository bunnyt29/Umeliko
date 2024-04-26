namespace Umeliko.Application.Learning.Sections.Commands.Create;

using Common;
using Domain.Learning.Models.Materials;
using MediatR;
using System.Threading.Tasks;
using Umeliko.Domain.Learning.Repositories;

public class CreateSectionCommand : SectionCommand<CreateSectionCommand>, IRequest<CreateSectionOutputModel>
{
    public class CreateSectionCommandHandler(
            ICourseDomainRepository courseRepository,
            ISectionDomainRepository sectionRepository)
        : IRequestHandler<CreateSectionCommand, CreateSectionOutputModel>
    {
        public async Task<CreateSectionOutputModel> Handle(
            CreateSectionCommand request,
            CancellationToken cancellationToken)
        {
            var course = await courseRepository.Find(
                request.CourseId,
                cancellationToken);

            if (course == null)
            {
                return null;
            }

            var section = new Section(request.Title, request.CourseId);

            course.AddSection(section);

            await sectionRepository.Save(section, cancellationToken);

            return new CreateSectionOutputModel(section.Id);
        }
    }
}
