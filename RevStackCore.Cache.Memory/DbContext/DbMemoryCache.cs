using System;
using Microsoft.Extensions.Caching.Memory;

namespace RevStackCore.Cache.Memory
{
	public sealed class DbMemoryCache
	{
		private static readonly IMemoryCache _memoryCache;
		public IMemoryCache Default
		{
			get
			{
				return _memoryCache;
			}
		}
		static DbMemoryCache()
		{
			_memoryCache = new MemoryCache(new MemoryCacheOptions());
		}
	}
}
