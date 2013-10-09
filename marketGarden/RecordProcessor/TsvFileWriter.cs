using System.IO;
using marketGarden;
using marketGarden.Models;
using MarketGarden.PathResolver;

namespace MarketGarden.RecordProcessor
{
	public class TsvFileWriter : IMarketRecordProcessor
	{
		public IPathResolver PathResolver { get; set; }

		public TsvFileWriter(IPathResolver pathResolver)
		{
			PathResolver = pathResolver;
		}

		public void ProcessMarketData(IPicusData data)
		{
			File.AppendAllText(PathResolver.GetFilename(data.DateTimeUtc), data.ToTsvLine());
		}
	}
}