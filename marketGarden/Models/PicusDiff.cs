using System;
using System.Globalization;
using MarketGarden.Loaders;

namespace marketGarden.Models
{
	public class PicusDiff : IPicusData
	{
		public string BuyMarket { get; set; }
		public string SellMarket { get; set; }
		public double Ask { get; set; }
		public double Bid { get; set; }
		public DateTime DateTimeUtc { get; set; }
		public DateTime DateTimeUtcSellMarket { get; set; }

		public override string ToString()
		{
			return string.Format("{0} - {1} \t{2} \t{3} \t{4}", BuyMarket, SellMarket, Bid - Ask, Ask, Bid);
		}

		public string ToTsvLine()
		{
			return string.Format("{0}\t{1}\t{2}_{3}\t{4}\t{5}\t{6}\n", DateTimeUtc.ToTimestamp(),DateTimeUtcSellMarket.ToTimestamp(), BuyMarket, SellMarket, 
				(Bid - Ask).ToString(CultureInfo.InvariantCulture), 
				Ask.ToString(CultureInfo.InvariantCulture), 
				Bid.ToString(CultureInfo.InvariantCulture));
		}
	}
}