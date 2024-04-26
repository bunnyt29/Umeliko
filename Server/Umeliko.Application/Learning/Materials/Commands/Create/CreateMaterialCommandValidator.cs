namespace Umeliko.Application.Learning.Materials.Commands.Create;

using Common;
using Domain.Learning.Repositories;
using FluentValidation;

public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialCommandValidator(IMaterialDomainRepository materialRepository)
        => this.Include(new MaterialCommandValidator<CreateMaterialCommand>(materialRepository));
}
