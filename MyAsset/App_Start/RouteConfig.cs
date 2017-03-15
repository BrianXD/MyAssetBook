using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyAsset
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }  //id 改為page，for 分頁
            //);

            routes.MapRoute(
               name: "Paging1",
               url: "{controller}/{action}/{page}",
               defaults: new { controller = "Home", action = "Index", page = UrlParameter.Optional }  //id 改為page，for 分頁
           );

           // routes.MapRoute(
           //    name: "Paging2",
           //    url: "Home/{page}",
           //    defaults: new { controller = "Home", action = "Index", page = UrlParameter.Optional }  //id 改為page，for 分頁
           //);
        }
    }
}
