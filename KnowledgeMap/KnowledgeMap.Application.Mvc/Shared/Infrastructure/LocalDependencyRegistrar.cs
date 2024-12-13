using CommonStore.Application.Abstracts;
using Microsoft.Practices.Unity;

namespace KnowledgeMap.Application.Mvc.Shared.Infrastructure
{
    public class LocalDependencyRegistrar : IDependencyRegistrar
    {
        public void RegisterTypes(IUnityContainer container)
        {
            // Register your local dependencies here...
            // Mainly used for injecting configurations and other properties to the controllers.
        }
    }
}