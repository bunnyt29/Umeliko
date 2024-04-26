namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Materials;

public interface ICourseDomainRepository : IDomainRepository<Course>
{
    Task<Course> Find(string id, CancellationToken cancellationToken = default);

    Task<bool> Delete(string id, CancellationToken cancellationToken = default);

    Task<bool> CourseHasResource(string courseId, int resourceId, CancellationToken cancellationToken = default);

    Task<bool> CourseHasSection(string courseId, int sectionId, CancellationToken cancellationToken = default);
}
