namespace Umeliko.Domain.Learning.Factories.Materials;

using Models.Materials;

internal class LessonFactory : ILessonFactory
{
    private string? lessonContent;
    private string? lessonFileUrl;
    private string? lessonMaterialId;
    private int lessonItemId;

    public ILessonFactory WithContent(string? content)
    {
        this.lessonContent = content;
        return this;
    }

    public ILessonFactory WithFileUrl(string? fileUrl)
    {
        this.lessonFileUrl = fileUrl;
        return this;
    }

    public ILessonFactory WithMaterialId(string? materialId)
    {
        this.lessonMaterialId = materialId;
        return this;
    }

    public ILessonFactory WithItemId(int sectionId)
    {
        this.lessonItemId = sectionId;
        return this;
    }

    public Lesson Build() => new Lesson(
        this.lessonContent,
        this.lessonFileUrl,
        this.lessonMaterialId,
        this.lessonItemId);
}
