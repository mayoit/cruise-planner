using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FishingTrip.Application.Interface
{
    public interface IDbContext
    {
        public ChangeTracker ChangeTracker { get; }
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default);
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(
            TEntity entity,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        void AddRange(params object[] entities);
        Task AddRangeAsync(params object[] entities);
        void AddRange(IEnumerable<object> entities);
        Task AddRangeAsync(
            IEnumerable<object> entities,
            CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;
        EntityEntry Entry(object entity);
    }
}
