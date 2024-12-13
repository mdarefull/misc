using KnowledgeMap.Data.Models;
using System.Data.Entity;
using System.Reflection;

namespace KnowledgeMap.Data.EF
{
    public class KnowledgeMapDbContext : DbContext
    {
        #region Construction and Initialization
        // TODO [CHECK] PM's Migrations requires a parameterless constructor.
        public KnowledgeMapDbContext() : this(KnowledgeMapDbConfig._defaultConnectionString) { }
        public KnowledgeMapDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.Configurations.AddFromAssembly(assembly);
        }
        #endregion

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<CustomResource> CustomResources { get; set; }
    }
}