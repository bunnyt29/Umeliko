namespace Umeliko.Infrastructure.Common.Persistence;

using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

internal class DatabaseInitializer(
        UmelikoDbContext db,
        IEnumerable<IInitialData> initialDataProviders)
    : IInitializer
{
    public void Initialize()
    {
        db.Database.Migrate();

        foreach (var initialDataProvider in initialDataProviders)
        {
            if (this.DataSetIsEmpty(initialDataProvider.EntityType))
            {
                var data = initialDataProvider.GetData();

                foreach (var entity in data)
                {
                    db.Add(entity);
                }
            }
        }

        db.SaveChanges();
    }

    private bool DataSetIsEmpty(Type type)
    {
        var setMethod = this.GetType()
            .GetMethod(nameof(this.GetSet), BindingFlags.Instance | BindingFlags.NonPublic)!
            .MakeGenericMethod(type);

        var set = setMethod.Invoke(this, Array.Empty<object>());

        var countMethod = typeof(Queryable)
            .GetMethods()
            .First(m => m.Name == nameof(Queryable.Count) && m.GetParameters().Length == 1)
            .MakeGenericMethod(type);

        var result = (int)countMethod.Invoke(null, new[] { set })!;

        return result == 0;
    }

    private DbSet<TEntity> GetSet<TEntity>()
        where TEntity : class
        => db.Set<TEntity>();
}
