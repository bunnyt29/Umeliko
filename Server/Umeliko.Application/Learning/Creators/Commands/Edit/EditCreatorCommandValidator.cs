namespace Umeliko.Application.Learning.Creators.Commands.Edit;

using FluentValidation;

using static Domain.Learning.Models.ModelConstants.Common;
using static Domain.Learning.Models.ModelConstants.Creator;

public class EditCreatorCommandValidator : AbstractValidator<EditCreatorCommand>
{
    public EditCreatorCommandValidator()
    {
        this.RuleFor(c => c.ImageUrl)
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("'{PropertyName}' must be a valid url.")
            .NotEmpty();

        this.RuleFor(c => c.FirstName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(c => c.LastName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(c => c.Bio)
            .MaximumLength(MaxBioLength);
    }
}
