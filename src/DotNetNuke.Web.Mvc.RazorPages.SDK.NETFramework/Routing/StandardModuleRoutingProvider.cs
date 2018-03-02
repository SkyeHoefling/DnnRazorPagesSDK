using DotNetNuke.Collections;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Definitions;
using DotNetNuke.UI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace DotNetNuke.Web.Mvc.RazorPages.SDK.NETFramework.Routing
{
    public class StandardModuleRoutingProvider : ModuleRoutingProvider
    {
        private const string ExcludedQueryStringParams = "tabid,mid,ctl,language,popup,action,controller";
        private const string ExcludedRouteValues = "mid,ctl,popup";

        public override string GenerateUrl(RouteValueDictionary routeValues, ModuleInstanceContext moduleContext)
        {
            //Look for a module control
            string controlKey = (routeValues.ContainsKey("ctl")) ? (string)routeValues["ctl"] : String.Empty;

            List<string> additionalParams = (from routeValue in routeValues
                                             where !ExcludedRouteValues.Split(',').ToList().Contains(routeValue.Key.ToLower())
                                             select routeValue.Key + "=" + routeValue.Value)
                                             .ToList();

            string url;
            if (String.IsNullOrEmpty(controlKey))
            {
                additionalParams.Insert(0, "moduleId=" + moduleContext.Configuration.ModuleID);
                url = Globals.NavigateURL("", additionalParams.ToArray());
            }
            else
            {
                url = moduleContext.EditUrl(String.Empty, String.Empty, controlKey, additionalParams.ToArray());
            }

            return url;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext, ModuleControlInfo moduleControl)
        {
            var assemblyName = moduleControl.ControlTitle;
            
            var segments = moduleControl.ControlSrc.Replace(".razorpages", "").Split('/');
            string routeNamespace = String.Empty;
            string routeModuleName;
            string routePageName;
            if (segments.Length == 3)
            {
                routeNamespace = segments[0];
                routeModuleName = segments[1];
                routePageName = segments[2];
            }
            else
            {
                routeModuleName = segments[0];
                routePageName = segments[1];
            }

            var pageName = (httpContext == null) ? routePageName : httpContext.Request.QueryString.GetValueOrDefault("action", routePageName);
            var moduleName = (httpContext == null) ? routeModuleName : httpContext.Request.QueryString.GetValueOrDefault("controller", routeModuleName);

            var routeData = new RouteData();
            routeData.Values.Add("module", moduleName);
            routeData.Values.Add("page", pageName);
            routeData.Values.Add("assembly", assemblyName);
                        
            var moduleDef = ModuleDefinitionController.GetModuleDefinitionByID(moduleControl.ModuleDefID);
            var desktopModule = DesktopModuleController.GetDesktopModule(moduleDef.DesktopModuleID, -1);

            routeData.Values.Add("page-path", $"~/DesktopModules/MVC/{desktopModule.FolderName}/Pages/{pageName}.cshtml");

            if (httpContext != null)
            {
                foreach (var param in httpContext.Request.QueryString.AllKeys)
                {
                    if (!ExcludedQueryStringParams.Split(',').ToList().Contains(param.ToLower()))
                    {
                        routeData.Values.Add(param, httpContext.Request.QueryString[param]);
                    }
                }
            }
            if (!String.IsNullOrEmpty(routeNamespace))
            {
                routeData.DataTokens.Add("namespaces", new string[] { routeNamespace });
            }

            return routeData;
        }
    }
}
