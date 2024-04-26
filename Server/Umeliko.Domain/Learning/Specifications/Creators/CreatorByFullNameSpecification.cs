namespace Umeliko.Domain.Learning.Specifications.Creators;

using Common;
using Models.Creators;
using System.Linq.Expressions;

public class CreatorByFullNameSpecification(string? fullName) : Specification<Creator>
{
    protected override bool Include => fullName != null;

    public override Expression<Func<Creator, bool>> ToExpression()
        => creator => creator.FirstName.ToLower().Contains(fullName!.Split().ToArray().GetValue(0).ToString().ToLower()) ||
                      creator.FirstName.ToLower().Contains(fullName!.ToLower()) ||
                      creator.LastName.ToLower().Contains(fullName!.Split().ToArray().GetValue(0).ToString().ToLower()) ||
                      creator.LastName.ToLower().Contains(fullName!.ToLower());
}
