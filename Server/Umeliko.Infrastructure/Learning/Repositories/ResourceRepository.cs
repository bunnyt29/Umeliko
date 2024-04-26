namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Resources;
using AutoMapper;
using Common.Persistence;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using Microsoft.EntityFrameworkCore;

internal class ResourceRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Resource>(db),
        IResourceDomainRepository,
        IResourceQueryRepository
{
    public async Task<Resource> Find(int id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var resource = await this.Find(id);

        if (resource == null)
        {
            return false;
        }

        this.Data.Resources.Remove(resource);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }
}
