using KnowledgeMap.Application.Mvc.DiExternalModule;
using Microsoft.Practices.Unity.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(ModuleRegistration), "RegisterModule")]
namespace KnowledgeMap.Application.Mvc.DiExternalModule
{
    public class ModuleRegistration
    {
        public static void RegisterModule()
        {
            DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }
    }
}