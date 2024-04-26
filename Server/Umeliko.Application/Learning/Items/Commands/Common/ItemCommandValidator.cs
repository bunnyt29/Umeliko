namespace Umeliko.Application.Learning.Items.Commands.Common;

using Domain.Learning.Models.Materials;
using FluentValidation;
using Umeliko.Application.Common;
using Umeliko.Domain.Common.Models;
using Umeliko.Domain.Learning.Repositories;

public class ItemCommandValidator<TCommand> : AbstractValidator<ItemCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public ItemCommandValidator(IItemDomainRepository itemRepository)
    {
        this.RuleFor(m => m.CourseContentType)
            .Must(Enumeration.HasValue<CourseContentType>)
            .WithMessage("'Course Content Type' is not valid.");
    }
}
