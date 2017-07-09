using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebWeather
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext oHttpContext;
            Exception oException;

            oHttpContext = HttpContext.Current;

            oException = oHttpContext.Server.GetLastError();

            if (oException is HttpException)
            {
                switch ((oException as HttpException).GetHttpCode())
                {
                    case 404:

                        oHttpContext.Response.StatusCode = 404;
                        oHttpContext.Response.StatusDescription = "Not Found";
                        //oHttpContext.Response.Charset = "windows-1251";

                        oHttpContext.Server.TransferRequest("~/Weather/");

                        oHttpContext.Server.ClearError();
                        break;
                }
            }
        }

    }
}
