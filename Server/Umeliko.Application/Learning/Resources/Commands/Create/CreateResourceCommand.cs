namespace Umeliko.Application.Learning.Resources.Commands.Create;

using Common;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using MediatR;

public class CreateArticleResourceCommand
    : EntityCommand<int>, IRequest<CreateResourceOutputModel>
{
    public string FileUrl { get; set; } = default!;

    public string ContainerId { get; set; } = default!;

    public string ContainerType { get; set; } = default!;

    public class CreateArticleResourceCommandHandler(
            IResourceDomainRepository resourceRepository,
            ILessonDomainRepository lessonRepository,
            IArticleDomainRepository articleRepository,
            ICourseDomainRepository courseRepository)
        : IRequestHandler<CreateArticleResourceCommand, CreateResourceOutputModel>
    {
        public async Task<CreateResourceOutputModel> Handle(
            CreateArticleResourceCommand request,
            CancellationToken cancellationToken)
        {
            IResourceContainer container;
            Resource resource;
            switch (request.ContainerType)
            {
                case "Lesson":
                    container = await lessonRepository.Find(request.ContainerId, cancellationToken);
                    resource = new Resource()
                    {
                        FileUrl = request.FileUrl,
                        LessonId = request.ContainerId,
                    };
                    break;
                case "Article":
                    container = await articleRepository.Find(request.ContainerId, cancellationToken);
                    resource = new Resource()
                    {
                        FileUrl = request.FileUrl,
                        ArticleId = request.ContainerId,
                    };
                    break;
                case "Course":
                    container = await courseRepository.Find(request.ContainerId, cancellationToken);
                    resource = new Resource()
                    {
                        FileUrl = request.FileUrl,
                        CourseId = request.ContainerId,
                    };
                    break;
                default:
                    container = null;
                    resource = null;
                    break;
            }

            if (container == null)
            {
                return null;
            }

            container.AddResource(resource);

            await resourceRepository.Save(resource, cancellationToken);

            return new CreateResourceOutputModel(resource.Id);
        }
    }
}
