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

            //for 分頁Route
            //當url為: /Home/Index/paging/1 (數字) 時才會套用
            routes.MapRoute(
               name: "Paging",
               url: "{controller}/{action}/paging/{page}",
               defaults: new
               {
                   controller = "Home",
                   action = "Index",
                   page = UrlParameter.Optional
               },  //for 分頁
               constraints: new { controller = "Home", action = "index", page = @"(\d*)" }
           );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }  //id 改為page，for 分頁
            );
        }
    }
}
