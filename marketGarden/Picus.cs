using System;
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
		public override string ToString()
		{
			return string.Format("{0} \t {1} \t {2}  ({3})", DateTimeUtc.ToTimestamp(), Bid, Ask, DateTimeUtc);
		}
	}


}