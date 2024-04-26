namespace Umeliko.Application.Learning.Lessons.Commands.Edit;

using Common;
using FluentValidation;
using Umeliko.Domain.Learning.Repositories;

public class EditLessonCommandValidator : AbstractValidator<EditLessonCommand>
{
    public EditLessonCommandValidator(ILessonDomainRepository bannerRepository)
        => this.Include(new LessonCommandValidator<EditLessonCommand>(bannerRepository));
}
