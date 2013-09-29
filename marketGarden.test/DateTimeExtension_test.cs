using System;
using MarketGarden.Loaders;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class DateTimeExtension_test
	{
		[Test]
		public void toTimestamp_test()
		{
			var x = DateTime.Now;

			var xx = x.ToTimestamp();
			var backToDate = xx.ToDateTime();

			Assert.AreEqual(backToDate, x);
		}
		[Test]
		public void xxx_test()
		{
			var x = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			var now = DateTime.Now;

			long timestamp = 1380483372;
			Console.WriteLine(now);
			Console.WriteLine(now.ToUniversalTime());

			Console.WriteLine(x.ToTimestamp());
			Console.WriteLine("xx");
			Console.WriteLine(x.ToUniversalTime().ToTimestamp());
			Console.WriteLine(timestamp.ToDateTime().ToLocalTime());
			Console.WriteLine(timestamp.ToDateTime());

		}
	}
}