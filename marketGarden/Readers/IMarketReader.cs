using marketGarden.Models;

namespace MarketGarden.Readers
{
	public interface IMarketReader
	{
		Market ReadData(string @base, string alt);
		string ShortName { get; }
		string TradeUrlGui(string @base, string alt);
	}
}