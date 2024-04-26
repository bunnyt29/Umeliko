namespace Umeliko.Domain.Learning.Factories.Creators;

using Exceptions;
using FluentAssertions;
using Xunit;

public class LaernerFactorySpecs
{
    [Fact]
    public void BuildShouldThrowExceptionIfFirstNameIsNotSet()
    {
        // Assert
        var creatorFactory = new CreatorFactory();

        // Act
        var firstName = () => creatorFactory
            .WithFirstName("John")
            .Build();

        // Assert
        firstName.Should().Throw<InvalidCreatorException>();
    }

    [Fact]
    public void BuildShouldThrowExceptionIfLastNameIsNotSet()
    {
        // Assert
        var creatorFactory = new CreatorFactory();

        // Act
        var lastName = () => creatorFactory
            .WithFirstName("Doe")
            .Build();

        // Assert
        lastName.Should().Throw<InvalidCreatorException>();
    }

    [Fact]
    public void BuildShouldCreateCreatorIfEveryPropertyIsSet()
    {
        // Assert
        var creatorFactory = new CreatorFactory();

        // Act
        var learner = creatorFactory
            .WithFirstName("John")
            .WithLastName("Doe")
            .Build();

        // Assert
        learner.Should().NotBeNull();
    }
}