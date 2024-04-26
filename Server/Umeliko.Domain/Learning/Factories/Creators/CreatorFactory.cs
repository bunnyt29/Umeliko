namespace Umeliko.Domain.Learning.Factories.Creators;

using Models.Creators;

internal class CreatorFactory : ICreatorFactory
{
    private string creatorFirstName = default!;
    private string creatorLastName = default!;

    public ICreatorFactory WithFirstName(string firstName)
    {
        this.creatorFirstName = firstName;
        return this;
    }

    public ICreatorFactory WithLastName(string lastName)
    {
        this.creatorLastName = lastName;
        return this;
    }

    public Creator Build() => new Creator(this.creatorFirstName, this.creatorLastName);
}