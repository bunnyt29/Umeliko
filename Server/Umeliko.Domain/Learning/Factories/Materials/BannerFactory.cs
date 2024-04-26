namespace Umeliko.Domain.Learning.Factories.Materials;

using Models.Materials;

internal class BannerFactory : IBannerFactory
{
    private string bannerCoverImageUrl = default!;
    private string bannerTitle = default!;
    private string? bannerDescription;
    private string bannerCategory = default!;
    private string bannerLevel = default!;
    private string bannerMaterialId = default!;

    public IBannerFactory WithCoverImageUrl(string coverImageUrl)
    {
        this.bannerCoverImageUrl = coverImageUrl;
        return this;
    }

    public IBannerFactory WithTitle(string title)
    {
        this.bannerTitle = title;
        return this;
    }

    public IBannerFactory WithDescription(string? description)
    {
        this.bannerDescription = description;
        return this;
    }

    public IBannerFactory WithCategory(string category)
    {
        this.bannerCategory = category;
        return this;
    }

    public IBannerFactory WithLevel(string level)
    {
        this.bannerLevel = level;
        return this;
    }

    public IBannerFactory WithMaterialId(string materialId)
    {
        this.bannerMaterialId = materialId;
        return this;
    }

    public Banner Build() => new Banner(
        this.bannerCoverImageUrl,
        this.bannerTitle,
        this.bannerDescription,
        this.bannerCategory,
        this.bannerLevel,
        this.bannerMaterialId);
}
