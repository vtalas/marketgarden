using System;
using System.IO;
using System.Net;
using MarketGarden.Loaders;
using Newtonsoft.Json.Linq;

namespace MarketGarden.Readers
{
	public class VirCurexReader : IMarketReader
	{
		private const string UrlPattern = "https://vircurex.com/api/get_info_for_1_currency.json?base={0}&alt={1}";

		public Picus ReadData(string @base, string alt)
		{
			var request = WebRequest.Create(string.Format(UrlPattern, @base, alt));
			var response = (HttpWebResponse)request.GetResponse();

			var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
			var json = JObject.Parse(rawJson); 

			//Console.WriteLine(json);
			var pic = new Picus
			{
				Ask = ParserCSV.ParseDouble(json["lowest_ask"].ToString()),
				Bid = ParserCSV.ParseDouble(json["highest_bid"].ToString()),
				Volume = ParserCSV.ParseDouble(json["volume"].ToString()),
				DateTimeUtc = DateTime.UtcNow
			};
			return pic;
		}
	}
}