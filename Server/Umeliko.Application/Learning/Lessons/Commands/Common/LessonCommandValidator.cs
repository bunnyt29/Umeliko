namespace Umeliko.Application.Learning.Lessons.Commands.Common;

using Application.Common;
using Domain.Learning.Repositories;
using FluentValidation;

public class LessonCommandValidator<TCommand> : AbstractValidator<LessonCommand<TCommand>>
    where TCommand : EntityCommand<string>
{
    public LessonCommandValidator(ILessonDomainRepository lessonRepository)
    {

    }
}
