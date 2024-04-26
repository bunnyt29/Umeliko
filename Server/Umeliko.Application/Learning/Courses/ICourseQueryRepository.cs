namespace Umeliko.Application.Learning.Courses;

using Common.Contracts;
using Queries.Details;
using Umeliko.Application.Learning.Resources.Queries.Common;
using Umeliko.Domain.Learning.Models.Materials;

public interface ICourseQueryRepository : IQueryRepository<Course>
{
    Task<CourseDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default);

    Task<CourseDetailsOutputModel> GetDetailsByMaterialId(string materialId, CancellationToken cancellationToken = default);

    Task<IEnumerable<ResourceOutputModel>> GetResources(string courseId, CancellationToken cancellationToken = default);
}
