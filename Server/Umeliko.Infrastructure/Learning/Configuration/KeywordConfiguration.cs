namespace Umeliko.Infrastructure.Learning.Configuration;

using Domain.Learning.Models.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class KeywordConfiguration : IEntityTypeConfiguration<Keyword>
{
    public void Configure(EntityTypeBuilder<Keyword> builder)
    {
        builder
            .HasKey(k => k.Id);

        builder
            .Property(k => k.Name)
            .IsRequired();
    }
}
