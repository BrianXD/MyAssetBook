using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MyAsset.Helper
{/// <summary>
 /// 權限限制的 ActionLink 擴充方法
 /// </summary>
    public static class AuthLinkHelper
    {
        /// <summary>
        /// Actions the link authorized.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">連結文字</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="allowRole">允許的群組（可用逗點分隔）</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName,
            string allowRole)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, new RouteValueDictionary(),
                new RouteValueDictionary(), allowRole);
        }

        /// <summary>
        /// Actions the link authorized.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">連結文字</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="allowRole">允許的群組（可用逗點分隔）</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName,
            object routeValues, string allowRole)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, new RouteValueDictionary(routeValues),
                new RouteValueDictionary(), allowRole);
        }

        /// <summary>
        /// Actions the link authorized.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">連結文字</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="allowRole">允許的群組（可用逗點分隔）</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, string allowRole)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, controllerName, new RouteValueDictionary(),
                new RouteValueDictionary(), allowRole);
        }

        /// <summary>
        /// Actions the link authorized.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">連結文字</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="allowRole">允許的群組（可用逗點分隔）</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName,
            RouteValueDictionary routeValues, string allowRole)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, routeValues, new RouteValueDictionary(),
                allowRole);
        }

        /// <summary>
        /// Actions the link authorized.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">連結文字</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="allowRole">允許的群組（可用逗點分隔）</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName,
            object routeValues, object htmlAttributes, string allowRole)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, new RouteValueDictionary(routeValues),
                new RouteValueDictionary(htmlAttributes), allowRole);
        }

        /// <summary>
        /// Actions the link authorized.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">連結文字</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="allowRole">允許的群組（可用逗點分隔）</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName,
            RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, string allowRole)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, null, routeValues, htmlAttributes, allowRole);
        }

        /// <summary>
        /// Actions the link authorized.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">連結文字</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="allowRole">允許的群組（可用逗點分隔）</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, object routeValues, object htmlAttributes, string allowRole)
        {
            return htmlHelper.ActionLinkAuthorized(linkText, actionName, controllerName,
                new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes), allowRole);
        }

        /// <summary>
        /// Actions the link authorized.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">連結文字</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="allowRole">允許的群組（可用逗點分隔）</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes,
            string allowRole)
        {
            if (string.IsNullOrWhiteSpace(allowRole) == false)
            {
                var roles = new List<string>() { allowRole };
                if (allowRole.Contains(","))
                {
                    roles = allowRole.Split(',').ToList();
                }
                if (roles.Any(role => HttpContext.Current.User.IsInRole(role)))
                {
                    return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
                }
            }

            return MvcHtmlString.Empty;
        }
    }
}