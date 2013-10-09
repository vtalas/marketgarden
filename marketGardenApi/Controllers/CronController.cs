using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using MarketGarden;
using marketGarden;
using marketGarden.Models;
using MarketGarden.PathResolver;
using MarketGarden.Readers;
using MarketGarden.Recorder;
using MarketGarden.RecordProcessor;

namespace marketGardenApi.Controllers
{
	public class CronController : ApiController
	{
		// http://localhost:49288/api/cron/getbtce/ltc/btc
		public Picus GetBtce(string @base, string alt)
		{
			var pathResolver = new PathResolverWeb(@base.ToUpper(), alt.ToUpper(), "btce", HttpContext.Current);

			var settings = new MarketDataSettings
			{
				MarketReader = new BtceReader(),
				SymbolBase = @base.ToUpper(),
				SymbolAlt = alt.ToUpper(),
				MarketRecordProcessor = new TsvFileWriter(pathResolver)
			};

			return new MarketInfoRecorder(settings).Process("btce"); ;
		}

		PicusWithName MarketInfoRecorderFactory(IMarketReader reader, string marketName, string baseSymbol, string altSymbol)
		{
			var pathResolver = new PathResolverWeb(baseSymbol, altSymbol, marketName, HttpContext.Current);
			var settings = new MarketDataSettings
			{
				MarketReader = reader,
				SymbolBase = baseSymbol,
				SymbolAlt = altSymbol,
				MarketRecordProcessor = new TsvFileWriter(pathResolver)
			};

			return new MarketInfoRecorder(settings).Process(marketName);

		}

		public int GetAll(string @base, string alt)
		{
			var baseSymbol = @base.ToUpper();
			var altSymbol = alt.ToUpper();

			var x = new List<PicusWithName>
			{
				MarketInfoRecorderFactory(new BtceReader(), "btce", baseSymbol, altSymbol),
				MarketInfoRecorderFactory(new CryptoTradeReader(), "crypto", baseSymbol, altSymbol),
				MarketInfoRecorderFactory(new VirCurexReader(), "vircurex", baseSymbol, altSymbol),
				MarketInfoRecorderFactory(new McxReader(), "mcx", baseSymbol, altSymbol)
			};

			var pathResolver = new PathResolverWeb(baseSymbol, altSymbol, "diff", HttpContext.Current);
			var cho = new Chochoo(x, new TsvFileWriter(pathResolver));
			cho.Process();

			return 1;
		}

	}
}