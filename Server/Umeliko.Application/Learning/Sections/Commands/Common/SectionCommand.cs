namespace Umeliko.Application.Learning.Sections.Commands.Common;

using Umeliko.Application.Common;

public abstract class SectionCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string Title { get; set; } = default!;

    public string CourseId { get; set; } = default!;
}
