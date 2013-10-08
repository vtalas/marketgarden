namespace MarketGarden.RecordProcessor
{
	public interface IMarketRecordProcessor
	{
		void ProcessMarketData(Picus data);
	}
}