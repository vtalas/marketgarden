using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using MarketGarden.Loaders;

namespace MarketGarden.Readers
{
	public class McxReader : IMarketReader
	{
		private const string UrlPattern = "https://mcxnow.com/orders?cur={0}";

		public Picus ReadData(string @base, string alt)
		{
			var request = WebRequest.Create(string.Format(UrlPattern, @base));

			//request.ContentType = "application/json; charset=utf-8";
			var response = (HttpWebResponse)request.GetResponse();

			var doc = XDocument.Load(response.GetResponseStream());

			var askString = doc.Descendants("sell").Descendants("o").Descendants("p").First();
			var bidString = doc.Descendants("buy").Descendants("o").Descendants("p").First();
			var volume = doc.Descendants("curvol").First();

			var pic = new Picus()
			{
				Ask = ParserCSV.ParseDouble(askString.Value),
				Bid = ParserCSV.ParseDouble(bidString.Value),
				Volume = ParserCSV.ParseDouble(volume.Value),// + ParserCSV.ParseDouble(sellVolume.Value),
				DateTimeUtc = DateTime.UtcNow
			};
			return pic;
		}
	}
}