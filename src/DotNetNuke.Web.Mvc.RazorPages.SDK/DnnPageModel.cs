using System;
using System.Collections.Generic;
using System.Text;


#if NET_CORE
using Microsoft.AspNetCore.Mvc.RazorPages;
#elif NET45
using DotNetNuke.Web.Mvc.RazorPages.SDK.NETFramework;
using System.Web.Mvc;
using System.Web.UI;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.UI.Modules;
#endif

namespace DotNetNuke.Web.Mvc.RazorPages.SDK
{
    public class DnnPageModel
#if NET_CORE
        : PageModel
#elif NET45
        : DnnViewResult
#endif
    {
#if NET45
        public bool ValidateRequest { get; set; }
        public Page Page { get; set; }
        public ModuleInstanceContext ModuleContext { get; set; }
        public ModuleActionCollection ModuleActions { get; set; }
        public string LocalResourceFile { get; set; }
        public ViewEngineCollection ViewEngineCollectionEx { get; set; }
        public ActionResult ResultOfLastExecute
        {
            get
            {
                var result = new DnnViewResult
                {
                    ViewName = "Index",
                    ViewData = new ViewDataDictionary(this)
                };

                return result;
            }
        }
        public ControllerContext PageContext { get; set; }
#endif
    }
}
