namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Materials;

public interface ILessonDomainRepository : IDomainRepository<Lesson>
{
    Task<Lesson> Find(string id, CancellationToken cancellationToken = default);

    Task<bool> Delete(string id, CancellationToken cancellationToken = default);

    Task<bool> LessonHasResource(string lessonId, int resourceId, CancellationToken cancellationToken = default);
}
