using System;
using System.Collections.Generic;
using MarketGarden;
using marketGarden.Models;
using MarketGarden.Readers;
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
			var list = new List<MarketWithInfo>
			{
				new MarketWithInfo {Ask = 100, Bid = 90, MarketName = "buy market"},
				new MarketWithInfo {Ask = 110, Bid = 105, MarketName = "sell market"},
				new MarketWithInfo {Ask = 120, Bid = 95, MarketName = "---"},
			};
			var a = new Chochoo(list, new TsvFileWriterMock());
			var diff = a.Process();

			Console.WriteLine(diff);
		}
	}

	public class TsvFileWriterMock : IMarketRecordProcessor
	{
		public void ProcessMarketData(IMarketData data)
		{
		}

		public Market ProcessMarketData(string symbolBase, string symbolAlt, IMarketReader marketReader)
		{
			throw new NotImplementedException();
		}
	}
}