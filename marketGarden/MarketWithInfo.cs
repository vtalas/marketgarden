using marketGarden.Models;

namespace MarketGarden
{
	public class MarketWithInfo : Market
	{
		public string MarketName { get; set; }
		public string TradeUrlGui { get; set; }
	}
}