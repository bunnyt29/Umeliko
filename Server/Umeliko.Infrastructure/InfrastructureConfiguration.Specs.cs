namespace Umeliko.Infrastructure;

using Application.Learning.Banners;
using Common.Events;
using Common.Persistence;
using FluentAssertions;
using Learning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Xunit;

public class InfrastructureConfigurationSpecs
{
    [Fact]
    public void AddRepositoriesShouldRegisterRepositories()
    {
        // Arrange
        var serviceCollection = new ServiceCollection()
            .AddDbContext<UmelikoDbContext>(opts => opts
                .UseInMemoryDatabase(Guid.NewGuid().ToString()))
            .AddScoped<ILearningDbContext>(provider => provider
                .GetService<UmelikoDbContext>())
            .AddTransient<IEventDispatcher, EventDispatcher>();

        // Act
        var services = serviceCollection
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddRepositories()
            .BuildServiceProvider();

        // Assert
        services
            .GetService<IBannerQueryRepository>()
            .Should()
            .NotBeNull();
    }
}
