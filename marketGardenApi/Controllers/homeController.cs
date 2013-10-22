using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using System.Web.Mvc;
using MarketGarden;
using marketGarden;
using marketGarden.Models;
using MarketGarden.PathResolver;
using MarketGarden.Readers;
using MarketGarden.Recorder;
using MarketGarden.RecordProcessor;

namespace marketGardenApi.Controllers
{
    public class HomeController : Controller
    {
		const string Litecoin = "LTC";
		const string Bitcoin = "BTC";
		const string Eur = "EUR";
		const string Usd = "USD";

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

			var lite = new List<PicusWithName>
			{
				MarketInfoRecorderFactory(new BtceReader(), "btce", Litecoin, Bitcoin),
				MarketInfoRecorderFactory(new CryptoTradeReader(), "crypto", Litecoin, Bitcoin),
				MarketInfoRecorderFactory(new VirCurexReader(), "vircurex", Litecoin, Bitcoin),
				MarketInfoRecorderFactory(new McxReader(), "mcx", Litecoin, Bitcoin),
			};

			var btcEur = new List<PicusWithName>
			{
				MarketInfoRecorderFactory(new BtceReader(), "btce", Bitcoin, Eur),
				MarketInfoRecorderFactory(new MtGoxReader(), "mtgox", Bitcoin, Eur),
				MarketInfoRecorderFactory(new CryptoTradeReader(), "crypto", Bitcoin, Eur),
				//nema deposit
				//	MarketInfoRecorderFactory(new VirCurexReader(), "vircurex", Bitcoin, Eur),
			};

			var btcUsd = new List<PicusWithName>
			{
				MarketInfoRecorderFactory(new BtceReader(), "btce", Bitcoin, Usd),
				MarketInfoRecorderFactory(new MtGoxReader(), "mtgox", Bitcoin, Usd),
				MarketInfoRecorderFactory(new CryptoTradeReader(), "crypto", Bitcoin, Usd),
				MarketInfoRecorderFactory(new BitStampReader(), "bistamp", Bitcoin, Usd),
				//nema deposit
				//MarketInfoRecorderFactory(new VirCurexReader(), "vircurex", Bitcoin, Usd),
			};

			ProcessMarket(lite, Litecoin, Bitcoin, 1);
			ProcessMarket(btcEur, Bitcoin, Eur, 5);
			ProcessMarket(btcUsd, Bitcoin, Usd, 15);

			return View();
        }

		private void ProcessMarket(List<PicusWithName> list, string @base, string alt, int thesholdPercent = 10)
	    {
			var pathResolver = new PathResolverWeb(@base, alt, "diff", System.Web.HttpContext.Current);
			var cho = new Chochoo(list, new TsvFileWriter(pathResolver));
			var diff = cho.Process();


			if (diff != null)
		    {
				var diferencePercent = (diff.Bid - diff.Ask) / diff.Ask * 100;
			    if (diferencePercent >= thesholdPercent)
			    {
					SendEmail(@base, alt, diff.ToTsvLineReadable() + " " + diferencePercent + "%");
			    }
		    }
	    }

		private void SendEmail(string @base, string alt, string body)
		{
			var message = new MailMessage { From = new MailAddress("marketgarden@aspone.cz") };

			message.To.Add(new MailAddress("vladimir.talas@gmail.com"));

			message.Subject = @base + alt;
			message.Body = body;

			var client = new SmtpClient();
			client.Send(message);
		}


		public ActionResult TestMail()
		{
			SendEmail("test", DateTime.Now.ToString(CultureInfo.InvariantCulture), "test");
			return new EmptyResult();
		}


    }
}
