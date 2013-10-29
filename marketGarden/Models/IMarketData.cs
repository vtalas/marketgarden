using System;

namespace marketGarden.Models
{
	public interface IMarketData
	{
		DateTime DateTimeUtc { get; set; }
		string ToTsvLine();
	}
}