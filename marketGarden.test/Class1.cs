using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketGarden;
using MarketGarden.Loaders;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class MarketHistoryInfo_test
	{
		private long ConvertToTimestamp(DateTime value)
		{
			var span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToUniversalTime());
			return (long)span.TotalSeconds;
		}

		public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
		{
			var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToUniversalTime();
			dateTime = dateTime.AddSeconds(unixTimeStamp);
			return dateTime;
		}
		[Test]
		public void Xx()
		{
			var date = DateTime.Now.ToUniversalTime();
			var timestamp = ConvertToTimestamp(date);

			Console.WriteLine(date);
			Console.WriteLine(timestamp);
			Console.WriteLine(UnixTimeStampToDateTime(timestamp));
			Console.WriteLine(UnixTimeStampToDateTime(1380221083));
			Console.WriteLine(UnixTimeStampToDateTime(1380224702));
			Console.WriteLine(date - UnixTimeStampToDateTime(timestamp));
		}

		public MarketHistoryInfo CreateDefault()
		{
			var x = new MarketDataLoader(new ParserCSV());
			return new MarketHistoryInfo(x);
		}

		[Test]
		public void DefaultTimesetShouldBeReturned()
		{
			var instance = CreateDefault();
			var list = instance.GetInfo();
			Assert.Greater(0, list.Count);
			Assert.Less(list.Count, MarketHistoryInfo.MaxCount);
		}

		[Test]
		public void TimeIntervalShouldBeInBoundaries()
		{
			var from = DateTime.Now.AddDays(-2);
			var to = DateTime.Now.AddDays(-1);

			var instance = CreateDefault();
			var list = instance.GetInfo(from, to);
			Assert.Greater(0, list.Count);
			Assert.Less(list.Count, MarketHistoryInfo.MaxCount);

			Assert.Greater(list.First().DateTime, from);
			Assert.LessOrEqual(list.Last().DateTime, to);
		}
	}
}
