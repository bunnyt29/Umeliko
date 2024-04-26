namespace Umeliko.Domain.Learning.Specifications.Materials;

using Common;
using Learning.Models.Materials;
using System.Linq.Expressions;

public class MaterialByStateTypeSpecification(int? stateType) : Specification<Material>
{
    protected override bool Include => stateType != null;

    public override Expression<Func<Material, bool>> ToExpression()
        => material => material.StateType.Value == stateType;
}
