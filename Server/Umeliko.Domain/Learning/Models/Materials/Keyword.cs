namespace Umeliko.Domain.Learning.Models.Materials;

using Common;
using Common.Models;

public class Keyword : Entity<int>, IAggregateRoot
{
    public Keyword(string name, string bannerId)
    {
        this.Name = name;
        this.BannerId = bannerId;
    }

    public string Name { get; set; }

    public string BannerId { get; set; }
}
