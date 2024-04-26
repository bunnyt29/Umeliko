namespace Umeliko.Application.Learning.Materials.Commands.Common;

using Application.Common;
using Domain.Common.Models;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using FluentValidation;

public class MaterialCommandValidator<TCommand> : AbstractValidator<MaterialCommand<TCommand>>
    where TCommand : EntityCommand<string>
{
    public MaterialCommandValidator(IMaterialDomainRepository materialRepository)
    {
        this.RuleFor(m => m.ContentType)
            .Must(Enumeration.HasValue<ContentType>)
            .WithMessage("'Content Type' is not valid.");
    }
}
