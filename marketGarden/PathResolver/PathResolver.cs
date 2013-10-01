using System;
using System.IO;
using MarketGarden.Loaders;

namespace MarketGarden.PathResolver
{
	public class PathResolver : IPathResolver
	{
		private string BaseDir { get; set; }
		public MarketDataLoaderSettings Settings { get; set; }

		public PathResolver(MarketDataLoaderSettings settings)
		{
			Settings = settings;
			BaseDir = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
		}

		public string GetFilename(DateTime datetime)
		{
			var filename = string.Format("{0}_{1}-{2}", datetime.ToString("yyMMdd"), Settings.Symbol, Settings.Market);
			return Path.Combine(BaseDir, "Content", filename);
		}
	}
}