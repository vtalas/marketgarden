using System.Collections.Generic;
using System.Linq;
using MarketGarden;
using marketGarden.Models;
using MarketGarden.RecordProcessor;

namespace marketGarden
{
	public class Chochoo
	{
		public List<PicusWithName> Picuses { get; set; }
		public IMarketRecordProcessor RecordProcessor { get; set; }

		public Chochoo(List<PicusWithName> picuses, IMarketRecordProcessor recordProcessor)
		{
			Picuses = picuses;
			RecordProcessor = recordProcessor;
		}

		public PicusDiff Process()
		{
			var minAsk = Picuses.OrderBy(a => a.Ask).First();
			var maxBid = Picuses.OrderByDescending(u => u.Bid).First();

			if (minAsk.Ask < maxBid.Bid || true)
			{
				var diff  = new PicusDiff
				{
					BuyMarket = minAsk.MarketName,
					SellMarket = maxBid.MarketName,
					Ask = minAsk.Ask,
 					Bid = maxBid.Bid,
					DateTimeUtc = minAsk.DateTimeUtc,
					DateTimeUtcSellMarket = maxBid.DateTimeUtc
				};
				RecordProcessor.ProcessMarketData(diff);
				return diff;
			}
			return null;
		}
	}
}