using System.Runtime.Remoting.Messaging;

namespace MarketGarden.Recorder
{
	public class MarketInfoRecorder
	{
		public MarketDataSettings Settings { get; set; }

		public MarketInfoRecorder(MarketDataSettings settings)
		{
			Settings = settings;
		}

		public PicusWithName Process(string marketName)
		{
			var data = Settings.MarketReader.ReadData(Settings.SymbolBase, Settings.SymbolAlt);
			Settings.MarketRecordProcessor.ProcessMarketData(data);

			return new PicusWithName
			{
				Ask = data.Ask,
				Bid = data.Bid,
				MarketName = marketName,
				Volume = data.Volume,
				DateTimeUtc = data.DateTimeUtc
			};
		}

	}
}