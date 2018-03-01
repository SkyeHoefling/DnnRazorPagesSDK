using System.IO;
using System.Web.Mvc;

namespace DotNetNuke.Web.Mvc.RazorPages.SDK.NETFramework
{
    public interface IDnnViewResult
    {
        void ExecuteResult(ControllerContext context, TextWriter writer);
    }
}
