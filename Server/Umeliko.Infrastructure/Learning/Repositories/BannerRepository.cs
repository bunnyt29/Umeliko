namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Banners;
using Application.Learning.Banners.Queries.Details;
using Application.Learning.Keywords.Queries.Common;
using AutoMapper;
using Common.Persistence;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using Microsoft.EntityFrameworkCore;

internal class BannerRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Banner>(db),
        IBannerDomainRepository,
        IBannerQueryRepository
{
    public async Task<Banner> Find(string id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<Banner> FindByMaterialId(string materialId, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(b => b.MaterialId == materialId, cancellationToken);

    public async Task<bool> Delete(string id, CancellationToken cancellationToken = default)
    {
        var banner = await this.Find(id);

        if (banner == null)
        {
            return false;
        }

        this.Data.Banners.Remove(banner);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> BannerHasKeyword(
        string bannerId,
        int keywordId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(b => b.Id == bannerId)
            .AnyAsync(b => b.Keywords
                .Any(k => k.Id == keywordId));

    public async Task<BannerDetailsOutputModel> GetDetails(string id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<BannerDetailsOutputModel>(this
                .All()
                .Where(b => b.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<BannerDetailsOutputModel> GetDetailsByMaterialId(string materialId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<BannerDetailsOutputModel>(this
                .All()
                .Where(b => b.MaterialId == materialId))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<KeywordOutputModel>> GetKeywords(string bannerId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<KeywordOutputModel>(this
                .Data
                .Keywords
                .Where(k => k.BannerId == bannerId))
            .ToListAsync(cancellationToken);
}
