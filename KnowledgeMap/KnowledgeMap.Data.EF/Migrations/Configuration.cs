using CommonStore.EF.Initializers;
using System.Data.Entity.Migrations;

namespace KnowledgeMap.Data.EF.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<KnowledgeMapDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KnowledgeMapDbContext context)
        {
            Seeder<KnowledgeMapDbContext>.Seed(context);
        }
    }
}