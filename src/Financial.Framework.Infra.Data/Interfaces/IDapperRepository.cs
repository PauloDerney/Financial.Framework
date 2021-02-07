using Financial.Framework.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financial.Framework.Infra.Data.Interfaces
{
    public interface IDapperRepository<TEntity, TIdentifier> where TEntity : Entity<TIdentifier>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(TIdentifier id);

        Task DeleteAsync(TIdentifier id);

        Task<IEnumerable<TEntity>> GetByFieldAsync(string field, object value);
    }
}
