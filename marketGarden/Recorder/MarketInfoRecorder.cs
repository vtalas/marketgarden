namespace MarketGarden.Recorder
{
	public class MarketInfoRecorder
	{
		public MarketDataSettings Settings { get; set; }

		public MarketInfoRecorder(MarketDataSettings settings)
		{
			Settings = settings;
		}

		public MarketWithInfo Process(string marketName)
		{
			var data =  Settings.MarketRecordProcessor.ProcessMarketData(Settings.SymbolBase, Settings.SymbolAlt, Settings.MarketReader);

			return new MarketWithInfo
			{
				Ask = data.Ask,
				Bid = data.Bid,
				MarketName = marketName,
				TradeUrlGui = Settings.MarketReader.TradeUrlGui(Settings.SymbolBase, Settings.SymbolAlt),
				Volume = data.Volume,
				DateTimeUtc = data.DateTimeUtc
			};
		}

	}
}