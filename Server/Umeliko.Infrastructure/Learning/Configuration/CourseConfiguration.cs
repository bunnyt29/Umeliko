namespace Umeliko.Infrastructure.Learning.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Umeliko.Domain.Learning.Models.Materials;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Content)
            .IsRequired();

        builder
            .HasMany(c => c.Sections)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade)
            .Metadata
            .PrincipalToDependent
            ?.SetField("sections");
    }
}
