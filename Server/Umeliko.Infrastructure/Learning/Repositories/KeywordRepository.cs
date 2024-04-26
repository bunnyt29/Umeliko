namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Keywords;

using AutoMapper;
using Common.Persistence;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Umeliko.Domain.Common;

internal class KeywordRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Keyword>(db),
        IKeywordDomainRepository,
        IKeywordQueryRepository
{
    public async Task<Keyword> Find(int id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(k => k.Id == id, cancellationToken);

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var keyword = await this.Find(id);

        if (keyword == null)
        {
            return false;
        }

        this.Data.Keywords.Remove(keyword);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IEnumerable<TOutputModel>> GetKeywordListings<TOutputModel>(
        Specification<Banner> bannerSpecification,
        CancellationToken cancellationToken = default)
        => await mapper
                .ProjectTo<TOutputModel>(this
                    .GetKeywordsQuery(bannerSpecification))
                .ToListAsync(cancellationToken);

    private IQueryable<Keyword> GetKeywordsQuery(Specification<Banner> bannerSpecification)
        => this
            .Data
            .Banners
            .Where(bannerSpecification)
            .SelectMany(b => b.Keywords);
}
