using MarketGarden;
using MarketGarden.PathResolver;

namespace marketGarden.test
{
	public class Chuj
	{
		protected MarketDataSettings GetDefaultMarketSettings()
		{
			return new MarketDataSettings()
			{
				SymbolBase = "LTC",
				SymbolAlt = "BTC"
			};
		}

		protected IPathResolver GetPathResolver()
		{
			return new PathResolver(GetDefaultMarketSettings(), "btce");
		}


	}
}