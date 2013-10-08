using System;
using System.IO;
using System.Web;

namespace MarketGarden.PathResolver
{
	public class PathResolverWeb : IPathResolver
	{
		public string BaseSymbol { get; set; }
		public string AltSymbol { get; set; }
		public string MarketName { get; set; }
		private string BaseDir { get; set; }

		public PathResolverWeb(string baseSymbol, string altSymbol, string marketName, HttpContext httpContext)
		{
			BaseSymbol = baseSymbol;
			AltSymbol = altSymbol;
			MarketName = marketName;
			BaseDir = httpContext.Server.MapPath("~/Content");
		}

		public string GetFilename(DateTime datetime)
		{
			var filename = string.Format("{0}_{1}{2}-{3}", datetime.ToString("yyMMdd"), BaseSymbol, AltSymbol, MarketName);
			return Path.Combine(BaseDir, filename);
		}
	}
}