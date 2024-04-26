namespace Umeliko.Application.Learning.Items.Commands.Common;

using Application.Common;

public abstract class ItemCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string Title { get; set; } = default!;

    public int CourseContentType { get; set; }

    public int SectionId { get; set; }
}
