namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Materials;
using Application.Learning.Materials.Queries.Common;
using Application.Learning.Materials.Queries.Details;
using AutoMapper;
using Common;
using Common.Persistence;
using Domain.Common;
using Domain.Learning.Models.Creators;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using Microsoft.EntityFrameworkCore;

internal class MaterialRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Material>(db),
    IMaterialDomainRepository,
    IMaterialQueryRepository
{
    public async Task<Material> Find(
        string id,
        CancellationToken cancellationToken = default)
        => await this
            .Data
            .Materials
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);


    public async Task<bool> HasBanner(

        string materialId,
        string bannerId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(m => m.Id == materialId)
            .AnyAsync(m => m.Banner.Id == bannerId, cancellationToken);

    public async Task<bool> HasArticle(
        string materialId,
        string articleId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(m => m.Id == materialId)
            .AnyAsync(m => m.Article.Id == articleId, cancellationToken);

    public async Task<bool> HasLesson(
        string materialId,
        string lessonId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(m => m.Id == materialId)
            .AnyAsync(m => m.Lesson.Id == lessonId, cancellationToken);

    public async Task<bool> HasVote(
        string materialId,
        int voteId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(m => m.Id == materialId)
            .AnyAsync(m => m.Votes
                .Any(v => v.Id == voteId), cancellationToken);

    public async Task<bool> HasComment(
        string materialId,
        int commentId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(m => m.Id == materialId)
            .AnyAsync(m => m.Comments
                .Any(v => v.Id == commentId), cancellationToken);

    public async Task<bool> Delete(string id, CancellationToken cancellationToken = default)
    {
        var material = await this.Find(id);

        if (material == null)
        {
            return false;
        }

        this.Data.Materials.Remove(material);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<MaterialDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<MaterialDetailsOutputModel>(this
                .All()
                .Where(m => m.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<TOutputModel>> GetMaterialListings<TOutputModel>(
        Specification<Material> materialSpecification,
        Specification<Material> materialByBannerSpecification,
        Specification<Creator> creatorSpecification,
        MaterialsSortOrder materialsSortOrder,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => (await mapper
                .ProjectTo<TOutputModel>(this
                    .GetMaterialsQuery(materialSpecification, creatorSpecification)
                    .Where(materialByBannerSpecification)
                    .Sort(materialsSortOrder))
                .ToListAsync(cancellationToken))
            .Skip(skip)
            .Take(take);

    public async Task<int> Total(
        Specification<Material> materialSpecification,
        Specification<Material> materialByBannerSpecification,
        Specification<Creator> creatorSpecification,
        CancellationToken cancellationToken = default)
        => await this
            .GetMaterialsQuery(materialSpecification, creatorSpecification)
            .Where(materialByBannerSpecification)
            .CountAsync(cancellationToken);

    private IQueryable<Material> GetMaterialsQuery(
        Specification<Material> materialSpecification,
        Specification<Creator> creatorSpecification)
        => this
            .Data
            .Creators
            .Where(creatorSpecification)
            .SelectMany(c => c.Materials)
            .Where(materialSpecification);
}
