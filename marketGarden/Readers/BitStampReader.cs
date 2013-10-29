using System;
using System.IO;
using System.Net;
using MarketGarden.Loaders;
using marketGarden.Models;
using Newtonsoft.Json.Linq;

namespace MarketGarden.Readers
{
	public class BitStampReader : IMarketReader
	{
		private const string UrlPattern = "https://www.bitstamp.net/api/ticker/";

		public Market ReadData(string @base, string alt)
		{
			var request = WebRequest.Create(UrlPattern);
			var response = (HttpWebResponse)request.GetResponse();

			var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
			var ticker = JObject.Parse(rawJson);  //Turns your raw string into a key value lookup

			//check data is not too old ? 
			//Console.WriteLine(ticker.ToString());
			var pic = new Market
			{
				Ask = ParserCSV.ParseDouble(ticker["ask"].ToString()),
				Bid = ParserCSV.ParseDouble(ticker["bid"].ToString()),
				Volume = ParserCSV.ParseDouble(ticker["volume"].ToString()),
				DateTimeUtc = DateTime.UtcNow
			};
			return pic;
		}

		public string ShortName
		{
			get
			{
				return "bitstamp";
			}
		}

		string IMarketReader.TradeUrlGui(string @base, string alt)
		{
			return "https://www.bitstamp.net";
		}
	}
}