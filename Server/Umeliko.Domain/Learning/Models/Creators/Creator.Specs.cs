namespace Umeliko.Domain.Learning.Models.Creators;

using FakeItEasy;
using FluentAssertions;
using Xunit;

public class CreatorSpecs
{
    [Fact]
    public void AddCategoryShouldSaveCategory()
    {
        // Arrange
        var creator = new Creator("John", "Doe");

        var category = A.Dummy<Category>();

        // Act
        creator.AddCategory(category);

        // Assert
        creator.Categories.Should().Contain(category);
    }
}