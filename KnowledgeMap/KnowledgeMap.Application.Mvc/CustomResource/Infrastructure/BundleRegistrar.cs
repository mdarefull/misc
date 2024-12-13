using CommonStore.Mvc.Abstracts;
using System.Web.Optimization;

namespace KnowledgeMap.Application.Mvc.CustomResource.Infrastructure
{
    public class BundleRegistrar : IBundleRegistrar
    {
        public const string BasePath = "~/CustomResource/Content/";
        public const string BaseJsPath = BasePath + "Scripts/";
        public const string BaseCssPath = BasePath + "Styles/";

        public const string AddResourcePath = "AddResource/";
        public const string CssAddResourcePath = BaseCssPath + AddResourcePath;
        public const string JsAddResourcePath = BaseJsPath + AddResourcePath;

        
        public void RegisterBundle(BundleCollection bundles)
        {
            // So far does nothing...
            //BundleConfig.RegisterJsBundle(bundles, JsAddResourcePath);
        }
    }
}