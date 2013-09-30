using System;

namespace MarketGarden
{
	public class Picus
	{
		public DateTime DateTimeUtc {get; set; }
		public double Ask {get; set; }
		public double Bid {get; set; }
		public override string ToString()
		{
			return string.Format("{0}\t{1}\t{2}", DateTimeUtc, Bid, Ask);
		}
	}


}