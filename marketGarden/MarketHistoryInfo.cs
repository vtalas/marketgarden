
using System;
using System.Collections.Generic;
using MarketGarden.Loaders;

namespace MarketGarden
{
	public class MarketHistoryInfo
	{
		public IMarketDataLoader Loader { get; set; }
		public static int MaxCount = 1000;

		public MarketHistoryInfo(IMarketDataLoader loader)
		{
			Loader = loader;
		}

		public IList<Picus> GetInfo(DateTime from, DateTime to)
		{
			var x = new List<Picus>();
			return x;
		}

		public IList<Picus> GetInfo(DateTime from)
		{
			var x = new List<Picus>();
			return x;
		}

		public IList<Picus> GetInfo()
		{
			var x =  new  List<Picus>();
			return x;
		}
	}
}
