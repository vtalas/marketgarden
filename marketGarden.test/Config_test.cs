using System;
using System.Configuration;
using MarketGarden.Readers;
using marketGardenApi.Controllers;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class Config_test
	{
		[Test]
		public void check_first_level_Markets()
		{
			var x = (MarketGetterConfig)ConfigurationManager.GetSection("marketGetter");

			Assert.IsNotNull(x);
			Assert.AreEqual(2, x.Market.Count);
			
			Assert.AreEqual("BTC", x.Market[0].AltCurrency);
			Assert.AreEqual("LTC", x.Market[0].BaseCurrency);
			Assert.AreEqual(5.5, x.Market[0].ThresholdPercent);
		}
		
		[Test]
		public void check_second_level_Markets()
		{
			var x = (MarketGetterConfig)ConfigurationManager.GetSection("marketGetter");

			Assert.AreEqual(2, x.Market[0].ReadersCollection.Count);
			Assert.AreEqual("MarketGarden.Readers.BtceReader", x.Market[0].ReadersCollection[0].Type);

			var type = x.Market[0].ReadersCollection[0].Type;

			//Assert.AreEqual(typeof(BtceReader), Type.GetType(type));


		}



	}
}