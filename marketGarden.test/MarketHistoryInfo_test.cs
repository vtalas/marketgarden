using System;
using System.Linq;
using MarketGarden;
using MarketGarden.Loaders;
using MarketGarden.PathResolver;
using Newtonsoft.Json;
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

			var from = new DateTime(2013, 9, 29, 23, 0, 0, 0);
			var to = from.AddHours(5);
			TimeSpan xx = new TimeSpan(1, 0, 0, 0);

			Console.WriteLine(xx.TotalDays );
//			Console.WriteLine(timestamp);
//			Console.WriteLine(UnixTimeStampToDateTime(timestamp));
//			Console.WriteLine(UnixTimeStampToDateTime(1380221083));
//			Console.WriteLine(UnixTimeStampToDateTime(1380224702));
//			Console.WriteLine(date - UnixTimeStampToDateTime(timestamp));
		}

		public MarketHistoryInfo CreateDefault()
		{
			var pathResolver = new PathResolver(new MarketDataLoaderSettings
			{
				Market = "btce",
				SymbolBase = "LTCBTC"
			});

			var x = new MarketDataLoader(new ParserCSV(), pathResolver);
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
			var from = new DateTime(2013, 10, 1, 0, 0, 0, 0); ;
			var to = from.AddHours(5);

			var instance = CreateDefault();
			var list = instance.GetInfo(from, to);
			Assert.Greater(list.Count, 0);
			Assert.Less(list.Count, MarketHistoryInfo.MaxCount);

			Assert.Greater(list.First().DateTimeUtc, from);
			Assert.LessOrEqual(list.Last().DateTimeUtc, to);
		}

		[Test]
		public void ConvertSimpleInterval_toJson()
		{
			var from = new DateTime(2013, 10, 1, 0, 0, 0, 0); ;
			var to = from.AddHours(5);

			var instance = CreateDefault();
			var list = instance.GetInfo(from, to);
			var json = JsonConvert.SerializeObject(list);

			Console.WriteLine(json);
		}

	}
}
