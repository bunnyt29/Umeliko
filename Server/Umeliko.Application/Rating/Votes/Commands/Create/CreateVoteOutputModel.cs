namespace Umeliko.Application.Rating.Votes.Commands.Create;

public class CreateVoteOutputModel(int voteId)
{
    public int VoteId { get; } = voteId;
}
