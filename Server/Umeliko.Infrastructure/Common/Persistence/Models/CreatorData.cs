namespace Umeliko.Infrastructure.Common.Persistence.Models;

internal class CreatorData
{
    public string Id { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Bio { get; set; } = default!;

    public ICollection<CategoryData> Categories { get; set; } = new HashSet<CategoryData>();
}
