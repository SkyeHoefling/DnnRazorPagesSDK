using DotNetNuke.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotNetNuke.Web.Mvc.RazorPages.SDK.NETFramework.Framework.ActionResults
{
    public class DnnRedirectToRouteResult : RedirectToRouteResult
    {
        public DnnRedirectToRouteResult(string actionName, string controllerName, string routeName, RouteValueDictionary routeValues, bool permanent)
            : base(routeName, routeValues, permanent)
        {
            ActionName = actionName;
            ControllerName = controllerName;
        }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            Requires.NotNull("context", context);

            Guard.Against(context.IsChildAction, "Cannot Redirect In Child Action");

            string url;
            //TODO - match other actions
            url = Globals.NavigateURL();

            if (Permanent)
            {
                context.HttpContext.Response.RedirectPermanent(url, true);
            }
            else
            {
                context.HttpContext.Response.Redirect(url, true);
            }


        }
    }
}
