using CommonStore.Mvc.Abstracts;
using System.Web.Optimization;

namespace KnowledgeMap.Application.Mvc.Shared.Infrastructure
{
    public class CoreBundleRegistrar : IBundleRegistrar
    {
        public const string BasePath = "~/Shared/Content/";

        public const string CssCorePath = BasePath + "Styles/";
        public const string JsCorePath = BasePath + "Scripts/";

        public void RegisterBundle(BundleCollection bundles)
        {
            var cssCore = new StyleBundle(CssCorePath)
                                 .Include(CssCorePath + "bootstrap.css")
                                 .Include(CssCorePath + "bootstrap-theme.css")
                                 .Include(CssCorePath + "site.css");
            bundles.Add(cssCore);

            var jsCore = new ScriptBundle(JsCorePath)
                                 .Include(JsCorePath + "jquery-{version}.js")
                                 .Include(JsCorePath + "bootstrap.js")
                                 .Include(JsCorePath + "jquery.validate.js")
                                 .Include(JsCorePath + "jquery.validate.unobtrusive.js")
                                 .Include(JsCorePath + "jquery.unobtrusive-ajax.js");
            bundles.Add(jsCore);
        }
    }
}