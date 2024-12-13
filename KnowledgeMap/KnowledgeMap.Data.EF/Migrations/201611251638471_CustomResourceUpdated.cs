using System.Data.Entity.Migrations;

namespace KnowledgeMap.Data.EF.Migrations
{
    public partial class CustomResourceUpdated : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CustomResources");
            CreateTable(
                "dbo.CustomResources",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    MimeType = c.String(nullable: false, maxLength: 12, unicode: false),
                    File = c.Binary(nullable: false),
                })
                .PrimaryKey(c => c.Id);
        }

        public override void Down()
        {
            DropTable("dbo.CustomResources");
            CreateTable(
                "dbo.CustomResources",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 100, unicode: false),
                    Url = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }
    }
}