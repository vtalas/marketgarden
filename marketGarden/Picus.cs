using System;
using System.Globalization;
using MarketGarden.Loaders;
using Newtonsoft.Json;

namespace MarketGarden
{
	public class Picus
	{
		[JsonIgnore]
		public DateTime DateTimeUtc {get; set; }

		public ulong DateTime
		{
			get
			{
				return DateTimeUtc.ToJsTimestamp();
			}
		}

		public double Ask {get; set; }
		public double Bid {get; set; }
		public double Volume { get; set; }

		public override string ToString()
		{
			return string.Format("{0}\t{1}\t{2}\t{3} ({4})", DateTimeUtc.ToTimestamp(), Bid, Ask, Volume, DateTimeUtc);
		}
		
		public string ToTsvLine()
		{
			return string.Format("{0}\t{1}\t{2}\t{3}\n", DateTimeUtc.ToTimestamp(), 
				Bid.ToString(CultureInfo.InvariantCulture), 
				Ask.ToString(CultureInfo.InvariantCulture), 
				Volume.ToString(CultureInfo.InvariantCulture)
			);
		}
	}


}