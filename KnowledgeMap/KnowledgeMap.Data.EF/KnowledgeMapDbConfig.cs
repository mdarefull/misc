using CommonStore.EF.Initializers;
using KnowledgeMap.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace KnowledgeMap.Data.EF
{
    public class KnowledgeMapDbConfig : DbConfiguration
    {
        public const string _defaultConnectionString = "Data Source = (localDb)\\MSSQLLocalDb;"
                                                     + "Initial Catalog = KnowledgeMapDefaultDb;"
                                                     + "Integrated Security=True;"
                                                     + "Connect Timeout=15;"
                                                     + "Pooling=True;"
                                                     + "Encrypt=False;"
                                                     + "TrustServerCertificate=False;";
        public KnowledgeMapDbConfig()
        {
            Seeder<KnowledgeMapDbContext>.SeedAction = DbSeeder;

            SetDefaultConnectionFactory();
            SetProviderServices();
            SetProviderFactory();
            SetDatabaseInitializer();
            SetSeeder();
        }

        protected virtual void SetDefaultConnectionFactory()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb", _defaultConnectionString));
        }
        protected virtual void SetProviderServices()
        {
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
        protected virtual void SetProviderFactory() { }

        protected virtual void SetDatabaseInitializer()
        {
            SetDatabaseInitializer(new DefaultInitializer<KnowledgeMapDbContext>());
        }
        protected virtual void SetSeeder()
        {
            Seeder<KnowledgeMapDbContext>.SeedAction = DbSeeder;
        }
        protected virtual void DbSeeder(KnowledgeMapDbContext context)
        {
            SeedTopics(context.Topics);

            context.SaveChanges();
        }
        private void SeedTopics(DbSet<Topic> topics)
        {
            if (topics.Count() == 0)
            {
                var universe = new Topic
                {
                    Name = "Universe",
                    Owner = null,
                    Description = "At the beggining of time, we only had the universe... it contained a set of unclear and irrelevant references.\n"
                                + "One day, a student said: Let the knowledge be made! and the related references started to gather each other into meaningfull contents, the subtopics were bornt.\n"
                                + "And then, after 5 days of subtopics and references playing together, on the 7th day of the creation, the student, finally, could rest in peace, with even the knowing being categorized.",
                    SubTopics = null,
                    References = null,
                };
                topics.Add(universe);
            }
        }
    }
}