namespace Umeliko.Domain.Rating.Models.Comments;

using Common;
using Common.Models;
using Learning.Models.Creators;
using Learning.Models.Materials;

public class Comment : Entity<int>, IAggregateRoot
{
    public string Content { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public string CreatorId { get; set; } = default!;

    public Creator Creator { get; set; }

    public Material Material { get; set; }

    public string MaterialId { get; set; } = default!;
}
