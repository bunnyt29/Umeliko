namespace Umeliko.Domain.Learning.Models.Materials;

using Domain.Common.Models;

public class CourseContentType : Enumeration
{
    public static readonly CourseContentType Article = new CourseContentType(1, nameof(Article));
    public static readonly CourseContentType Lesson = new CourseContentType(2, nameof(Lesson));

    private CourseContentType(int value)
        : this(value, FromValue<ContentType>(value).Name)
    {
    }

    private CourseContentType(int value, string name)
        : base(value, name)
    {
    }
}
