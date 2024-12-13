using CommonStore.Mvc.Abstracts;
using System.Web.Mvc;
using System.Web.Routing;

namespace KnowledgeMap.Application.Mvc.Shared.Infrastructure
{
    public class CoreRouteRegistrar : IRouteRegistrar
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}