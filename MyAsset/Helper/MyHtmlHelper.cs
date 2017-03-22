using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MyAsset.Helper
{
    public static class MyHtmlHelper
    {


        public static bool MyCategoryCSSClass(this HtmlHelper helper, string category)
        {
            return (category == "支出");
        }
        public static MvcHtmlString MyCategoryHtml(this HtmlHelper helper, string category)
        {

            string colorCode = category == "支出" ? "#880015" : "#104D67";
            string tag = $"<span style='color:{colorCode}'>{category}</span>";
            MvcHtmlString m = new MvcHtmlString(tag);
            return m;
        }
        public static string MyShowControllerAndActionName(this HtmlHelper helper)
        {
            var currentControllerName =
                (string)helper.ViewContext.RouteData.Values["controller"];

            var currentActionName =
                (string)helper.ViewContext.RouteData.Values["action"];

            return string.Format(
                "<h3>您現在的Controller為【{0}】Action為【{1}】</h3>",
                currentControllerName,
                currentActionName);
        }
    }
}