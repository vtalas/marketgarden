using System;
using System.IO;
using System.Net;
using MarketGarden.Loaders;
using Newtonsoft.Json.Linq;

namespace MarketGarden.Readers
{
	public class CryptoTradeReader : IMarketReader
	{
		private const string UrlPattern = "https://crypto-trade.com/api/1/ticker/{0}";

		public Picus ReadData(string @base, string alt)
		{
			var request = WebRequest.Create(string.Format(UrlPattern, @base, alt));
			var response = (HttpWebResponse)request.GetResponse();

			var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
			var json = JObject.Parse(rawJson)["data"]; 

			//Console.WriteLine(json);
			var pic = new Picus
			{

				Ask = ParserCSV.ParseDouble(json["min_ask"].ToString()),
				Bid = ParserCSV.ParseDouble(json["max_bid"].ToString()),
				Volume = ParserCSV.ParseDouble(json["vol_ltc"].ToString()),
				DateTimeUtc = DateTime.UtcNow
			};
			return pic;
		}

	}
}