namespace Umeliko.Application.Learning.Courses.Commands.Common;

using Umeliko.Application.Common;

public abstract class CourseCommand<TCommand> : EntityCommand<string>
    where TCommand : EntityCommand<string>
{
    public string Content { get; set; } = default!;

    public string MaterialId { get; set; } = default!;
}
