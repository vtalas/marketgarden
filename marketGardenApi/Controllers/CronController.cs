using System.IO;
using System.Web;
using System.Web.Http;
using MarketGarden;
using MarketGarden.Loaders;
using MarketGarden.PathResolver;
using MarketGarden.Readers;

namespace marketGardenApi.Controllers
{
	public class CronController : ApiController
	{
		private MarketHistoryInfo x()
		{
			var pathResolver = new PathResolverWeb(new MarketDataLoaderSettings
			{
				Market = "btce",
				SymbolBase = "LTCBTC"
			}, HttpContext.Current);

			var x = new MarketDataLoader(new ParserCSV(), pathResolver);
			return new MarketHistoryInfo(x);
		}

		///http://localhost:49288/api/cron/ltc_btc
		public Picus GetBtce(string @base, string alt)
		{
			var path = new PathResolverWeb(new MarketDataLoaderSettings
			{
				Market = "btce",
				SymbolBase = "BTC",
				SymbolAlt = "LTC",
			}, HttpContext.Current);

			var x = new BtceReader();
			var data = x.ReadData(@base, "");

			File.AppendAllText(path.GetFilename(data.DateTimeUtc), data.ToString());
			
			return data;
		}

		//http://localhost:49288/api/cron/getvircurex/LTC/BTC
		public Picus GetVirCurex(string @base, string alt)
		{
			var x = new VirCurexReader();
			var data = x.ReadData(@base, alt);
			return data;
		}

	}
}