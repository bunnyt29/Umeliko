namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Sections;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Umeliko.Domain.Learning.Models.Materials;
using Umeliko.Domain.Learning.Repositories;
using Umeliko.Infrastructure.Common.Persistence;

internal class SectionRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Section>(db),
        ISectionDomainRepository,
        ISectionQueryRepository
{
    public async Task<Section> Find(int id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(k => k.Id == id, cancellationToken);

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var section = await this.Find(id);

        if (section == null)
        {
            return false;
        }

        this.Data.Sections.Remove(section);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public Task<bool> HasItem(int sectionId, int itemId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
