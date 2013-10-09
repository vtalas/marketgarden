using marketGarden.Models;

namespace MarketGarden.RecordProcessor
{
	public interface IMarketRecordProcessor
	{
		void ProcessMarketData(IPicusData data);
	}
}