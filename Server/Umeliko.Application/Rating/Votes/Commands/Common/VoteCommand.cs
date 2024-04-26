namespace Umeliko.Application.Rating.Votes.Commands.Common;

using Application.Common;

public abstract class VoteCommand<TCommand> : EntityCommand<string>
    where TCommand : EntityCommand<string>
{
    public int VoteType { get; set; }

    public string MaterialId { get; set; } = default!;
}
