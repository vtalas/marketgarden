using System;
using System.IO;
using System.Net;
using MarketGarden.Loaders;
using marketGarden.Models;
using Newtonsoft.Json.Linq;

namespace MarketGarden.Readers
{
	public class CryptoTradeReader : IMarketReader
	{
		private const string UrlPattern = "https://crypto-trade.com/api/1/ticker/{0}_{1}";
		private const string UrlTradePattern = "https://crypto-trade.com/trade/{0}_{1}";

		public Market ReadData(string @base, string alt)
		{
			var request = WebRequest.Create(string.Format(UrlPattern, @base.ToLower(), alt.ToLower()));
			var response = (HttpWebResponse)request.GetResponse();

			var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
			var json = JObject.Parse(rawJson)["data"]; 

			//Console.WriteLine(json);
			var pic = new Market
			{
				Ask = ParserCSV.ParseDouble(json["min_ask"].ToString()),
				Bid = ParserCSV.ParseDouble(json["max_bid"].ToString()),
				Volume = ParserCSV.ParseDouble(json["vol_" + @base.ToLower()].ToString()),
				DateTimeUtc = DateTime.UtcNow
			};
			return pic;
		}
		public string ShortName
		{
			get
			{
				return "crypto";
			}
		}

		public string TradeUrlGui (string @base, string alt)
		{
			return string.Format(UrlTradePattern, @base.ToLower(), alt.ToLower());
		}
	}
}