﻿using System;
using MarketGarden.Readers;
using NUnit.Framework;

namespace marketGarden.test
{
	[TestFixture]
	public class MarketReaders_test
	{
		[Test]
		public void mcx()
		{
			var x = new McxReader();
			var response = x.ReadData("LTC");

			Console.WriteLine(response);

		}
	}
}