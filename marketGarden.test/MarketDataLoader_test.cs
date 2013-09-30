using System;
using System.IO;
using System.Linq;
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
			
			return new MarketDataLoaderStream(new ParserCSV());
		}

		[Test]
		public void xxx()
		{
			var instance = CreateDefault();


			var from = new DateTime(2013, 9, 29, 0, 0, 0, 0);
			var x = instance.GetAll(new DateTime(2013, 9,29, 0, 0,0,0), from.AddHours(1));

			Console.WriteLine(x.Count());
			Console.WriteLine(x.First().Ask);

			foreach (var picuse in x)
			{
				Console.WriteLine(picuse);
			}

			Assert.IsTrue(false);
		}
	}
}