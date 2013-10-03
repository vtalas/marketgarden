using System;
using System.IO;
using System.Web;
using MarketGarden.Loaders;

namespace MarketGarden.PathResolver
{
	public class PathResolverWeb : IPathResolver
	{
		private string BaseDir { get; set; }
		public MarketDataLoaderSettings Settings { get; set; }

		public PathResolverWeb(MarketDataLoaderSettings settings, HttpContext current)
		{
			Settings = settings;
			BaseDir = current.Server.MapPath("~/Content");
		}

		public string GetFilename(DateTime datetime)
		{
			var filename = string.Format("{0}_{1}-{2}", datetime.ToString("yyMMdd"), Settings.Symbol, Settings.Market);
			return Path.Combine(BaseDir, filename);
		}
	}
}