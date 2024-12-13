using KnowledgeMap.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace KnowledgeMap.Data.EF.Configurations
{
    public class ReferenceConfiguration : EntityTypeConfiguration<Reference>
    {
        public ReferenceConfiguration()
        {
            ToTable("References");
            Property(r => r.Name).IsRequired().IsUnicode(false).HasMaxLength(100).IsVariableLength();
            Property(r => r.Description).IsOptional().IsUnicode().IsMaxLength().IsVariableLength();
            Property(r => r.TargetUrl).IsRequired().IsUnicode().IsMaxLength().IsVariableLength();
        }
    }
}