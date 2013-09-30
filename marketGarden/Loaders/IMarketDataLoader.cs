using System;
using System.Linq;

namespace MarketGarden.Loaders
{
	public interface IMarketDataLoader
	{
		IQueryable<Picus> GetAll();
		IQueryable<Picus> GetAll(DateTime from, DateTime to);
	}
}