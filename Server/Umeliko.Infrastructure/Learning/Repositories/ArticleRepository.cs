namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Articles;
using Application.Learning.Articles.Queries.Details;
using AutoMapper;
using Common.Persistence;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using Microsoft.EntityFrameworkCore;
using Umeliko.Application.Learning.Resources.Queries.Common;

internal class ArticleRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Article>(db),
        IArticleDomainRepository,
        IArticleQueryRepository
{
    public async Task<Article> Find(string id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);


    public async Task<bool> Delete(string id, CancellationToken cancellationToken = default)
    {
        var article = await this.Find(id);

        if (article == null)
        {
            return false;
        }

        this.Data.Articles.Remove(article);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> ArticleHasResource(
        string articleId,
        int resourceId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == articleId)
            .AnyAsync(a => a.Resources
                .Any(r => r.Id == resourceId));

    public async Task<ArticleDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<ArticleDetailsOutputModel>(this
                .All()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<ArticleDetailsOutputModel> GetDetailsByMaterialId(string materialId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<ArticleDetailsOutputModel>(this
                .All()
                .Where(a => a.MaterialId == materialId))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<ResourceOutputModel>> GetResources(string articleId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<ResourceOutputModel>(this
                .Data
                .Resources
                .Where(r => r.ArticleId == articleId))
            .ToListAsync(cancellationToken);
}
