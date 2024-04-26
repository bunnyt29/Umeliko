namespace Umeliko.Domain;

using FluentAssertions;
using Learning.Factories.Creators;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

public class DomainConfigurationSpecs
{
    [Fact]
    public void AddDomainShouldRegisterFactories()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();

        // Act
        var services = serviceCollection
            .AddDomain()
            .BuildServiceProvider();

        // Assert
        services
            .GetService<ICreatorFactory>()
            .Should()
            .NotBeNull();
    }
}