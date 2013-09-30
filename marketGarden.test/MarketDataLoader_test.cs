using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MarketGarden;
using MarketGarden.Loaders;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class MarketDataLoader_test
	{
		public IMarketDataLoader CreateDefault()
		{
			
			return new MarketDataLoaderStream(new ParserCSV());
		}

		public void Dump(IEnumerable<Picus> list)
		{
			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
	
		}
		[Test]
		public void GetAllValues_test()
		{
			var instance = CreateDefault();
			var x = instance.GetAll();
			Assert.AreEqual(x.Count(), 579);
			Console.WriteLine(x.FirstOrDefault().DateTimeUtc.ToLocalTime());
			Dump(x);
		}

		[Test]
		public void GetValues_simpleInterval_test()
		{
			var instance = CreateDefault();
			var from = new DateTime(2013, 9, 29, 0, 0, 0, 0);

			var x = instance.GetAll(from, from.AddHours(1));

			Assert.AreEqual(x.Count(), 24);
			Dump(x);
		}

		[Test]
		public void DayChangeShouldReadFromMultipleFiles_test()
		{
			var instance = CreateDefault();
			var from = new DateTime(2013, 9, 29, 23, 0, 0, 0);

			var x = instance.GetAll(from, from.AddHours(5));
			Assert.AreEqual(29, x.First().DateTimeUtc.Day);
			Assert.AreEqual(30, x.Last().DateTimeUtc.Day);
			Dump(x);
		}
	}
}