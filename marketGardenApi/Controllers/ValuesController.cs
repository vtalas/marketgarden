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