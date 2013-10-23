﻿using marketGarden.Models;

namespace MarketGarden.Readers
{
	public interface IMarketReader
	{
		Picus ReadData(string @base, string alt);
		string ShortName { get; }
	}
}