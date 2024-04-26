namespace Umeliko.Application.Learning.Articles.Commands.Common;

using Application.Common;

public abstract class ArticleCommand<TCommand> : EntityCommand<string>
    where TCommand : EntityCommand<string>
{
    public string Content { get; set; } = default!;

    public string MaterialId { get; set; } = default!;
}
