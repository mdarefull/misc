using KnowledgeMap.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace KnowledgeMap.Data.EF.Configurations
{
    public class CustomResourceConfiguration : EntityTypeConfiguration<CustomResource>
    {
        public CustomResourceConfiguration()
        {
            ToTable("CustomResources");
            Property(cr => cr.Name).IsRequired().IsVariableLength();
            Property(cr => cr.MimeType).IsRequired().HasMaxLength(12).IsUnicode(false);
            Property(cr => cr.File).IsRequired();
        }
    }
}