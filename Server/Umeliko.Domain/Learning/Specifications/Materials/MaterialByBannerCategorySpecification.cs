namespace Umeliko.Domain.Learning.Specifications.Materials;

using Common;
using Learning.Models.Materials;
using System.Linq.Expressions;

public class MaterialByBannerCategorySpecification(string? category) : Specification<Material>
{
    protected override bool Include => category != null;

    public override Expression<Func<Material, bool>> ToExpression()
        => material => material.Banner.Category.ToLower().Contains(category!.ToLower());
}
