using System;
using System.Linq;

namespace MarketGarden.Loaders
{
	public interface IMarketDataLoader
	{
		IQueryable<Picus> GetOffset(long seconds);
		IQueryable<Picus> GetInterval(DateTime from, DateTime to);

		// reading from date "from" until maxrecordcount or the end of data.
		IQueryable<Picus> GetInterval(DateTime from);
	}
}