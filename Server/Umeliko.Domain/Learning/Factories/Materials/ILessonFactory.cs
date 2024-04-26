namespace Umeliko.Domain.Learning.Factories.Materials;

using Common;
using Models.Materials;

public interface ILessonFactory : IFactory<Lesson>
{
    ILessonFactory WithContent(string? content);

    ILessonFactory WithFileUrl(string? fileUrl);

    ILessonFactory WithMaterialId(string? materialId);

    ILessonFactory WithItemId(int itemId);
}
