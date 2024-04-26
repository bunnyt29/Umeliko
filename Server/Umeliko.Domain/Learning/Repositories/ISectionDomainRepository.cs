namespace Umeliko.Domain.Learning.Repositories;

using Common;
using Models.Materials;

public interface ISectionDomainRepository : IDomainRepository<Section>
{
    Task<Section> Find(int id, CancellationToken cancellationToken = default);

    Task<bool> Delete(int id, CancellationToken cancellationToken = default);

    Task<bool> HasItem(int sectionId, int itemId, CancellationToken cancellationToken = default);
}
