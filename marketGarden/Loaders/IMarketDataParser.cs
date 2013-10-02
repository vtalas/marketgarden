using System;
using System.Collections.Generic;
using System.Globalization;

namespace MarketGarden.Loaders
{
	public interface IMarketDataParser
	{
		Picus ParseRecord(string record);
		long ParseDate(string record);
	}

	public class ParserCSV : IMarketDataParser
	{
		private const int AskPosition = 4;
		private const int BidPosition = 3;
		private const int DateTimePosition = 2;
		private readonly char[] _separator = new[] { '\t' };

		public Picus ParseRecord(string record)
		{
			var array = record.Split(_separator);

			return new Picus()
			{
				Ask = ParseDouble(array[AskPosition]),
				Bid = ParseDouble(array[BidPosition]),
				DateTimeUtc = ParseLong(DateTimePosition, array).ToDateTime()
			};
		}

		public long ParseDate(string record)
		{
			var array = record.Split(_separator);
			return ParseLong(DateTimePosition, array);
		}

		public static double ParseDouble(string candidate)
		{
			double result;
			if (double.TryParse(candidate, out result))
			{
				return result;
			}
			if (double.TryParse(candidate, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out result))
			{
				return result;
			}
			throw new InvalidOperationException(string.Format("Value {0} cannot be converted to float.", candidate));
		}

		private long ParseLong(int position, IList<string> source)
		{
			var candidate = source[position];
			long result;
			if (long.TryParse(candidate, out result))
			{
				return result;
			}
			throw new InvalidOperationException(string.Format("Invalid index {0} - value {1} cannot be converted to int.", position, candidate));
		}


	}
}