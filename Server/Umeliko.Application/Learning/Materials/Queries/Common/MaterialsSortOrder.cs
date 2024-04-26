namespace Umeliko.Application.Learning.Materials.Queries.Common;

using Application.Common;
using Domain.Learning.Models.Materials;
using System.Linq.Expressions;

public class MaterialsSortOrder : SortOrder<Material>
{
    public MaterialsSortOrder(string? sortBy, string? order)
        : base(sortBy, order)
    {
    }

    public override Expression<Func<Material, object>> ToExpression()
        => SortBy switch
        {
            "vote" => material => material.Votes
                .Select(vote => vote.VoteType.Value)
                .Count(voteType => voteType == 1),
            "title" => material => material.Banner.Title,
            "createdOn" => material => material.CreatedOn,
            _ => material => material.Id
        };
}
