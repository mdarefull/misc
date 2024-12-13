using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace KnowledgeMap.Application.Mvc.Shared.Infrastructure
{
    public static class Helpers
    {
        public const string StorePartialResultKey = "StorePartialResultKey";
        public const string SessionPath = "Path";

        public static string DeferPartialViewRender(this HtmlHelper html, string partialViewName, object model = null, ViewDataDictionary viewData = null)
        {
            var result = html.Partial(partialViewName, model, viewData);

            var sb = (StringBuilder)HttpContext.Current.Items[StorePartialResultKey];
            if (sb == null)
            {
                sb = new StringBuilder();
                HttpContext.Current.Items[StorePartialResultKey] = sb;
            }
            sb.Append(result.ToHtmlString());
            return null;
        }
        public static MvcHtmlString RenderDeferredPartialViews(this HtmlHelper html)
        {
            var result = new MvcHtmlString(string.Empty);

            var sb = (StringBuilder)HttpContext.Current.Items[StorePartialResultKey];
            if (sb != null)
            {
                HttpContext.Current.Items[StorePartialResultKey] = null;
                result = new MvcHtmlString(sb.ToString());
            }

            return result;
        }
    }
}