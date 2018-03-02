namespace DotNetNuke.Web.Mvc.RazorPages.SDK
{
    public abstract class DnnWebViewPage<TModel>
#if NET45
        : NETFramework.DnnWebViewPage<TModel>
#endif
    {
    }
}
