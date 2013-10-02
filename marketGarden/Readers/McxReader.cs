using System;
using System.Net;
using System.Xml.Linq;

namespace MarketGarden.Readers
{
	public class McxReader : IMarketReader
	{
		private const string UrlPattern = "https://mcxnow.com/orders?cur={0}";

		public string ReadData(string symbol)
		{
			var request = WebRequest.Create(string.Format(UrlPattern, symbol));

			//request.ContentType = "application/json; charset=utf-8";
			var response = (HttpWebResponse)request.GetResponse();

			var doc = XDocument.Load(response.GetResponseStream());
			var a = doc.Descendants("doc").Descendants("buy");
			Console.WriteLine(a.ToString());
			return "xx";
		}
	}
}