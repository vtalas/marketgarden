using System.Collections.Generic;
using System.Web.Mvc;
using MarketGarden;
using marketGarden;
using MarketGarden.PathResolver;
using MarketGarden.Readers;
using MarketGarden.Recorder;
using MarketGarden.RecordProcessor;

namespace marketGardenApi.Controllers
{
    public class HomeController : Controller
    {
		PicusWithName MarketInfoRecorderFactory(IMarketReader reader, string marketName, string baseSymbol, string altSymbol)
		{
			var pathResolver = new PathResolverWeb(baseSymbol, altSymbol, marketName, System.Web.HttpContext.Current);
			var settings = new MarketDataSettings
			{
				MarketReader = reader,
				SymbolBase = baseSymbol,
				SymbolAlt = altSymbol,
				MarketRecordProcessor = new TsvFileWriter(pathResolver)
			};

			return new MarketInfoRecorder(settings).Process(marketName);

		}
		public ActionResult Index()
        {
			const string baseSymbol = "LTC";
	        const string altSymbol = "BTC";

			var x = new List<PicusWithName>
			{
				MarketInfoRecorderFactory(new BtceReader(), "btce", baseSymbol, altSymbol),
				MarketInfoRecorderFactory(new CryptoTradeReader(), "crypto", baseSymbol, altSymbol),
				MarketInfoRecorderFactory(new VirCurexReader(), "vircurex", baseSymbol, altSymbol),
				MarketInfoRecorderFactory(new McxReader(), "mcx", baseSymbol, altSymbol)
			};

			var pathResolver = new PathResolverWeb(baseSymbol, altSymbol, "diff", System.Web.HttpContext.Current);
			var cho = new Chochoo(x, new TsvFileWriter(pathResolver));
			cho.Process();

			return View();
        }

    }
}
