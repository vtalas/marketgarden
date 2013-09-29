using System;
using MarketGarden.Loaders;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class MarketDataLoader_test
	{
		public MarketDataLoader_test()
		{
	
		}

		public IMarketDataLoader CreateDefault()
		{
			return new MarketDataLoader(new ParserCSV());
		}

		[Test]
		public void xxx()
		{
			var instance = CreateDefault();

			var x = instance.GetAll();

			Console.WriteLine("ljabsdkjbsa");
		}
	}
}