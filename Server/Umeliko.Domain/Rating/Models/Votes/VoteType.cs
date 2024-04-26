namespace Umeliko.Domain.Rating.Models.Votes;

using Common.Models;
using Umeliko.Domain.Learning.Models.Materials;

public class VoteType : Enumeration
{
    public static readonly VoteType Up = new VoteType(1, nameof(Up));
    public static readonly VoteType Down = new VoteType(2, nameof(Down));

    private VoteType(int value)
        : this(value, FromValue<ContentType>(value).Name)
    {
    }

    private VoteType(int value, string name)
        : base(value, name)
    {
    }
}
