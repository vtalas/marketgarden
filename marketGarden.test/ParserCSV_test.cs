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
		public void CultureDataShouldBeParsedCorrectely()
		{
			var instance = CreateDefault();

			var x = instance.ParseRecord("VIRC	LTCBTC	7200	0,01701	0,01722996				3002,02693178		1380405601");

			Assert.AreEqual(0.01722996, x.Ask);
			Assert.AreEqual(0.01701, x.Bid);
			Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, 0).AddHours(2), x.DateTimeUtc);
		}

		[Test]
		public void DefaultDataShouldBeParsedCorrectely()
		{
			var instance = CreateDefault();

			var x = instance.ParseRecord("VIRC	LTCBTC	0	0.01701	0.01722996				3002.02693178		1380405601");

			Assert.AreEqual(0.01722996, x.Ask);
			Assert.AreEqual(0.01701, x.Bid);
			Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, 0), x.DateTimeUtc);
		}

	}
}