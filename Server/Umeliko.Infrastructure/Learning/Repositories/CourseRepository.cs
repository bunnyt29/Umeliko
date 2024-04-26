namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Courses;
using Application.Learning.Courses.Queries.Details;
using Application.Learning.Resources.Queries.Common;
using AutoMapper;
using Common.Persistence;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using Microsoft.EntityFrameworkCore;

internal class CourseRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Course>(db),
        ICourseDomainRepository,
        ICourseQueryRepository
{
    public async Task<Course> Find(string id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<bool> Delete(string id, CancellationToken cancellationToken = default)
    {
        var course = await this.Find(id);

        if (course == null)
        {
            return false;
        }

        this.Data.Courses.Remove(course);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> CourseHasResource(
        string courseId,
        int resourceId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(c => c.Id == courseId)
            .AnyAsync(c => c.Resources
                .Any(r => r.Id == resourceId));

    public async Task<bool> CourseHasSection(
        string courseId,
        int sectionId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(c => c.Id == courseId)
            .AnyAsync(c => c.Sections
                .Any(s => s.Id == sectionId));

    public async Task<CourseDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<CourseDetailsOutputModel>(this
                .All()
                .Where(c => c.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<CourseDetailsOutputModel> GetDetailsByMaterialId(string materialId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<CourseDetailsOutputModel>(this
                .All()
                .Where(c => c.MaterialId == materialId))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<ResourceOutputModel>> GetResources(string courseId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<ResourceOutputModel>(this
                .Data
                .Resources
                .Where(r => r.CourseId == courseId))
            .ToListAsync(cancellationToken);
}
