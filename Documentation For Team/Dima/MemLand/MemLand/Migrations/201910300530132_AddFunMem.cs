namespace MemLand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFunMem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlSlug = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        CategoryId = c.Int(nullable: false),
                        Like = c.Int(nullable: false),
                        PathImg = c.String(),
                        UserId = c.String(),
                        UrlSlug = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlSlug = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagMems",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Mem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Mem_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Mems", t => t.Mem_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Mem_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mems", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TagMems", "Mem_Id", "dbo.Mems");
            DropForeignKey("dbo.TagMems", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Mems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.TagMems", new[] { "Mem_Id" });
            DropIndex("dbo.TagMems", new[] { "Tag_Id" });
            DropIndex("dbo.Mems", new[] { "User_Id" });
            DropIndex("dbo.Mems", new[] { "CategoryId" });
            DropTable("dbo.TagMems");
            DropTable("dbo.Tags");
            DropTable("dbo.Mems");
            DropTable("dbo.Categories");
        }
    }
}
