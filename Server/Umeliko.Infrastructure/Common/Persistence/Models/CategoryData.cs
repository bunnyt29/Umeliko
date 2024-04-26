namespace Umeliko.Infrastructure.Common.Persistence.Models;

internal class CategoryData
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string CreatorId { get; set; } = default!;

    public CreatorData Creator { get; set; } = default!;
}
