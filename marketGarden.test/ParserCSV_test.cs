using System;
using MarketGarden.Loaders;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class ParserCSV_test
	{
		public ParserCSV_test()
		{
	
		}

		public ParserCSV CreateDefault()
		{
			return new ParserCSV();
		}

		[Test]
		public void DefaultDataShouldBeParsedCorrectely()
		{
			var instance = CreateDefault();

			var x = instance.ParseRecord("VIRC	LTCBTC	1380405602	0.01701	0.01722996				3002.02693178		1380405601");

			Assert.AreEqual(x.Ask, 0.01722996);
			Assert.AreEqual(x.Bid, 0.01701);
//			Assert.AreEqual(x.DateTime, 0.01701);
		}

		[Test]
		public void CultureDataShouldBeParsedCorrectely()
		{
			var instance = CreateDefault();

			var x = instance.ParseRecord("VIRC	LTCBTC	1380405602	0,01701	0,01722996				3002,02693178		1380405601");

			Assert.AreEqual(x.Ask, 0.01722996);
			Assert.AreEqual(x.Bid, 0.01701);
//			Assert.AreEqual(x.DateTime, 0.01701);
		}
	}
}