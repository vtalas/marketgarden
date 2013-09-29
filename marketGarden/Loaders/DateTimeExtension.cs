using System;

namespace MarketGarden.Loaders
{
	public static class DateTimeExtension
	{
		public static long ToTimestamp(this DateTime source)
		{
			var span = (source - new DateTime(1970, 1, 1, 0, 0, 0, 0));
			return (long)span.TotalSeconds;
		}

		public static DateTime ToDateTime(this long timestamp)
		{
			var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			dateTime = dateTime.AddSeconds(timestamp);
			return dateTime;
		}
	}
}