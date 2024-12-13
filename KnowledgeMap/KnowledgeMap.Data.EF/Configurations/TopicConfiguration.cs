using KnowledgeMap.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace KnowledgeMap.Data.EF.Configurations
{
    public class TopicConfiguration : EntityTypeConfiguration<Topic>
    {
        public TopicConfiguration()
        {
            ToTable("Topics");
            Property(t => t.Name).IsRequired().IsUnicode(false).HasMaxLength(100).IsVariableLength();
            Property(t => t.Description).IsOptional().IsUnicode().IsMaxLength().IsVariableLength();

            // This cannot cascade on delete, because there's no way the DB engine can avoid loops like: A -> B -> A.
            HasOptional(t => t.Owner).WithMany(t => t.SubTopics).WillCascadeOnDelete(false);
            HasMany(t => t.References).WithRequired(r => r.Owner).WillCascadeOnDelete();
        }
    }
}