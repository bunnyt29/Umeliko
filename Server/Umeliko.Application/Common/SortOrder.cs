namespace Umeliko.Application.Common;

using System.Linq.Expressions;

public abstract class SortOrder<TEntity>(string? sortBy, string? order)
{
    public const string Ascending = "asc";
    public const string Descending = "desc";

    public string? SortBy { get; } = sortBy;

    public string? Order { get; } = order;

    public abstract Expression<Func<TEntity, object>> ToExpression();
}
