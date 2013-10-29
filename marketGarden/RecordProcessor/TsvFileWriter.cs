using System.IO;
using marketGarden.Models;
using MarketGarden.PathResolver;
using MarketGarden.Readers;

namespace MarketGarden.RecordProcessor
{
	public class TsvFileWriter : IMarketRecordProcessor
	{
		public IPathResolver PathResolver { get; set; }

		public TsvFileWriter(IPathResolver pathResolver)
		{
			PathResolver = pathResolver;
		}

		public void ProcessMarketData(IMarketData data)
		{
			File.AppendAllText(PathResolver.GetFilename(data.DateTimeUtc), data.ToTsvLine());
		}

		public Market ProcessMarketData(string symbolBase, string symbolAlt, IMarketReader marketReader)
		{

			var data = marketReader.ReadData(symbolBase, symbolAlt);
			File.AppendAllText(PathResolver.GetFilename(data.DateTimeUtc), data.ToTsvLine());
			return data;
		}
	}
}