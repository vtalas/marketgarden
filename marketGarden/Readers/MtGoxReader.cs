using System;
using System.IO;
using System.Net;
using MarketGarden.Loaders;
using marketGarden.Models;
using Newtonsoft.Json.Linq;

namespace MarketGarden.Readers
{
	public class MtGoxReader : IMarketReader
	{
		private const string UrlPattern = "http://data.mtgox.com/api/2/{0}{1}/money/ticker_fast";

		public Picus ReadData(string @base, string alt)
		{
			var request = WebRequest.Create(string.Format(UrlPattern, @base.ToUpper(), alt.ToUpper()));
			var response = (HttpWebResponse)request.GetResponse();

			var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
			var json = JObject.Parse(rawJson);  //Turns your raw string into a key value lookup
			var ticker = json["data"];

			//check data is not too old ? 
			//Console.WriteLine(ticker.ToString());
			var pic = new Picus
			{
				Ask = ParserCSV.ParseDouble(ticker["buy"]["value"].ToString()),
				Bid = ParserCSV.ParseDouble(ticker["sell"]["value"].ToString()),
				Volume = -1,
				DateTimeUtc = DateTime.UtcNow
			};
			return pic;
		}
	}
}