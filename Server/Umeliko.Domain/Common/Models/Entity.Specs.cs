﻿namespace Umeliko.Domain.Common.Models;

using Xunit;

public class EntitySpecs
{
    [Fact]
    public void EntitiesWithEqualIdsShouldBeEqual()
    {
        // Arrange
        //var first = new Manufacturer("First").SetId(1);
        //var second = new Manufacturer("Second").SetId(1);

        //// Act
        //var result = first == second;

        //// Arrange
        //result.Should().BeTrue();
    }

    [Fact]
    public void EntitiesWithDifferentIdsShouldNotBeEqual()
    {
        // Arrange
        //var first = new Manufacturer("First").SetId(1);
        //var second = new Manufacturer("Second").SetId(2);

        //// Act
        //var result = first == second;

        //// Arrange
        //result.Should().BeFalse();
    }
}

internal static class EntityExtensions
{
    public static TEntity SetId<TEntity>(this TEntity entity, string id)
        where TEntity : Entity<string>
        => (entity.SetId<string>(id) as TEntity)!;

    private static Entity<T> SetId<T>(this Entity<T> entity, string id)
    {
        entity
            .GetType()
            .BaseType!
            .GetProperty(nameof(Entity<T>.Id))!
            .GetSetMethod(true)!
            .Invoke(entity, new object[] { id });

        return entity;
    }
}