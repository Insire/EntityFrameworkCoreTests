using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
#pragma warning disable CA1012 // Abstract types should not have constructors
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity>, IDisposable
#pragma warning restore CA1012 // Abstract types should not have constructors
        where TEntity : class, IEntity<TKey>
    {
        private DbContext _dbContext;
        private bool _isDisposed;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            return await GetAllInternal().ToListAsync().ConfigureAwait(false);
        }

        protected virtual IQueryable<TEntity> GetAllInternal()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id).ConfigureAwait(false);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext?.Dispose();
                    _dbContext = null;
                }

                // Free any other managed objects here.
            }

            // Free any unmanaged objects here.
            _isDisposed = true;
        }
    }
}
