using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Entities;

namespace Trial.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(params object[] ids);

        TEntity FindById(params object[] ids);
        TEntity FindByIdAsNoTracking(params object[] ids);
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableAsNoTracking { get; }
    }
}
