using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarketGarden.Loaders
{

	public class MarketDataLoaderStream : IMarketDataLoader
	{
		public IMarketDataParser Parser { get; set; }
		public string BaseDir { get; set; }

		public MarketDataLoaderStream(IMarketDataParser parser)
		{
			Parser = parser;
			BaseDir = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
			Console.WriteLine(BaseDir);
		}

		public List<Picus> aaa(long from, long to)
		{
			var z = new List<Picus>();

			var filename = Path.Combine( BaseDir, "Content\\130929_LTCBTC-btce");
			var counter = 0;
			string line;

			var file = new StreamReader(filename);
			while ((line = file.ReadLine()) != null)
			{
				try
				{
					var date = Parser.ParseDate(line);
					if (date < to && date > from)
					{
						z.Add(Parser.ParseRecord(line));
					}
				}
				catch (InvalidOperationException ex)
				{
					Console.WriteLine(ex.Message + string.Format(" on line {0}", counter));
				}
				counter++;
			}
			file.Close();
			return z;
		}

		public IQueryable<Picus> GetAll(DateTime from, DateTime to)
		{
			return aaa(from.ToTimestamp(), to.ToTimestamp()).AsQueryable();
		}

		public IQueryable<Picus> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}