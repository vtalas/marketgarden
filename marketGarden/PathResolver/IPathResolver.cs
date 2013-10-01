using System;

namespace MarketGarden.PathResolver
{
	public interface IPathResolver
	{
		string GetFilename(DateTime datetime);
	}
}