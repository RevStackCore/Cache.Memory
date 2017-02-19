using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace RevStackCore.Cache.Memory
{
	public class MemoryCacheDbContext
	{
		private readonly IMemoryCache _context;
		private TimeSpan _timeSpan;
		public MemoryCacheDbContext()
		{
			_timeSpan = TimeSpan.FromMinutes(30);
			var db = new DbMemoryCache();
			_context = db.Default;
		}
		public MemoryCacheDbContext(TimeSpan timeSpan)
		{
			_timeSpan = timeSpan;
			var db = new DbMemoryCache();
			_context = db.Default;
		}

		public void Delete(string key)
		{
			_context.Remove(key);
		}

		public TEntity Get<TEntity>(string key)
		{
			return (TEntity)_context.Get(key);
		}

		public IEnumerable<TEntity> GetCollection<TEntity>(string key)
		{
			var entityCollection = (EntityCollection<TEntity>)_context.Get(key);
			if (entityCollection != null)
			{
				return entityCollection.Collection;
			}
			else
			{
				return null;
			}

		}

		public void Set<TEntity>(TEntity entity, string key)
		{
			_context.Set(key, entity, _timeSpan);
		}

		public void Set<TEntity>(TEntity entity, string key, TimeSpan timeSpan)
		{
			_context.Set(key, entity, timeSpan);
		}

		public void SetCollection<TEntity>(IEnumerable<TEntity> collection, string key)
		{
			Set(collection, key, _timeSpan);
		}

		public void SetCollection<TEntity>(IEnumerable<TEntity> collection, string key, TimeSpan timeSpan)
		{
			var entityCollection = new EntityCollection<TEntity>
			{
				Id = key,
				Collection = collection
			};
			_context.Set(key, collection, timeSpan);
		}
	}
}
