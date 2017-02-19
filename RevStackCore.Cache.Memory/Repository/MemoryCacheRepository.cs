using System;
using System.Collections.Generic;
using RevStackCore.Pattern;

namespace RevStackCore.Cache.Memory
{
	public class MemoryCacheRepository<TEntity, TKey> : ICacheRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
	{
		private readonly MemoryCacheDbContext _dbContext;
		public MemoryCacheRepository(MemoryCacheDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Delete(string key)
		{
			_dbContext.Delete(key);
		}

		public TEntity Get(string key)
		{
			return _dbContext.Get<TEntity>(key);
		}

		public IEnumerable<TEntity> GetCollection(string key)
		{
			return _dbContext.GetCollection<TEntity>(key);
		}

		public void Set(TEntity entity, string key)
		{
			_dbContext.Set(entity, key);
		}

		public void Set(TEntity entity, string key, TimeSpan timeSpan)
		{
			_dbContext.Set(entity, key, timeSpan);
		}

		public void SetCollection(IEnumerable<TEntity> collection, string key)
		{
			_dbContext.SetCollection(collection, key);
		}

		public void SetCollection(IEnumerable<TEntity> collection, string key, TimeSpan timeSpan)
		{
			_dbContext.SetCollection(collection, key, timeSpan);
		}
	}
}
