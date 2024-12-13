using CommonStore.Application.App_Start;
using CommonStore.Mvc.App_Start;
using CommonStore.Mvc.Scream;
using KnowledgeMap.Application.Mvc.DiExternalModule;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KnowledgeMap.Application.Mvc
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // TODO [CHECK] ScreamRouteRegistrar HAS TO BE always the first one to be registered. Currently it works because is the only one on its assembly.
            //  This fact is prompt to change, potentially breaking the whole solution.
            //  The easier way to detect it is that it will try to route forbidden folders that match the previously registered routes instead of ignore them.
            RouteConfig.RegisterRoutes(RouteTable.Routes, typeof(ScreamRouteRegistrar).Assembly, Assembly.GetExecutingAssembly());
            BundleConfig.RegisterBundles(BundleTable.Bundles, Assembly.GetExecutingAssembly());

            UnityConfig.RegisterTypes(UnityConfig.Container, typeof(ExternalDependenciesRegistrar).Assembly);
            UnityWebActivator.Start(UnityConfig.Container);

            // Scream Architecture Setup
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ScreamRazorViewEngine());

            // Set mappings between models and view models
            ModelMappingConfig.RegisterMappings(Assembly.GetExecutingAssembly());
        }

        protected void Application_End()
        {
            UnityWebActivator.Shutdown(UnityConfig.Container);
        }
    }
}