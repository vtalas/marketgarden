using System;

namespace marketGarden.Models
{
	public interface IPicusData
	{
		DateTime DateTimeUtc { get; set; }
		string ToTsvLine();
	}
}