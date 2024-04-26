namespace Umeliko.Infrastructure.Learning;

using Common.Persistence;
using Domain.Learning.Models.Creators;
using Domain.Learning.Models.Materials;
using Identity;
using Microsoft.EntityFrameworkCore;

internal interface ILearningDbContext : IDbContext
{
    DbSet<User> Users { get; }

    DbSet<Creator> Creators { get; }

    DbSet<Follow> Follows { get; }

    DbSet<Category> Categories { get; }

    DbSet<Material> Materials { get; }

    DbSet<Banner> Banners { get; }

    DbSet<Keyword> Keywords { get; }

    DbSet<Article> Articles { get; }

    DbSet<Lesson> Lessons { get; }

    DbSet<Resource> Resources { get; }

    DbSet<Course> Courses { get; }

    DbSet<Section> Sections { get; }

    DbSet<Item> Items { get; }
}
