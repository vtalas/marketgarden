
using System;
using System.Collections.Generic;
using System.Linq;
using MarketGarden.Loaders;
using marketGarden.Models;

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

		public IList<Market> GetInfo(DateTime from, DateTime to)
		{
			return Loader.GetInterval(from, to).ToList();
		}

		public IList<Market> GetInfo(DateTime from)
		{
			var x = new List<Market>();
			return x;
		}

		public IList<Market> GetInfo()
		{
			var x =  new  List<Market>();
			return x;
		}
	}
}
