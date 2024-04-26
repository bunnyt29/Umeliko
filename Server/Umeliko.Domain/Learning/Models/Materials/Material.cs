namespace Umeliko.Domain.Learning.Models.Materials;

using Common;
using Common.Models;
using Creators;
using Rating.Events.Votes;
using Rating.Models.Comments;
using Rating.Models.Votes;

public class Material : Entity<string>, IAggregateRoot
{
    private readonly HashSet<Vote> votes;
    private readonly HashSet<Comment> comments;

    private Material()
    {
        this.Id = Guid.NewGuid().ToString();

        this.votes = new HashSet<Vote>();
        this.comments = new HashSet<Comment>();
    }

    internal Material(ContentType contentType, StateType stateType)
        : this()
    {
        this.ContentType = contentType;
        this.StateType = stateType;
    }

    public ContentType ContentType { get; } = default!;

    public bool IsPublic { get; private set; } = false;

    public StateType StateType { get; private set; } = default!;

    public string? StateReason { get; set; } = default;

    public DateTime CreatedOn { get; private set; } = DateTime.Now;

    public Banner Banner { get; private set; } = default!;

    public Article Article { get; private set; } = default!;

    public Lesson Lesson { get; private set; } = default!;

    public Course Course { get; private set; } = default!;

    public Creator Creator { get; private set; } = default!;

    public string CreatorId { get; private set; } = default!;

    public Material ChangeState(string type)
    {
        switch (type)
        {
            case "None":
                this.StateType = Enumeration.FromValue<StateType>(1);

                this.IsPublic = false;
                break;
            case "Pending":
                this.StateType = Enumeration.FromValue<StateType>(2);
                break;
            case "Disapproved":
                this.StateType = Enumeration.FromValue<StateType>(3);
                break;
            case "Approved":
                this.StateType = Enumeration.FromValue<StateType>(4);

                this.IsPublic = true;
                break;
        }

        return this;
    }

    public Material ChangeVisibility()
    {
        this.ChangeState(this.IsPublic ? "None" : "Pending");

        return this;
    }

    public IReadOnlyCollection<Vote> Votes => this.votes.ToList().AsReadOnly();

    public void AddVote(Vote vote)
    {
        this.votes.Add(vote);

        RaiseEvent(new VoteAddedEvent());
    }

    public IReadOnlyCollection<Comment> Comments => this.comments.ToList().AsReadOnly();

    public void AddComment(Comment comment)
    {
        this.comments.Add(comment);

        RaiseEvent(new VoteAddedEvent());
    }
}
