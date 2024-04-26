namespace Umeliko.Application.Learning.Courses.Commands.Common;

using Domain.Learning.Repositories;
using FluentValidation;
using Umeliko.Application.Common;

public class CourseCommandValidator<TCommand> : AbstractValidator<CourseCommand<TCommand>>
    where TCommand : EntityCommand<string>
{
    public CourseCommandValidator(ICourseDomainRepository courseRepository)
    {

    }
}
