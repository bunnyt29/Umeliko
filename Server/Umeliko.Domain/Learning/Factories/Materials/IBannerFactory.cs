namespace Umeliko.Domain.Learning.Factories.Materials;

using Common;
using Models.Materials;

public interface IBannerFactory : IFactory<Banner>
{
    IBannerFactory WithCoverImageUrl(string coverImageUrl);

    IBannerFactory WithTitle(string title);

    IBannerFactory WithDescription(string? description);

    IBannerFactory WithCategory(string category);

    IBannerFactory WithLevel(string level);

    IBannerFactory WithMaterialId(string materialId);
}
