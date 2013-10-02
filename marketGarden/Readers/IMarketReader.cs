namespace MarketGarden.Readers
{
	public interface IMarketReader
	{
		string ReadData(string symbol);
	}
}