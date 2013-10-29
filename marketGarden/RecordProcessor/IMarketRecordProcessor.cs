using marketGarden.Models;
using MarketGarden.Readers;

namespace MarketGarden.RecordProcessor
{
	public interface IMarketRecordProcessor
	{
		void ProcessMarketData(IMarketData data);
		Market ProcessMarketData(string symbolBase, string symbolAlt, IMarketReader marketReader);
	}
}