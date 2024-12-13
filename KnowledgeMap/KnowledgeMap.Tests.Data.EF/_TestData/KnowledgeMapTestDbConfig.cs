using CommonStore.EF.Tests;
using Effort.Provider;
using KnowledgeMap.Data.EF;

namespace KnowledgeMap.Tests.Data.EF._TestData
{
    internal sealed class KnowledgeMapTestDbConfig : KnowledgeMapDbConfig
    {
        protected sealed override void SetDefaultConnectionFactory()
        {
            SetDefaultConnectionFactory(new TestDbConnectionFactory());
        }
        protected sealed override void SetProviderFactory()
        {
            EffortProviderConfiguration.RegisterProvider();
        }
        protected sealed override void DbSeeder(KnowledgeMapDbContext context) { }
    }
}