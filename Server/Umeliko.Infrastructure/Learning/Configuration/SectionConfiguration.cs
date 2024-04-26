namespace Umeliko.Infrastructure.Learning.Configuration;

using Domain.Learning.Models.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Learning.Models.ModelConstants.Section;

public class SectionConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder
            .HasKey(s => s.Id);

        builder
            .Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(MaxTitleLength);

        builder
            .HasMany(s => s.Items)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade)
            .Metadata
            .PrincipalToDependent
            ?.SetField("items");
    }
}
