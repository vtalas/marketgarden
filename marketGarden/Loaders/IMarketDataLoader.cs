using System.Linq;

namespace MarketGarden.Loaders
{
	public interface IMarketDataLoader
	{
		IQueryable<Picus> GetAll();
	}
}