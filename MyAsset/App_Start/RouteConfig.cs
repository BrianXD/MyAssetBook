using System.Web.Mvc;
using System.Web.Routing;

namespace MyAsset
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //加上這行可以強制 url 小寫
            routes.LowercaseUrls = true;

            //註冊 Attribute Route(這一行要寫在前面啊啊啊啊啊，要不然routeattribute會沒作用)
            routes.MapMvcAttributeRoutes();

            //全站路由加上skilltree
            routes.MapRoute(
               name: "SkillTree",
               url: "SkillTree/{controller}/{action}/",
               defaults: new
               {
                   controller = "Home",
                   action = "Index"
               },
               namespaces: new[] { "MyAsset.Controllers" }

            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MyAsset.Controllers" }
            );
        }
    }
}
