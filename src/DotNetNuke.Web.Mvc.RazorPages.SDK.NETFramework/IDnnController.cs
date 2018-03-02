using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.UI.Modules;
using DotNetNuke.Web.Mvc.RazorPages.SDK.NETFramework.Helpers;
using System.Web.Mvc;
using System.Web.UI;

namespace DotNetNuke.Web.Mvc.RazorPages.SDK.NETFramework
{
    public interface IDnnController : IController
    {
        ControllerContext ControllerContext { get; }
        Page DnnPage { get; set; }
        string LocalResourceFile { get; set; }
        string LocalizeString(string key);
        ModuleActionCollection ModuleActions { get; set; }
        ModuleInstanceContext ModuleContext { get; set; }
        ActionResult ResultOfLastExecute { get; }
        bool ValidateRequest { get; set; }
        ViewEngineCollection ViewEngineCollectionEx { get; set; }
        DnnUrlHelper Url { get; set; }

    }
}
