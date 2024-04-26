namespace Umeliko.Domain.Learning.Models.Materials;

using Common.Models;

public class ContentType : Enumeration
{
    public static readonly ContentType Article = new ContentType(1, nameof(Article));
    public static readonly ContentType Lesson = new ContentType(2, nameof(Lesson));
    public static readonly ContentType Course = new ContentType(3, nameof(Course));

    private ContentType(int value)
        : this(value, FromValue<ContentType>(value).Name)
    {
    }

    private ContentType(int value, string name)
        : base(value, name)
    {
    }
}
