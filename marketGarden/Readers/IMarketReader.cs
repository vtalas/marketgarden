namespace MarketGarden.Readers
{
	public interface IMarketReader
	{
		Picus ReadData(string symbol);
	}
}