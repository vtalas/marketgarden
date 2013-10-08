using System;
using System.IO;

namespace MarketGarden.PathResolver
{
	public class PathResolver : IPathResolver
	{
		private string BaseDir { get; set; }
		public MarketDataSettings Settings { get; set; }
		public string MarketSymbol { get; set; }

		public PathResolver(MarketDataSettings settings, string marketSymbol)
		{
			Settings = settings;
			MarketSymbol = marketSymbol;
			BaseDir = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
		}

		public string GetFilename(DateTime datetime)
		{
			var filename = string.Format("{0}_{1}{2}-{3}", datetime.ToString("yyMMdd"), Settings.SymbolBase, Settings.SymbolAlt, MarketSymbol);
			return Path.Combine(BaseDir, "Content", filename);
		}
	}
}