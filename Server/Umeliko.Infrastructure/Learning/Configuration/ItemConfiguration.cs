namespace Umeliko.Infrastructure.Learning.Configuration;

using Domain.Learning.Models.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Learning.Models.ModelConstants.Item;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder
            .HasKey(i => i.Id);

        builder
            .Property(i => i.Title)
            .IsRequired()
            .HasMaxLength(MaxTitleLength);

        builder
            .OwnsOne(i => i.CourseContentType,
                c =>
                {
                    c.WithOwner();

                    c.Property(co => co.Value);
                });

        //builder
        //    .HasOne(i => i.Article)
        //    .WithOne()
        //    .HasForeignKey<Article>("ItemId")
        //    .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(i => i.Lesson)
            .WithOne()
            .HasForeignKey<Lesson>("ItemId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
