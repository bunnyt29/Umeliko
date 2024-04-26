namespace Umeliko.Domain.Learning.Specifications.Materials;

using Common;
using Models.Materials;
using System.Linq.Expressions;

public class MaterialOnlyPublicSpecification(bool onlyPublic) : Specification<Material>
{
    public override Expression<Func<Material, bool>> ToExpression()
    {
        if (onlyPublic)
        {
            return material => material.IsPublic;
        }

        return carAd => true;
    }
}
