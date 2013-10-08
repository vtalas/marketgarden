using System;
using System.IO;
using MarketGarden.PathResolver;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class PathResolver_test: Chuj
	{
		[Test]
		public void FileNameIsPutTogetherCorrectely()
		{
			var x = GetPathResolver();
			var date = new DateTime(13, 9, 2, 0, 0, 0, 0);
			Assert.AreEqual( "130902_LTCBTC-btce", Path.GetFileName(x.GetFilename(date)));
		}

		[Test]
		public void xx()
		{
			var x = new PathResolver(GetDefaultMarketSettings(), "btce");
			var from = new DateTime(2013, 10, 1, 0, 0, 0, 0); ;
			var to = from.AddHours(5);

			Console.WriteLine(from);
			Console.WriteLine(to);
			
			Assert.AreEqual( "130901_LTCBTC-btce", Path.GetFileName(x.GetFilename(to)));
		}
	}
}