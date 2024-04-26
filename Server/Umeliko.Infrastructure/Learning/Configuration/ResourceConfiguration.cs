namespace Umeliko.Infrastructure.Learning.Configuration;

using Domain.Learning.Models.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.FileUrl)
            .IsRequired();

        builder
            .HasOne(r => r.Article)
            .WithMany()
            .HasForeignKey("ArticleId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(r => r.Lesson)
            .WithMany()
            .HasForeignKey("LessonId")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(r => r.Course)
            .WithMany()
            .HasForeignKey("CourseId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
