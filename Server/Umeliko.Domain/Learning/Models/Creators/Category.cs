namespace Umeliko.Domain.Learning.Models.Creators;

using Common;
using Common.Models;

public class Category : Entity<string>, IAggregateRoot
{
    internal Category(string name)
    {
        this.Id = Guid.NewGuid().ToString();

        this.Name = name;
    }

    public string Name { get; private set; }

    public string CreatorId { get; private set; }

    public Category UpdateName(string name)
    {
        Name = name;

        return this;
    }
}
