namespace Umeliko.Infrastructure.Learning.Repositories;

using Application.Learning.Items;
using AutoMapper;
using Domain.Learning.Models.Materials;
using System;
using System.Threading.Tasks;
using Umeliko.Domain.Learning.Repositories;
using Umeliko.Infrastructure.Common.Persistence;

internal class ItemRepository(ILearningDbContext db, IMapper mapper)
    : DataRepository<ILearningDbContext, Item>(db),
        IItemDomainRepository,
        IItemQueryRepository
{
    public Task<Item> Find(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasArticle(int itemId, string articleId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasLesson(int itemId, string lessonId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
