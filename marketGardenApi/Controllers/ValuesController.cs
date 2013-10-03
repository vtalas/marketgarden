using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MarketGarden;
using MarketGarden.Loaders;
using MarketGarden.PathResolver;
using Microsoft.Ajax.Utilities;

namespace marketGardenApi.Controllers
{
	public class ValuesController : ApiController
	{
		private MarketHistoryInfo x()
		{
			var pathResolver = new PathResolverWeb(new MarketDataLoaderSettings
			{
				Market = "btce",
				Symbol = "LTCBTC"
			}, HttpContext.Current);

			var x = new MarketDataLoader(new ParserCSV(), pathResolver);
			return new MarketHistoryInfo(x);
		}
		
		// GET api/values
		public IEnumerable<Picus> Get()
		{
			var from = new DateTime(2013, 10, 3, 0, 0, 0, 0); ;
			var to = from.AddHours(5);
			return x().GetInfo(from, to).ToList();
		}

		// GET api/values/5
		public string Get(int id)
		{
			var pathx = HttpContext.Current;
			var path = HttpContext.Current.Server.MapPath("~/Content/");
			return path;
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}