using System;
using System.Collections.Generic;
using MarketGarden;
using marketGarden.Models;
using MarketGarden.RecordProcessor;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class ChoChoo_test
	{
		[Test]
		public void BuyOnBuyMarket_SellOnSellMarket_test()
		{
			var list = new List<PicusWithName>
			{
				new PicusWithName {Ask = 100, Bid = 90, MarketName = "buy market"},
				new PicusWithName {Ask = 110, Bid = 105, MarketName = "sell market"},
				new PicusWithName {Ask = 120, Bid = 95, MarketName = "---"},
			};
			var a = new Chochoo(list, new TsvFileWriterMock());
			var diff = a.Process();

			Console.WriteLine(diff);
		}
	}

	public class TsvFileWriterMock : IMarketRecordProcessor
	{
		public void ProcessMarketData(IPicusData data)
		{
		}
	}
}