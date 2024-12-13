using CommonStore.Mvc.Abstracts;
using CommonStore.Mvc.App_Start;
using System.Web.Optimization;

namespace KnowledgeMap.Application.Mvc.Home.Infrastructure
{
    public class BundleRegistrar : IBundleRegistrar
    {
        public const string BasePath = "~/Home/Content/";
        public const string BaseJsPath = BasePath + "Scripts/";
        public const string BaseCssPath = BasePath + "Styles/";

        public const string TopicPath = "Topic/";
        public const string CssTopicPath = BaseCssPath + TopicPath;
        public const string JsTopicPath = BaseJsPath + TopicPath;

        public const string AddTopicPath = "AddTopic/";
        public const string CssAddTopicPath = BaseCssPath + AddTopicPath;
        public const string JsAddTopicPath = BaseJsPath + AddTopicPath;

        public void RegisterBundle(BundleCollection bundles)
        {
            BundleConfig.RegisterCssBundle(bundles, CssTopicPath);
            BundleConfig.RegisterJsBundle(bundles, JsTopicPath);

            BundleConfig.RegisterJsBundle(bundles, JsAddTopicPath);
        }
    }
}