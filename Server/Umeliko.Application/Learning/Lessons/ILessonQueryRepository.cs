namespace Umeliko.Application.Learning.Lessons;

using Common.Contracts;
using Domain.Learning.Models.Materials;
using Queries.Details;
using Resources.Queries.Common;

public interface ILessonQueryRepository : IQueryRepository<Lesson>
{
    Task<LessonDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default);

    Task<LessonDetailsOutputModel> GetDetailsByMaterialId(string materialId, CancellationToken cancellationToken = default);

    Task<IEnumerable<ResourceOutputModel>> GetResources(string lessonId, CancellationToken cancellationToken = default);
}
