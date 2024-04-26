namespace Umeliko.Domain.Learning.Factories.Creators;

using Common;
using Models.Creators;

public interface ICreatorFactory : IFactory<Creator>
{
    ICreatorFactory WithFirstName(string firstName);

    ICreatorFactory WithLastName(string lastName);
}