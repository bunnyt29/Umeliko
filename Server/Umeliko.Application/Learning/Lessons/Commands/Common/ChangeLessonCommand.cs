namespace Umeliko.Application.Learning.Lessons.Commands.Common;
using System.Threading.Tasks;
using Umeliko.Application.Common;
using Umeliko.Domain.Learning.Repositories;

internal static class ChangeLessonCommandExtensions
{
    public static async Task<Result> MaterialHasLesson(
        string materialId,
        IMaterialDomainRepository materialRepository,
        string lessonId,
        CancellationToken cancellationToken)
    {
        var materialHasArticle = await materialRepository.HasLesson(
            materialId,
            lessonId,
            cancellationToken);

        return materialHasArticle
            ? Result.Success
            : "You cannot edit this lesson.";
    }
}
