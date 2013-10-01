using System;
using System.IO;
using MarketGarden.Loaders;
using MarketGarden.PathResolver;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class PathResolver_test
	{
		[Test]
		public void FileNameIsPuTogetherCorrectely()
		{
			var marketSettins = new MarketDataLoaderSettings()
			{
				Market = "btce",
				Symbol = "LTCBTC"
			};
			var x = new PathResolver(marketSettins);

			var date = new DateTime(13, 9, 2, 0, 0, 0, 0);
			
			Assert.AreEqual( "130902_LTCBTC-btce", Path.GetFileName(x.GetFilename(date)));
		}
	}
}