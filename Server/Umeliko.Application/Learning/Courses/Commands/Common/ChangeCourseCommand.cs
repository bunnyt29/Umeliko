namespace Umeliko.Application.Learning.Courses.Commands.Common;

using Umeliko.Application.Common;
using Umeliko.Domain.Learning.Repositories;

internal static class ChangeCourseCommandExtensions
{
    public static async Task<Result> MaterialHasCourse(
        string materialId,
        IMaterialDomainRepository materialRepository,
        string courseId,
        CancellationToken cancellationToken)
    {
        var materialHasCourse = await materialRepository.HasArticle(
            materialId,
            courseId,
            cancellationToken);

        return materialHasCourse
            ? Result.Success
            : "You cannot edit this course.";
    }
}
