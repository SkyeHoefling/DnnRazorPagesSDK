using DotNetNuke.ComponentModel;
using DotNetNuke.Entities.Modules;
using DotNetNuke.UI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace DotNetNuke.Web.Mvc.RazorPages.SDK.NETFramework.Routing
{
    public abstract class ModuleRoutingProvider
    {
        public static ModuleRoutingProvider Instance()
        {
            var component = ComponentFactory.GetComponent<ModuleRoutingProvider>();

            if (component == null)
            {
                component = new StandardModuleRoutingProvider();
                ComponentFactory.RegisterComponentInstance<ModuleRoutingProvider>(component);
            }

            return component;
        }

        public abstract string GenerateUrl(RouteValueDictionary routeValues, ModuleInstanceContext moduleContext);

        public abstract RouteData GetRouteData(HttpContextBase httpContext, ModuleControlInfo moduleControl);
    }
}
