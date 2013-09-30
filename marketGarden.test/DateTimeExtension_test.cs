using System;
using MarketGarden.Loaders;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class DateTimeExtension_test
	{
		[Test]
		public void toDateTime_test()
		{
			var datetime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddHours(2);
			const long timestamp = 7200;
			Assert.AreEqual(datetime, timestamp.ToDateTime());
		}
		
		[Test]
		public void toTimestamp_test()
		{
			var now = DateTime.Now;
			now = now.AddMilliseconds(-now.Millisecond);

			var xx = now.ToTimestamp();
			var backToDate = xx.ToDateTime();

			Assert.IsTrue(backToDate.IsEqualTo(now));
		}

		[Test]
		public void equalityOfDates_test()
		{
			var a = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			var b = new DateTime(1970, 1, 1, 0, 0, 0, 0);

			Assert.IsTrue(a.IsEqualTo(b));

			a = new DateTime(1970, 1, 1, 0, 0, 0, 1);
			b = new DateTime(1970, 1, 1, 0, 0, 0, 0);

			Assert.IsFalse(a.IsEqualTo(b));
		}

		[Test]
		public void tJsTimestamp_test()
		{
			var now = DateTime.Now;

			var xx = now.ToJsTimestamp();
			var backToDate = xx.ToDateTimeFromJsTimestamp();

			Assert.IsTrue(backToDate.IsEqualTo(now));
		}

		[Test]
		public void xxx_test()
		{
			var x = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			var now = DateTime.Now;

			//long timestamp = 1380483372;
			const long timestamp = 0;
			Console.WriteLine(x);

			Console.WriteLine(x.ToTimestamp());
			Console.WriteLine("xx");
			Console.WriteLine(x.ToUniversalTime().ToTimestamp());
			Console.WriteLine(timestamp.ToDateTime().ToLocalTime());
			Console.WriteLine(timestamp.ToDateTime());

		}
	}
}