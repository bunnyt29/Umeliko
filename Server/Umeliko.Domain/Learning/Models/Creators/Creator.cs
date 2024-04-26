namespace Umeliko.Domain.Learning.Models.Creators;

using Common;
using Common.Models;
using Events.Creators;
using Events.Materials;
using Exceptions;
using Materials;
using Rating.Events.Votes;
using Rating.Models.Comments;
using Rating.Models.Votes;

using static ModelConstants.Common;
using static ModelConstants.Creator;

public class Creator : Entity<string>, IAggregateRoot
{
    private readonly HashSet<Category> categories;
    private readonly HashSet<Material> materials;
    private readonly HashSet<Creator> following;
    private readonly HashSet<Vote> votes;
    private readonly HashSet<Comment> comments;

    internal Creator(string firstName, string lastName)
    {
        Validate(firstName, lastName);

        this.Id = Guid.NewGuid().ToString();

        this.FirstName = firstName;
        this.LastName = lastName;

        this.categories = new HashSet<Category>();
        this.materials = new HashSet<Material>();
        this.following = new HashSet<Creator>();
        this.votes = new HashSet<Vote>();
        this.comments = new HashSet<Comment>();
    }

    public string ImageUrl { get; private set; } = "https://res.cloudinary.com/dxqy3jgj3/image/upload/v1708158161/profile-default-image_tzncwc.jpg";

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string? Bio { get; private set; }

    public Creator UpdateImageUrl(string imageUrl)
    {
        this.ValidateImageUrl(imageUrl);
        this.ImageUrl = imageUrl;

        return this;
    }

    public Creator UpdateFirstName(string firstName)
    {
        this.ValidateFirstName(firstName);
        this.FirstName = firstName;

        return this;
    }

    public Creator UpdateLastName(string lastName)
    {
        this.ValidateLastName(lastName);
        this.LastName = lastName;

        return this;
    }

    public Creator UpdateBio(string? bio)
    {
        this.ValidateBio(bio);
        this.Bio = bio;

        return this;
    }

    public IReadOnlyCollection<Category> Categories => this.categories.ToList().AsReadOnly();

    public void AddCategory(Category category)
    {
        this.categories.Add(category);

        RaiseEvent(new CategoryAddedEvent());
    }

    public IReadOnlyCollection<Material> Materials => this.materials.ToList().AsReadOnly();

    public void AddMaterial(Material material)
    {
        this.materials.Add(material);

        RaiseEvent(new MaterialAddedEvent());
    }

    public IReadOnlyCollection<Creator> Following => this.following.ToList().AsReadOnly();

    public void Follow(Creator follow)
    {
        this.following.Add(follow);

        RaiseEvent(new FollowAddedEvent());
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

    private void Validate(string firstName, string lastName)
    {
        this.ValidateFirstName(firstName);
        this.ValidateLastName(lastName);
    }

    private void ValidateImageUrl(string imageUrl)
        => Guard.ForValidUrl<InvalidCreatorException>(
            imageUrl,
            nameof(ImageUrl));

    private void ValidateFirstName(string firstName)
        => Guard.ForStringLength<InvalidCreatorException>(
            firstName,
            MinNameLength,
            MaxNameLength,
            nameof(FirstName));

    private void ValidateLastName(string lastName)
        => Guard.ForStringLength<InvalidCreatorException>(
            lastName,
            MinNameLength,
            MaxNameLength,
            nameof(LastName));

    private void ValidateBio(string? bio)
        => Guard.ForMaxLength<InvalidCreatorException>(
            bio,
            MaxBioLength,
            nameof(this.Bio));
}