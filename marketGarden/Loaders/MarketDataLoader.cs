using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketGarden.Loaders
{

	public class MarketDataLoader : IMarketDataLoader
	{
		public IMarketDataParser Parser { get; set; }

		public MarketDataLoader(IMarketDataParser parser)
		{
			Parser = parser;
		}

		public IQueryable<Picus> GetAll()
		{
			var z = new List<Picus>();

	//		z.Add(new Picus() {Ask = 1.2, Bid = 2.10, DateTime = DateTime.Now});
			Parser.ParseRecord("VIRC	LTCBTC	1380405602	0.01701	0.01722996				3002.02693178		1380405601");

			return z.AsQueryable();
		}

	}
}