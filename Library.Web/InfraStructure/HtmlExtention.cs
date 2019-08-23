using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Library.Web.InfraStructure
{
    public static class HtmlExtention
    {
        public static MvcHtmlString RoleButton(this HtmlHelper helper, string text, string action, string controller, string role,object RouteValues=null, object htmlAttributes=null)
        {
            var user = (LibraryPrinciple)helper.ViewContext.HttpContext.User;
            if (user.IsInRole(role))
            {
                UrlHelper uHelper = new UrlHelper();
                MvcHtmlString item = helper.ActionLink(text, action, controller, RouteValues == null ? new { } : RouteValues, htmlAttributes == null ? new { } : htmlAttributes);
                return item;
            }
            return new MvcHtmlString("");
        }
    }
}