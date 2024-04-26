namespace Umeliko.Domain.Learning.Specifications.Creators;

using Common;
using Models.Creators;
using System.Linq.Expressions;

public class CreatorByIdSpecification(string? id) : Specification<Creator>
{
    protected override bool Include => id != null;

    public override Expression<Func<Creator, bool>> ToExpression()
        => creator => creator.Id == id;
}
