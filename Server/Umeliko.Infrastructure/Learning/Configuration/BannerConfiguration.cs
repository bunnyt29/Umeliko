namespace Umeliko.Infrastructure.Learning.Configuration;

using Domain.Learning.Models.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Learning.Models.ModelConstants.Banner;
using static Domain.Learning.Models.ModelConstants.Common;

public class BannerConfiguration : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.CoverImageUrl)
            .IsRequired()
            .HasMaxLength(MaxUrlLength);

        builder
            .Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(MaxTitleLength);

        builder
            .Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(MaxTitleLength);

        builder
            .Property(b => b.Category)
            .IsRequired();

        builder
            .Property(b => b.Level)
            .IsRequired();

        builder
            .HasMany(b => b.Keywords)
            .WithOne()
            .Metadata
            .PrincipalToDependent
            ?.SetField("keywords");
    }
}
