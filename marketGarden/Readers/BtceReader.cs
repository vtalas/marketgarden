using System;
using System.IO;
using System.Net;
using MarketGarden.Loaders;
using marketGarden.Models;
using Newtonsoft.Json.Linq;

namespace MarketGarden.Readers
{
	public class BtceReader : IMarketReader
	{
		private const string UrlPattern = "https://btc-e.com/api/2/{0}_{1}/ticker";

		public Market ReadData(string @base, string alt)
		{
			var request = WebRequest.Create(string.Format(UrlPattern, @base.ToLower(), alt.ToLower()));
			var response = (HttpWebResponse)request.GetResponse();

			var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
			var json = JObject.Parse(rawJson);  //Turns your raw string into a key value lookup
			var ticker = json["ticker"];

			//check data is not too old ? 
			//Console.WriteLine(ticker.ToString());
			var pic = new Market
			{
				Ask = ParserCSV.ParseDouble(ticker["buy"].ToString()),
				Bid = ParserCSV.ParseDouble(ticker["sell"].ToString()),
				Volume = ParserCSV.ParseDouble(ticker["vol_cur"].ToString()),
				DateTimeUtc = DateTime.UtcNow
			};
			return pic;
		}

		public string ShortName
		{
			get
			{
				return "btce";
			} 
		}

		string IMarketReader.TradeUrlGui(string @base, string alt)
		{
			return string.Format("https://btc-e.com/exchange/{0}_{1}", @base.ToLower(), alt.ToLower());
		}
	}
}