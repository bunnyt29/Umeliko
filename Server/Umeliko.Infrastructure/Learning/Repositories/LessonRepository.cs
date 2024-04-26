namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Lessons;
using Application.Learning.Lessons.Queries.Details;
using Application.Learning.Resources.Queries.Common;
using AutoMapper;
using Common.Persistence;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using Microsoft.EntityFrameworkCore;

internal class LessonRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Lesson>(db),
        ILessonDomainRepository,
        ILessonQueryRepository
{
    public async Task<Lesson> Find(string id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

    public async Task<bool> Delete(string id, CancellationToken cancellationToken = default)
    {
        var lesson = await this.Find(id);

        if (lesson == null)
        {
            return false;
        }

        this.Data.Lessons.Remove(lesson);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> LessonHasResource(
        string lessonId,
        int resourceId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(l => l.Id == lessonId)
            .AnyAsync(l => l.Resources
                .Any(r => r.Id == resourceId));

    public async Task<LessonDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<LessonDetailsOutputModel>(this
                .All()
                .Where(l => l.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<LessonDetailsOutputModel> GetDetailsByMaterialId(string materialId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<LessonDetailsOutputModel>(this
                .All()
                .Where(l => l.MaterialId == materialId))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<ResourceOutputModel>> GetResources(string lessonId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<ResourceOutputModel>(this
                .Data
                .Resources
                .Where(r => r.LessonId == lessonId))
            .ToListAsync(cancellationToken);
}
