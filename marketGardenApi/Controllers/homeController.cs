using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net.Mail;
using System.Text;
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
		MarketWithInfo RecordMarket(IMarketReader reader, string marketName, string baseSymbol, string altSymbol)
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
			var x = (MarketGetterConfig)ConfigurationManager.GetSection("marketGetter");
		    var list = new List<MarketWithInfo>();
		    foreach (var market in x.Market)
		    {
			    foreach (var reader in market.ReadersCollection)
			    {
					var instance = Activator.CreateInstance(Type.GetType(reader.Type)) as IMarketReader;
					list.Add(RecordMarket(instance, instance.ShortName, market.BaseCurrency, market.AltCurrency));
			    }
				ProcessMarket(list, market.BaseCurrency, market.AltCurrency, market.ThresholdPercent);
				list.Clear();
		    }
			return new EmptyResult();
        }

		private void ProcessMarket(List<MarketWithInfo> list, string @base, string alt, double thesholdPercent = 10)
	    {
			var pathResolver = new PathResolverWeb(@base, alt, "diff", System.Web.HttpContext.Current);
			var cho = new Chochoo(list, new TsvFileWriter(pathResolver));
			var diff = cho.Process();

			if (diff != null)
		    {
				var diferencePercent = (diff.Bid - diff.Ask) / diff.Ask * 100;
			    if (diferencePercent >= thesholdPercent)
			    {
					var body = new StringBuilder(diff.ToTsvLineReadable());
					body.Append(" ");
					body.Append(diferencePercent + "%\n");
					body.Append("BUY: " + diff.BuyMarket.TradeUrlGui + "\n");
					body.Append("SELL: " + diff.SellMarket.TradeUrlGui + "\n");

					SendEmail(@base, alt, body.ToString());
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
