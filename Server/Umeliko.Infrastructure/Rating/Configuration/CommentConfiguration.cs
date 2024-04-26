namespace Umeliko.Infrastructure.Rating.Configuration;

using Domain.Rating.Models.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .HasKey(v => v.Id);

        builder
            .Property(b => b.Content)
            .IsRequired();

        builder
            .HasOne(c => c.Material)
            .WithMany()
            .HasForeignKey("MaterialId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.Creator)
            .WithMany()
            .HasForeignKey("CreatorId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
