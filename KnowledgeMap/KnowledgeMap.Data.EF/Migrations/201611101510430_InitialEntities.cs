using System.Data.Entity.Migrations;

namespace KnowledgeMap.Data.EF.Migrations
{
    public partial class InitialEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomResources",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.References",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(),
                        TargetUrl = c.String(nullable: false),
                        Owner_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Owner_Id);

            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(),
                        Owner_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.References", "Owner_Id", "dbo.Topics");
            DropForeignKey("dbo.Topics", "Owner_Id", "dbo.Topics");
            DropIndex("dbo.Topics", new[] { "Owner_Id" });
            DropIndex("dbo.References", new[] { "Owner_Id" });
            DropTable("dbo.Topics");
            DropTable("dbo.References");
            DropTable("dbo.CustomResources");
        }
    }
}