namespace Umeliko.Application.Learning.Courses.Commands.Create;

using Common;
using Domain.Learning.Repositories;
using FluentValidation;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator(ICourseDomainRepository courseRepository)
        => this.Include(new CourseCommandValidator<CreateCourseCommand>(courseRepository));
}
