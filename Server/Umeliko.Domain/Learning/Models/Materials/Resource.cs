namespace Umeliko.Domain.Learning.Models.Materials;

using Common;
using Common.Models;

public class Resource : Entity<int>, IAggregateRoot
{
    public string FileUrl { get; set; } = default!;

    public string? ArticleId { get; set; }

    public Article Article { get; set; } = default!;

    public string? LessonId { get; set; }

    public Lesson Lesson { get; set; } = default!;

    public string? CourseId { get; set; }

    public Course Course { get; set; } = default!;
}
