﻿using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using MarketGarden.Loaders;
using marketGarden.Models;

namespace MarketGarden.Readers
{
	public class McxReader : IMarketReader
	{
		private const string UrlPattern = "https://mcxnow.com/orders?cur={0}";

		public Market ReadData(string @base, string alt)
		{
			var request = WebRequest.Create(string.Format(UrlPattern, @base));

			//request.ContentType = "application/json; charset=utf-8";
			var response = (HttpWebResponse)request.GetResponse();

			var doc = XDocument.Load(response.GetResponseStream());

			var askString = doc.Descendants("sell").Descendants("o").Descendants("p").First();
			var bidString = doc.Descendants("buy").Descendants("o").Descendants("p").First();
			var volume = doc.Descendants("curvol").First();

			var pic = new Market()
			{
				Ask = ParserCSV.ParseDouble(askString.Value),
				Bid = ParserCSV.ParseDouble(bidString.Value),
				Volume = ParserCSV.ParseDouble(volume.Value),// + ParserCSV.ParseDouble(sellVolume.Value),
				DateTimeUtc = DateTime.UtcNow
			};
			return pic;
		}
		public string ShortName
		{
			get
			{
				return "mcx";
			}
		}

		string IMarketReader.TradeUrlGui(string @base, string alt)
		{
			return string.Format("https://mcxnow.com/exchange/{0}", @base.ToUpper());
		}

		public string TradeUrlGui { get; set; }
	}
}