namespace Umeliko.Domain.Learning.Specifications.Materials;

using Common;
using Models.Materials;
using System.Linq.Expressions;

public class MaterialByBannerTitleSpecification(string? title) : Specification<Material>
{
    protected override bool Include => title != null;

    public override Expression<Func<Material, bool>> ToExpression()
        => material => material.Banner.Title.ToLower().Contains(title!.ToLower());
}
