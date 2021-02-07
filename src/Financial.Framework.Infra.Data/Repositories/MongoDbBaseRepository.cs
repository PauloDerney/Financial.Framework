using Financial.Framework.Domain.Entities;
using Financial.Framework.Infra.Data.AppModels;
using Financial.Framework.Infra.Data.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Financial.Framework.Infra.Data.Repositories
{
    public class MongoDbBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity<Guid>
    {
        protected readonly IMongoCollection<TEntity> Collection;

        public MongoDbBaseRepository(IOptions<DatabaseSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);

            Collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task InsertAsync(TEntity item)
        {
            item.Id = Guid.NewGuid();
            await Collection.InsertOneAsync(item);
        }

        public async Task InsertAsync(IList<TEntity> items)
        {
            foreach (var item in items)
                item.Id = Guid.NewGuid();

            await Collection.InsertManyAsync(items);
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await (await Collection.FindAsync(col => true)).ToListAsync();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await (await Collection.FindAsync(filter)).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await (await Collection.FindAsync(c => c.Id == id)).FirstOrDefaultAsync();
        }

        public async Task<IList<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await (await Collection.FindAsync<TEntity>(filter)).ToListAsync();
        }

        public async Task<IList<TEntity>> GetPaginatedResultAsync(Expression<Func<TEntity, bool>> filter, int skip, int limit)
        {
            var option = new FindOptions<TEntity>
            {
                Skip = skip,
                Limit = limit
            };

            return await (await Collection.FindAsync<TEntity>(filter, option)).ToListAsync();

        }

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Collection.CountDocumentsAsync<TEntity>(filter);
        }

        public async Task RemoveAsync(Guid id)
        {
            await Collection.DeleteOneAsync(col => col.Id == id);
        }

        public async Task UpdateAsync(TEntity updateItem)
        {
            if (updateItem.Id != Guid.Empty)
                await Collection.ReplaceOneAsync(col => col.Id == updateItem.Id, updateItem);
            else
                await InsertAsync(updateItem);
        }
    }
}
