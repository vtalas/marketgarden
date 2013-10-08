using System;
using MarketGarden.Readers;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	[Ignore]
	public class MarketReaders_test
	{
		[Test]
		public void mcx()
		{
			var x = new McxReader();
			var response = x.ReadData("LTC", "");

			Console.WriteLine(response.ToString());
			Assert.Less(response.Bid, response.Ask);
			Assert.Greater(response.Volume, 0);
		}

		[Test]
		public void btce_test()
		{
			var x = new BtceReader();
			var data = x.ReadData("LTC", "BTC");

			Console.WriteLine(data.ToString());
			Assert.Less(data.Bid, data.Ask);
			Assert.Greater(data.Volume, 0);
		}

		[Test]
		public void vircurex_test()
		{
			var x = new VirCurexReader();
			var data = x.ReadData("LTC", "BTC");

			Console.WriteLine(data.ToString());
			Assert.Less(data.Bid, data.Ask);
			Assert.Greater(data.Volume, 0);
		}

		[Test]
		public void CryptoTrade_test()
		{
			var x = new CryptoTradeReader();
			var data = x.ReadData("ltc", "btc");

			Console.WriteLine(data.ToString());
			Assert.Less(data.Bid, data.Ask);
			Assert.Greater(data.Volume, 0);
		}
	}
}