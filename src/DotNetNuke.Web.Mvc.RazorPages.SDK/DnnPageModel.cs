using System;
using System.Collections.Generic;
using System.Text;

#if NETCOREAPP2_0
using Microsoft.AspNetCore.Mvc.RazorPages;
#elif NET45
using DotNetNuke.Web.Mvc.RazorPages.SDK.NETFramework;
#endif

namespace DotNetNuke.Web.Mvc.RazorPages.SDK
{
    public class DnnPageModel
#if NECOREAPP2_0
        : PageModel
#elif NET45
        : PageModel
#endif
    {
    }
}
