namespace Umeliko.Application.Learning.Items.Commands.Create;

using Common;
using Domain.Common.Models;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using MediatR;

public class CreateItemCommand : ItemCommand<CreateItemCommand>, IRequest<CreateItemOutputModel>
{
    public class CreateItemCommandHandler(
            ISectionDomainRepository sectionRepository,
            IItemDomainRepository itemRepository)
        : IRequestHandler<CreateItemCommand, CreateItemOutputModel>
    {
        public async Task<CreateItemOutputModel> Handle(
            CreateItemCommand request,
            CancellationToken cancellationToken)
        {
            var section = await sectionRepository.Find(
                request.SectionId,
                cancellationToken);

            if (section == null)
            {
                return null;
            }

            var item = new Item(
                request.Title,
                Enumeration.FromValue<CourseContentType>(request.CourseContentType),
                request.SectionId);

            section.AddItem(item);

            await itemRepository.Save(item, cancellationToken);

            return new CreateItemOutputModel(section.Id);
        }
    }
}
