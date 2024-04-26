namespace Umeliko.Infrastructure.Learning.Configuration;

using Domain.Learning.Models.Creators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Learning.Models.ModelConstants.Common;

internal class CreatorConfiguration : IEntityTypeConfiguration<Creator>
{
    public void Configure(EntityTypeBuilder<Creator> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(MaxNameLength);

        builder
            .Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(MaxNameLength);

        builder
            .HasMany(c => c.Categories)
            .WithOne()
            .Metadata
            .PrincipalToDependent
            ?.SetField("categories");

        builder
            .HasMany(c => c.Materials)
            .WithOne(m => m.Creator)
            .Metadata
            .PrincipalToDependent
            ?.SetField("materials");

        builder
            .HasMany(c => c.Votes)
            .WithOne()
            .Metadata
            .DependentToPrincipal
            ?.SetField("votes");
    }
}
