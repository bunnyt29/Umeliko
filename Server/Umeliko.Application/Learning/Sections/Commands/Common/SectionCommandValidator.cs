namespace Umeliko.Application.Learning.Sections.Commands.Common;

using FluentValidation;
using Umeliko.Application.Common;
using Umeliko.Application.Learning.Banners.Commands.Common;
using Umeliko.Domain.Learning.Repositories;

using static Domain.Learning.Models.ModelConstants.Section;


public class SectionCommandValidator<TCommand> : AbstractValidator<BannerCommand<TCommand>>
    where TCommand : EntityCommand<string>
{
    public SectionCommandValidator(ISectionDomainRepository sectionRepository)
    {
        this.RuleFor(s => s.Title)
            .MinimumLength(MinTitleLength)
            .MaximumLength(MaxTitleLength)
            .NotEmpty();
    }
}
