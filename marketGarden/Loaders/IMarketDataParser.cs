using System;
using System.Collections.Generic;
using System.Globalization;

namespace MarketGarden.Loaders
{
	public interface IMarketDataParser
	{
		Picus ParseRecord(string record);
	}

	public class ParserCSV : IMarketDataParser
	{
		private const int AskPosition = 4;
		private const int BidPosition = 3;
		private readonly char[] _separator = new[] { '\t' };

		public ParserCSV()
		{
		}

		public Picus ParseRecord(string record)
		{
			var array = record.Split(_separator);

			return new Picus()
			{
				Ask = ParseDouble(AskPosition, array),
				Bid = ParseDouble(BidPosition, array)
			};
		}

		private double ParseDouble(int position, IList<string> source)
		{
			var candidate = source[position];
			double result;
			if (double.TryParse(candidate, out result))
			{
				return result;
			}
			if (double.TryParse(candidate, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out result))
			{
				return result;
			}
			throw new InvalidOperationException(string.Format("Invalid index {0} - value {1} cannot be converted to float.", position, candidate));
		}


	}
}