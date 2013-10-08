using System.Web;
using System.Web.Http;
using MarketGarden;
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

			return new MarketInfoRecorder(settings).Process(); ;
		}
	}
}