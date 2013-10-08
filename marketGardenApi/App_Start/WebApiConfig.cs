using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace marketGardenApi
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			//config.Routes.MapHttpRoute("marketApi", "api/cron/{action}/{xxx}/{alt}", new { controller ="Cron",  alt = RouteParameter.Optional, xxx = RouteParameter.Optional});
			config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{base}/{alt}", new { @base = RouteParameter.Optional, alt = "" });
		}
	}
}
