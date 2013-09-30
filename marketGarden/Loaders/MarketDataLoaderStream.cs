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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parser"></param>
		public MarketDataLoaderStream(IMarketDataParser parser)
		{
			Parser = parser;
			BaseDir = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
			Console.WriteLine(BaseDir);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public IQueryable<Picus> GetAll(DateTime from, DateTime to)
		{
			return Aaaa(line =>
			{
				var date = Parser.ParseDate(line);
				if (date <= to.ToTimestamp() && date >= from.ToTimestamp())
				{
					return Parser.ParseRecord(line);
				}
				return null;
			}).AsQueryable();
		}

		/// <summary>
		/// 
		/// 
		/// </summary>
		/// <returns></returns>
		public IQueryable<Picus> GetAll()
		{
			return Aaaa(line => Parser.ParseRecord(line)).AsQueryable();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parseLine"></param>
		/// <returns></returns>
		private IEnumerable<Picus> Aaaa(Func<string, Picus> parseLine)
		{
			var z = new List<Picus>();
			var counter = 0;
			var filename = Path.Combine(BaseDir, "Content\\130929_LTCBTC-btce");

			using (var file = new StreamReader(filename))
			{
				string line;
				while ((line = file.ReadLine()) != null)
				{
					try
					{
						var newPicus = parseLine(line);
						if (newPicus != null)
						{
							z.Add(newPicus);
						}
					}
					catch (InvalidOperationException ex)
					{
						Console.WriteLine(ex.Message + string.Format(" on line {0}", counter));
					}
					counter++;
				}
			}
			return z;
		}
	}
}