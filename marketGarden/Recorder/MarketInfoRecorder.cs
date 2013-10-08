namespace MarketGarden.Recorder
{
	public class MarketInfoRecorder
	{
		public MarketDataSettings Settings { get; set; }

		public MarketInfoRecorder(MarketDataSettings settings)
		{
			Settings = settings;
		}

		public Picus Process()
		{
			var data = Settings.MarketReader.ReadData(Settings.SymbolBase, Settings.SymbolAlt);
			Settings.MarketRecordProcessor.ProcessMarketData(data);
			return data;
		}
	}
}