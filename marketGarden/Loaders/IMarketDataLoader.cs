using System;
using System.Linq;

namespace MarketGarden.Loaders
{
	public interface IMarketDataLoader
	{
		IQueryable<Picus> GetAll();
		IQueryable<Picus> GetOffset(long seconds);
		IQueryable<Picus> GetInterval(DateTime from, DateTime to);
	}
}