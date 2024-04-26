namespace Umeliko.Domain.Learning.Specifications.Materials;

using Common;
using Models.Materials;
using System.Linq.Expressions;

public class BannerByIdSpecification(string? id) : Specification<Banner>
{
    protected override bool Include => id != null;

    public override Expression<Func<Banner, bool>> ToExpression()
        => banner => banner.Id == id;
}
