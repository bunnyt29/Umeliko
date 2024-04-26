namespace Umeliko.Domain.Learning.Specifications.Materials;

using Common;
using System.Linq.Expressions;
using Umeliko.Domain.Learning.Models.Materials;

public class MaterialByBannerKeywordSpecification(string? name) : Specification<Material>
{
    protected override bool Include => name != null;

    public override Expression<Func<Material, bool>> ToExpression()
        => material => material.Banner.Keywords.Any(k => k.Name.ToLower().Contains(name.ToLower()));
}
