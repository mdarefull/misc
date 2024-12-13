using System.Data.Entity.Migrations;

namespace KnowledgeMap.Data.EF.Migrations
{
    public partial class CustomResourceMimeTypeToVariableLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomResources", "MimeType", c => c.String(nullable: false, unicode: false));
        }

        public override void Down()
        {
            // TODO [FIX] This is buggy, Because I will be moving from a possible bigger length to just 12, I should execute a query 
            //  modifying those records with bigger lenght.
            AlterColumn("dbo.CustomResources", "MimeType", c => c.String(nullable: false, maxLength: 12, unicode: false));
        }
    }
}