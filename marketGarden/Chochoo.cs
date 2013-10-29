using System.Collections.Generic;
using System.Linq;
using MarketGarden;
using marketGarden.Models;
using MarketGarden.RecordProcessor;

namespace marketGarden
{
	public class Chochoo
	{
		public List<MarketWithInfo> Picuses { get; set; }
		public IMarketRecordProcessor RecordProcessor { get; set; }

		public Chochoo(List<MarketWithInfo> picuses, IMarketRecordProcessor recordProcessor)
		{
			Picuses = picuses;
			RecordProcessor = recordProcessor;
		}

		public MarketDiff Process()
		{
			var minAsk = Picuses.OrderBy(a => a.Ask).First();
			var maxBid = Picuses.OrderByDescending(u => u.Bid).First();

			if (minAsk.Ask < maxBid.Bid)
			{
				var diff  = new MarketDiff
				{
					BuyMarket = minAsk,
					SellMarket = maxBid,
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