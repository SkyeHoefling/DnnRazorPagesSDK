using System;
using System.IO;
using System.Web.Mvc;
using DotNetNuke.Common;

namespace DotNetNuke.Web.Mvc.RazorPages.SDK.NETFramework
{
    
    public class DnnViewResult : ViewResult, IDnnViewResult
    {
        public void ExecuteResult(ControllerContext context, TextWriter writer)
        {
            Requires.NotNull("context", context);
            Requires.NotNull("writer", writer);

            //if (String.IsNullOrEmpty(ViewName))
            //{
                ViewName = context.RouteData.GetRequiredString("page-path");
            //}

            ViewEngineResult result = null;

            if (View == null)
            {
                //result = ViewEngineCollection.FindView(context, ViewName, MasterName);
                result = new ViewEngineResult(new RazorView(context, ViewName, null, false, null), new RazorViewEngine());
                View = result.View;
            }

            var viewContext = new ViewContext(context, View, ViewData, TempData, writer);
            View.Render(viewContext, writer);

            if (result != null)
            {
                result.ViewEngine.ReleaseView(context, View);
            }
        }
    }
}
