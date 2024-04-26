namespace Umeliko.Infrastructure.Learning.Configuration;

using Domain.Learning.Models.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .OwnsOne(m => m.ContentType,
                c =>
                {
                    c.WithOwner();

                    c.Property(co => co.Value);
                });

        builder
            .OwnsOne(m => m.StateType,
                s =>
                {
                    s.WithOwner();

                    s.Property(st => st.Value);
                });

        builder
            .Property(m => m.IsPublic)
            .IsRequired();

        builder
            .Property(m => m.StateReason);

        builder
            .HasOne(m => m.Banner)
            .WithOne()
            .HasForeignKey<Banner>("MaterialId")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(m => m.Article)
            .WithOne()
            .HasForeignKey<Article>("MaterialId")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(m => m.Lesson)
            .WithOne()
            .HasForeignKey<Lesson>("MaterialId")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(m => m.Course)
            .WithOne()
            .HasForeignKey<Course>("MaterialId")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(m => m.Votes)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict)
            .Metadata
            .PrincipalToDependent
            ?.SetField("votes");
    }
}
