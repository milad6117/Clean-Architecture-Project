using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Entities;
using Trial.Data.Context;

namespace Trial.Data.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        #region Field
        private readonly IApplicationContext _context;
        public EFRepository(IApplicationContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> entities;
        protected DbSet<TEntity> Entities
        {
            get
            {
                if (entities == null)
                    entities = _context.Set<TEntity>();
                else
                {
                    return entities;
                }
                return entities;
            }
        }
        #endregion

        #region Methods
        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public TEntity FindById(params object[] ids)
        {
            return _context.Set<TEntity>().Find(ids);
        }

        public TEntity FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<TEntity>().Find(ids);
            if (entity != null)

                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<TEntity> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<TEntity>().FindAsync(ids);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
        #endregion

    }
}
