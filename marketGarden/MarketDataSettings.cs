using MarketGarden.Readers;
using MarketGarden.RecordProcessor;

namespace MarketGarden
{
	public class MarketDataSettings
	{
		public IMarketReader MarketReader { get; set; }
		public string SymbolBase { get; set; }
		public string SymbolAlt { get; set; }
		public IMarketRecordProcessor MarketRecordProcessor { get; set; }
	}
}