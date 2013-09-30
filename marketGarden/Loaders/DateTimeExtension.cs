using System;

namespace MarketGarden.Loaders
{
	public static class DateTimeExtension
	{
		public static long ToTimestamp(this DateTime source)
		{
			var span = (source - new DateTime(1970, 1, 1, 0, 0, 0, 0));
			return (long) span.TotalSeconds;
		}

		public static ulong ToJsTimestamp(this DateTime source)
		{
			return (ulong)source.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
		}

		public static DateTime ToDateTime(this long timestamp)
		{
			var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			dateTime = dateTime.AddSeconds(timestamp);
			return dateTime;
		}

		public static DateTime ToDateTimeFromJsTimestamp(this ulong timestamp)
		{
			var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			dateTime = dateTime.AddMilliseconds(timestamp);
			return dateTime;
		}

		public static bool IsEqualTo(this DateTime source, DateTime source2)
		{
			return Math.Abs(source.Subtract(source2).TotalMilliseconds) < 1;
		}
	}
}