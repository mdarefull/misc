using CommonStore.Application.Abstracts;
using CommonStore.EF.Repositories;
using CommonStore.Models.Pcl;
using KnowledgeMap.Application.Mvc.DiExternalModule.InterceptionBehaviors;
using KnowledgeMap.Business.Abstracts;
using KnowledgeMap.Business.Services;
using KnowledgeMap.Data.EF;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Data.Entity;
using System.Data.SqlClient;

namespace KnowledgeMap.Application.Mvc.DiExternalModule
{
    public class ExternalDependenciesRegistrar : IDependencyRegistrar
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.AddNewExtension<Interception>();

            // Register the Data Logic dependencies here...
            DbConfiguration.SetConfiguration(new KnowledgeMapMvcDbConfig());

            var connectionString = BuildDbConnectionString();
            container.RegisterType<DbContext, KnowledgeMapDbContext>(
                                new PerRequestLifetimeManager(),
                                new InjectionConstructor(connectionString));

            // TODO [CHECK] I cannot find a correct way of doing this than performing the logging for every method.
            //      Interception, just like the decorator pattern, consist about extending the class by inhering from it, but
            //      it will be very harmful to inherit and create another DbContext, ideally we should insert the code between
            //      the call to the method, without extending the class or anything, but I cannot figure out a way to do this.
            container.RegisterType(typeof(IRepository<,>), typeof(DbContextRepository<,>),
                                   new Interceptor<InterfaceInterceptor>(),
                                   new InterceptionBehavior<RepositoryLoggingBehavior>());

            // Register the Business Logic dependencies here...
            container.RegisterType<IHomeServices, HomeServices>();
            container.RegisterType<ICustomResourceServices, CustomResourceServices>();
        }

        private string BuildDbConnectionString()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(localdb)\\MSSQLLocalDB";

#if DEBUG
            builder.InitialCatalog = "KnowledgeMapDebug";
#else
            builder.InitialCatalog = "KnowledgeMap";
#endif
            builder.IntegratedSecurity = true;
            builder.ConnectTimeout = 15;
            builder.Pooling = true;
            builder.Encrypt = false;
            builder.TrustServerCertificate = false;

            return builder.ToString();
        }
    }
}