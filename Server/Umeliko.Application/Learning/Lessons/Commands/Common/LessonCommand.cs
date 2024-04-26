namespace Umeliko.Application.Learning.Lessons.Commands.Common;

using Application.Common;

public abstract class LessonCommand<TCommand> : EntityCommand<string>
    where TCommand : EntityCommand<string>
{
    public string? Content { get; set; }

    public string? FileUrl { get; set; }

    public string MaterialId { get; set; } = default!;

    public int ItemId { get; set; }
}
