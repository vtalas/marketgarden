using System.IO;
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

		public void ProcessMarketData(Picus data)
		{
			File.AppendAllText(PathResolver.GetFilename(data.DateTimeUtc), data.ToTsvLine());
		}
	}
}