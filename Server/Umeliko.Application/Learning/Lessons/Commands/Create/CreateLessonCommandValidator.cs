namespace Umeliko.Application.Learning.Lessons.Commands.Create;

using Common;
using Domain.Learning.Repositories;
using FluentValidation;

public class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
{
    public CreateLessonCommandValidator(ILessonDomainRepository lessonRepository)
        => this.Include(new LessonCommandValidator<CreateLessonCommand>(lessonRepository));
}
