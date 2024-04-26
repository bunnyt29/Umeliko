namespace Umeliko.Domain.Rating.Models.Votes;

using Common;
using Common.Models;

public class Vote : Entity<int>, IAggregateRoot
{
    private Vote()
    {
    }

    public Vote(VoteType voteType, string creatorId, string materialId)
        : this()
    {
        this.VoteType = voteType;
        this.CreatorId = creatorId;
        this.MaterialId = materialId;
    }

    public VoteType VoteType { get; } = default!;

    public string CreatorId { get; set; } = default!;

    public string MaterialId { get; set; } = default!;
}
