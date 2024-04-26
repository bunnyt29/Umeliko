namespace Umeliko.Domain.Learning.Models.Materials;

using Common;
using Common.Models;
using Events.Materials;
using Exceptions;

using static ModelConstants.Banner;

public class Banner : Entity<string>, IAggregateRoot
{
    private readonly HashSet<Keyword> keywords;

    internal Banner(
        string coverImageUrl,
        string title,
        string? description,
        string category,
        string level,
        string materialId)
    {
        this.Validate(coverImageUrl, title, description);

        this.Id = Guid.NewGuid().ToString();

        this.CoverImageUrl = coverImageUrl;
        this.Title = title;
        this.Description = description;
        this.Category = category;
        this.Level = level;
        this.MaterialId = materialId;

        this.keywords = new HashSet<Keyword>();
    }

    public string CoverImageUrl { get; private set; } = "https://res.cloudinary.com/dxqy3jgj3/image/upload/v1708158184/banner-default-cover-image_npxap1.svg";

    public string Title { get; private set; }

    public string? Description { get; private set; }

    public string Category { get; private set; }

    public string Level { get; private set; }

    public string MaterialId { get; private set; }

    private void Validate(
        string coverImageUrl,
        string title,
        string? description)
    {
        this.ValidateCoverImageUrl(coverImageUrl);
        this.ValidateTitle(title);
        this.ValidateDescription(description);
    }

    public Banner UpdateCoverImageUrl(string coverImageUrl)
    {
        this.ValidateCoverImageUrl(coverImageUrl);
        this.CoverImageUrl = coverImageUrl;

        return this;
    }

    public Banner UpdateTitle(string title)
    {
        this.ValidateTitle(title);
        this.Title = title;

        return this;
    }

    public Banner UpdateDescription(string? description)
    {
        this.ValidateDescription(description);
        this.Description = description;

        return this;
    }

    public Banner UpdateCategory(string category)
    {
        this.Category = category;

        return this;
    }

    public Banner UpdateLevel(string level)
    {
        this.Level = level;

        return this;
    }

    public IReadOnlyCollection<Keyword> Keywords => this.keywords.ToList().AsReadOnly();

    public void AddKeyword(Keyword keyword)
    {
        this.keywords.Add(keyword);

        this.RaiseEvent(new KeywordAddedEvent());
    }

    private void ValidateCoverImageUrl(string coverImageUrl)
        => Guard.ForValidUrl<InvalidBannerException>(
            coverImageUrl,
            nameof(this.CoverImageUrl));

    private void ValidateTitle(string title)
        => Guard.ForStringLength<InvalidBannerException>(
            title,
            MinTitleLength,
            MaxTitleLength,
            nameof(this.Title));

    private void ValidateDescription(string? description)
        => Guard.ForMaxLength<InvalidBannerException>(
            description,
            MaxDescriptionLength,
            nameof(this.Description));
}
