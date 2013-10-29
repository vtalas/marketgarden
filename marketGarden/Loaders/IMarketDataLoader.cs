using System;
using System.Linq;
using marketGarden.Models;

namespace MarketGarden.Loaders
{
	public interface IMarketDataLoader
	{
		IQueryable<Market> GetOffset(long seconds);
		IQueryable<Market> GetInterval(DateTime from, DateTime to);

		// reading from date "from" until maxrecordcount or the end of data.
		IQueryable<Market> GetInterval(DateTime from);
	}
}