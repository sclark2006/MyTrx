using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MyTrx.Data.Contexts
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DatabaseFacade Database { get; }
        //DbContextOptions Options { get; }
        ChangeTracker ChangeTracker { get; }
        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;

    }
}
