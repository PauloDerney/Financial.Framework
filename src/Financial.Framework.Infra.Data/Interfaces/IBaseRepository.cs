using Financial.Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Financial.Framework.Infra.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity<Guid>
    {
        Task InsertAsync(TEntity item);

        Task InsertAsync(IList<TEntity> item);

        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetByIdAsync(Guid id);

        Task UpdateAsync(TEntity updateItem);

        Task RemoveAsync(Guid id);

        Task<IList<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter);

        Task<IList<TEntity>> GetPaginatedResultAsync(Expression<Func<TEntity, bool>> filter, int skip, int limit);

        Task<long> CountAsync(Expression<Func<TEntity, bool>> filter);
    }
}
